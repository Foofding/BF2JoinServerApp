namespace BF2JoinServerApp.Models
{
    public class Profile
    {
        public Profile(string name, string nick, int totalPlayTime, int numTimesLoggedIn, string? folderPath)
        {
            this.Name = name;
            this.Nick = nick;
            this.TotalPlayedTime = totalPlayTime;
            this.NumTimesLoggedIn = numTimesLoggedIn;
            if (folderPath != null) { this.FolderName = folderPath; }

        }

        public string Name { get; set; }
        public string Nick { get; set; }
        public int TotalPlayedTime { get; set; }
        public int NumTimesLoggedIn { get; set; }

        public string? FolderName { get; set; }
    }
}
