using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppGroup4.SQLite
{
    public class Request
    {
        public int IdRequest { get; set; }
        public int IdUser { get; set; }
        public long PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
