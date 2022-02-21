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
        public int Year { get; set; }
        public int Mounth { get; set; }
        public string Recommend { get; set; }
        public string PhotoPath { get; set; }
        public Boolean IsFriendly { get; set; }

        public int idUser { get; set; }
    }
}
