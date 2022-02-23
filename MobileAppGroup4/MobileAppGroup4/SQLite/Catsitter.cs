using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppGroup4.SQLite
{
    [Table("Catsitters")]
    public class Catsitter
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Housing { get; set; }
        public int PracYears { get; set; }
        public DateTime birthdayDate { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public Boolean Child { get; set; }
        public Boolean Medicines { get; set; }
        public string PathPhoto { get; set; }
        public int IdUser { get; set; }
    }
}
