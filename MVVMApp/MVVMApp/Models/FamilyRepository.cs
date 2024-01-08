using System;
using System.Collections.Generic;
using SQLite;
using System;
using System.Collections.Generic;
using SQLite;

namespace MVVMApp.Models
{
    public class FamilyRepository : IDisposable
    {
        SQLiteConnection database;

        public FamilyRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Family>();
        }

        public IEnumerable<Family> GetItems()
        {
            return database.Table<Family>().ToList();
        }

        public Family GetItem(int id)
        {
            return database.Get<Family>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Family>(id);
        }

        public int SaveItem(Family obj)
        {
            return obj.Id != 0 ? database.Update(obj) : database.Insert(obj);
        }

        public void Dispose()
        {
            database?.Close();
        }
    }
}


