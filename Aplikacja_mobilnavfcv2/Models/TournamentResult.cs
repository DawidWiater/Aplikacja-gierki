using SQLite;

namespace Aplikacja_gierki.Models
{
    public class TournamentResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // W³aœciwoœæ przechowuj¹ca nazwê uczestnika
        public int TotalPoints { get; set; } // W³aœciwoœæ przechowuj¹ca ³¹czn¹ liczbê punktów
        public int RacesParticipated { get; set; } // W³aœciwoœæ przechowuj¹ca liczbê wyœcigów, w których uczestnik bra³ udzia³
    }
}
