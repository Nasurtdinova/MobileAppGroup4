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
            database.CreateTable<User>();
            database.CreateTable<Catsitter>();
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

        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }
        public User GetUser(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteUser(int id)
        {
            return database.Delete<User>(id);
        }
        public int SaveUser(User item)
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

        public IEnumerable<Catsitter> GetCatsitters()
        {
            return database.Table<Catsitter>().ToList();
        }
        public Catsitter GetCatsitter(int id)
        {
            return database.Get<Catsitter>(id);
        }
        public int DeleteCatsitter(int id)
        {
            return database.Delete<Catsitter>(id);
        }
        public int SaveCatsitter(Catsitter item)
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
