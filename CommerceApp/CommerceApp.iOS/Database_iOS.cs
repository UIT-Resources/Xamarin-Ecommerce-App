using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommerceApp.iOS;
using CommerceApp.Models;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Database_iOS))]
namespace CommerceApp.iOS
{
    public class Database_iOS : IDatabase
    {
        public Database_iOS() { }
        public SQLiteConnection DBConnect()
        {
            var filename = "ItemsSQLite.db3";
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(folder, "..",
            "Library");
            var path = Path.Combine(libraryFolder, filename);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}