using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppGroup4.SQLite
{
    [Table("AcceptedNoAcceptedRequests")]
    public class AcceptedNoAcceptedRequest
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdAcceptedRequest { get; set; }
        public int IdRequest { get; set; }
        public int IdUser { get; set; }
        public int IdCatsitter { get; set; }
        public string NameCatsitter { get; set; }
        public string NameUser { get; set; }
        public string Event { get; set; }
    }
}
