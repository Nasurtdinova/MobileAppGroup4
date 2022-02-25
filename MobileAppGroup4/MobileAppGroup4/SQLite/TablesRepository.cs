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
            database.CreateTable<Request>();
            database.CreateTable<AcceptedNoAcceptedRequest>();
        }
        public IEnumerable<Cat> GetCats()
        {
            return database.Table<Cat>().ToList();
        }
        public IEnumerable<Cat> GetCatsId(int id)
        {
            return database.Table<Cat>().Where(a=>a.IdUser==id);
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
        public Catsitter GetCatsitterId(int id)
        {
            return database.Table<Catsitter>().Where(a=>a.IdUser==id).FirstOrDefault();
        }
        public IEnumerable<Catsitter> GetCatsittersId(int id)
        {
            return database.Table<Catsitter>().Where(a => a.IdUser != id);
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

        public IEnumerable<Request> GetRequests()
        {
            return database.Table<Request>().ToList();
        }
        public Request GetRequest(int id)
        {
            return database.Get<Request>(id);
        }
        public Request GetRequestIdUser(int idUser,int idCatsitter)
        {
            return database.Table<Request>().Where(a=>a.IdUser==idUser && a.IdCatsitter == idCatsitter).FirstOrDefault();
        }
        public int DeleteRequest(int id)
        {
            return database.Delete<Request>(id);
        }
        public int SaveRequest(Request item)
        {
            if (item.IdRequest != 0)
            {
                database.Update(item);
                return item.IdRequest;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<Request> GetRequestCatsitter(int id)
        {
            return database.Table<Request>().Where(a => a.IdCatsitter == id);
        }

        public IEnumerable<AcceptedNoAcceptedRequest> GetAcceptedRequests()
        {
            return database.Table<AcceptedNoAcceptedRequest>().ToList();
        }
        public AcceptedNoAcceptedRequest GetAcceptedRequest(int id)
        {
            return database.Get<AcceptedNoAcceptedRequest>(id);
        }

        public int SaveAcceptedRequest(AcceptedNoAcceptedRequest item)
        {
            if (item.IdAcceptedRequest != 0)
            {
                database.Update(item);
                return item.IdRequest;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public IEnumerable<AcceptedNoAcceptedRequest> GetAcceptRequestUser(int idUser)
        {
            return database.Table<AcceptedNoAcceptedRequest>().Where(a => a.IdUser == idUser);
        }

        public int DeleteAcceptRequest(int id)
        {
            return database.Delete<AcceptedNoAcceptedRequest>(id);
        }
    }
}
