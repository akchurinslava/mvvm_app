using System;
using SQLite;

namespace MVVMApp.Models
{
	[Table("Friends")]
	public class Friend
	{
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime Birthday { get; set; }
		public string Nationality { get; set; }
        public Friend()
        {
            Birthday = DateTime.Now;
        }
    }

}

