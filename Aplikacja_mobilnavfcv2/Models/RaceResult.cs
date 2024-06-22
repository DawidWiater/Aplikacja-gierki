using SQLite;

namespace Aplikacja_gierki.Models
{
    public class RaceResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RaceTitle { get; set; } = string.Empty; // Domy�lna warto��
        public string ParticipantName { get; set; } = string.Empty; // Domy�lna warto��
        public int Points { get; set; }
    }
}
