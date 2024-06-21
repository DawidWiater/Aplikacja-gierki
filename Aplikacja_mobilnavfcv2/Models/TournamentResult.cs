using SQLite;

namespace Aplikacja_gierki.Models
{
    public class TournamentResult
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // W�a�ciwo�� przechowuj�ca nazw� uczestnika
        public int TotalPoints { get; set; } // W�a�ciwo�� przechowuj�ca ��czn� liczb� punkt�w
        public int RacesParticipated { get; set; } // W�a�ciwo�� przechowuj�ca liczb� wy�cig�w, w kt�rych uczestnik bra� udzia�
    }
}
