using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppGroup4.SQLite
{
    [Table("Cats")]
    public class Catsitter
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Boolean Housing { get; set; }
        public Boolean PracYears { get; set; }
        public DateTime birthdayDate { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public Boolean Child { get; set; }
        public Boolean Medicines { get; set; }
    }
}
