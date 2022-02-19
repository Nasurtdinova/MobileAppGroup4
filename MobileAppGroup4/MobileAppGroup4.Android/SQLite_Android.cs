using System;
using MobileAppGroup4.Droid;
using System.IO;
using Xamarin.Forms;
using MobileAppGroup4.SQLite;

namespace MobileAppGroup4.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}