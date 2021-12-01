using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDB,db3");

        public static bool Insert<T>(T item)
        {

            using SQLiteConnection conn = new SQLiteConnection(dbFile);

            conn.CreateTable<T>();
            int nbRows = conn.Insert(item);

            return nbRows > 0;
        }

        public static bool Update<T>(T item)
        {

            using SQLiteConnection conn = new SQLiteConnection(dbFile);

            conn.CreateTable<T>();
            int nbRows = conn.Update(item);

            return nbRows > 0;
        }

        public static bool Delete<T>(T item)
        {

            using SQLiteConnection conn = new SQLiteConnection(dbFile);

            conn.CreateTable<T>();
            int nbRows = conn.Delete(item);

            return nbRows > 0;
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T> items = new List<T>();

            using SQLiteConnection conn = new SQLiteConnection(dbFile);

            conn.CreateTable<T>();
            items = conn.Table<T>().ToList();

            return items;
        }
    }
}
