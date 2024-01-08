using System;
using System.Collections.Generic;
using SQLite;

namespace MVVMApp.Models
{
	public class FamilyRepository
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
            if (obj.Id != 0) // Here we controll, does file exist or not, if yes - update
            {
                database.Update(obj);
                return obj.Id;
            }
            else
            {
                return database.Insert(obj);
            }
        }
    }
}

