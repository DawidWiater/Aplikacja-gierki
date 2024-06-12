using SQLite;

namespace Aplikacja_gierki.Models
{
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Domyślna wartość
    }
}
