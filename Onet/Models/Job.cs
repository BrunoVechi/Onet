using Onet.Enums;
using SQLite;

namespace Onet.Models
{
    public class Job
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public EJobStatus Status { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
    }
}
