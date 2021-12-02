using EvernoteClone.Model;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDB,db3");
        private static string dbPath = "https://notes-app-wpf-c9d96-default-rtdb.europe-west1.firebasedatabase.app/";

        public async static Task<bool> Insert<T>(T item)
        {

            //using SQLiteConnection conn = new SQLiteConnection(dbFile);

            //conn.CreateTable<T>();
            //int nbRows = conn.Insert(item);

            //return nbRows > 0;

            var jsonBody = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var result = await client.PostAsync($"{dbPath}{item.GetType().Name.ToLower()}.json", content);

            if (result.IsSuccessStatusCode) return true;

            return false;
        }

        public static async Task<bool> Update<T>(T item) where T : HasId
        {

            //using SQLiteConnection conn = new SQLiteConnection(dbFile);

            //conn.CreateTable<T>();
            //int nbRows = conn.Update(item);

            //return nbRows > 0;

            var jsonBody = JsonConvert.SerializeObject(item);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var result = await client.PatchAsync($"{dbPath}{item.GetType().Name.ToLower()}/{item.Id}.json", content);

            if (result.IsSuccessStatusCode) return true;

            return false;
        }

        public static async Task<bool> Delete<T>(T item) where T : HasId
        {

            //using SQLiteConnection conn = new SQLiteConnection(dbFile);

            //conn.CreateTable<T>();
            //int nbRows = conn.Delete(item);

            //return nbRows > 0;

            using var client = new HttpClient();

            var result = await client.DeleteAsync($"{dbPath}{item.GetType().Name.ToLower()}/{item.Id}.json");

            if (result.IsSuccessStatusCode) return true;

            return false;
        }

        public static async Task<List<T>> Read<T>() where T : HasId
        {
            //List<T> items = new List<T>();

            //using SQLiteConnection conn = new SQLiteConnection(dbFile);

            //conn.CreateTable<T>();
            //items = conn.Table<T>().ToList();

            //return items;

            using var client = new HttpClient();

            var result = await client.GetAsync($"{dbPath}{typeof(T).Name.ToLower()}.json");
            var jsonResult = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var objects = JsonConvert.DeserializeObject<Dictionary<string,T>>(jsonResult);

                if (objects != null)
                {
                    List<T> list = new List<T>();
                    foreach (var obj in objects)
                    {
                        obj.Value.Id = obj.Key;
                        list.Add(obj.Value);
                    }

                    return list;
                }
                else
                {
                    return new List<T>();
                }
 
            }
            else
            {
                return null;
            }
        }
    }
}
