using System;
using SQLite;

namespace MVVMApp.Models
{
    [Table("Family")]
    public class Family
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Branch { get; set; }
        public DateTime LastVisit { get; set; }
        public Family()
        {
            LastVisit = DateTime.Now;
        }
    }

}

