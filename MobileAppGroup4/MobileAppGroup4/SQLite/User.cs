using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileAppGroup4.SQLite
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Password { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
