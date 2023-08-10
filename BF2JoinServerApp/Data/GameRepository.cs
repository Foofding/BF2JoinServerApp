using System;
using System.IO;

namespace BF2JoinServerApp.Data
{
    /// <summary>
    /// Represents a repository for accessing BF2-related information
    /// </summary>
    public class GameRepository
    {
        public Game _game { get; set; }

        /// <summary>
        /// Initializes a new instance of the GameRepository class
        /// </summary>
        public GameRepository()
        {
            _game = new Game();
            CheckInstallation();
        }

        /// <summary>
        /// Gets the directory path of the game
        /// </summary>
        /// <returns>The directory path of the game</returns>
        public string GetDirectoryPath()
        {
            return _game.DirectoryPath;
        }

        /// <summary>
        /// Gets the executable path of the game
        /// </summary>
        /// <returns>The executable path of the game</returns>
        public string GetExecutablePath()
        {
            return _game.ExecutablePath;
        }

        /// <summary>
        /// Checks if the game is installed
        /// </summary>
        /// <returns>True if the game is installed, false otherwise</returns>
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
