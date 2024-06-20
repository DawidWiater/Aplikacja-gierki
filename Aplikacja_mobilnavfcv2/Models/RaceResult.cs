using SQLite;

namespace Aplikacja_gierki.Models
{
    public class RaceResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RaceTitle { get; set; }
        public string ParticipantName { get; set; }
        public int Points { get; set; }
    }
}
