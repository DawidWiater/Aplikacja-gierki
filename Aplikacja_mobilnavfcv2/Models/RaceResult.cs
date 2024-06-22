using SQLite;

namespace Aplikacja_gierki.Models
{
    public class RaceResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RaceTitle { get; set; } = string.Empty; // Domyœlna wartoœæ
        public string ParticipantName { get; set; } = string.Empty; // Domyœlna wartoœæ
        public int Points { get; set; }
    }
}
