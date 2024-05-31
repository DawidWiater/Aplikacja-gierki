using SQLite;

namespace Aplikacja_mobilnavfcv2.Models
{
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Domyślna wartość
    }
}
