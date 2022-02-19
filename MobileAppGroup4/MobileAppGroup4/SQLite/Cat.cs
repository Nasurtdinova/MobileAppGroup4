using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppGroup4.SQLite
{
    [Table("Cats")]
    public class Cat
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public Boolean Men { get; set; }
        public Boolean Woman { get; set; }
    }
}
