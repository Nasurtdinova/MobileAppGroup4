using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileAppGroup4.SQLite
{
    public class TablesRepository
    {
        SQLiteConnection database;
        public TablesRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Cat>();
        }
        public IEnumerable<Cat> GetCats()
        {
            return database.Table<Cat>().ToList();
        }
        public Cat GetCat(int id)
        {
            return database.Get<Cat>(id);
        }
        public int DeleteCat(int id)
        {
            return database.Delete<Cat>(id);
        }
        public int SaveCat(Cat item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
