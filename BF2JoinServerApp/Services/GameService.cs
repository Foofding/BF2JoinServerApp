using BF2JoinServerApp.Data;

namespace BF2JoinServerApp.Services
{
    /// <summary>
    /// Provides services for interacting with the BF2-related information
    /// </summary>
    public class GameService
    {
        private readonly GameRepository _gameRepository;

        /// <summary>
        /// Initializes a new instance of the GameService class
        /// </summary>
        public GameService()
        {
            _gameRepository = new GameRepository();
        }

        /// <summary>
        /// Gets the directory path of the game
        /// </summary>
        /// <returns>The directory path of the game</returns>
        public string GetDirectoryPath()
        {
            return _gameRepository.GetDirectoryPath();
        }

        /// <summary>
        /// Gets the executable path of the game
        /// </summary>
        /// <returns>The executable path of the game</returns>
        public string GetExecutablePath()
        {
            return _gameRepository.GetExecutablePath();
        }

        /// <summary>
        /// Checks if the game is installed
        /// </summary>
        /// <returns>True if the game is installed, false otherwise</returns>
        public bool CheckInstallation()
        {
            return _gameRepository.CheckInstallation();
        }
    }
}
