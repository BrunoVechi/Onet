using SQLite;

namespace Mobile.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public byte[]? Photo { get; set; }
        public int Reset { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
