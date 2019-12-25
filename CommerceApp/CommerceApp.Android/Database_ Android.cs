using CommerceApp.Droid;
using CommerceApp.Models;
using SQLite;
using System.IO;
using Xamarin.Forms;
using System;

[assembly: Dependency(typeof(Database_Android))]
namespace CommerceApp.Droid
{
    public class Database_Android : IDatabase
    {
        public Database_Android() { }
        public SQLiteConnection DBConnect()
        {
            var filename = "ItemsSQLite.db3";
            string folder =
            System.Environment.GetFolderPath(System.Environment.
            SpecialFolder.Personal);
            var path = Path.Combine(folder, filename);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}