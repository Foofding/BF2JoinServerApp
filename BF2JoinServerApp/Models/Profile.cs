namespace BF2JoinServerApp.Models
{
    public class Profile
    {
        public Profile(string name, string nick, int totalPlayTime, int numTimesLoggedIn)
        {
            this.Name = name;
            this.Nick = nick;
            this.TotalPlayedTime = totalPlayTime;
            this.NumTimesLoggedIn = numTimesLoggedIn;
        }

        public string Name { get; set; }
        public string Nick { get; set; }
        public int TotalPlayedTime { get; set; }
        public int NumTimesLoggedIn { get; set; }
    }
}
