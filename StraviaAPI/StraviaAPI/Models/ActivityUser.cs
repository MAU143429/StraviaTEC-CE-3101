namespace StraviaAPI.Models
{
    public class ActivityUser
    {
        public String Username { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public int Duration { get; set; }
        public String Type { get; set; }
        public int Distance { get; set; }
        public int Altitude { get; set; }
        public String Route { get; set; }
        public int NoChallenge { get; set; }
    }
}
