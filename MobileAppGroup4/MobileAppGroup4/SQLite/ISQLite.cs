using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppGroup4.SQLite
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
