using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppGroup4.SQLite
{
    [Table("Requests")]
    public class Request
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdRequest { get; set; }
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public int IdCatsitter { get; set; }
        public int IdCat { get; set; }
        public string NameCatsitter { get; set; }
        public long PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
