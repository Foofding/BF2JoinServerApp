namespace BF2JoinServerApp.Models
{
    public class Profile
    {
        public Profile(string name, int playTime)
        {
            this.Name = name;
            this.PlayTime = playTime;
        }

        public string Name { get; set; }
        public int PlayTime { get; set; }
    }
}
