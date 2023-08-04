using System;
using System.IO;

namespace BF2JoinServerApp.Data
{
    public class GameRepository
    {
        public Game _game { get; set; }

        public GameRepository()
        {
            _game = new Game();
            CheckInstallation();
        }

        public string GetDirectoryPath()
        {
            return _game.DirectoryPath;
        }

        public string GetExecutablePath()
        {
            return _game.ExecutablePath;
        }

        public bool CheckInstallation()
        {
            if (Directory.Exists(_game.DirectoryPath))
            {
                if (File.Exists(_game.ExecutablePath))
                {
                    _game.Exists = true;
                }
                else
                {
                    throw new Exception("BF2.exe not found!");
                }
            }
            else
            {
                throw new Exception("Game directory not found!");
            }

            return _game.Exists;
        }
    }
}
