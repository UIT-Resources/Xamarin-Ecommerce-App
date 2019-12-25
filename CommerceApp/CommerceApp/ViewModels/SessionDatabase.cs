using System;
using System.Collections.Generic;
using System.Text;
using CommerceApp.Models;
using SQLite;
using Xamarin.Forms;

namespace CommerceApp.ViewModels
{
    public class SessionDatabase
    {
        protected static object locker = new object();
        protected SQLiteConnection database;
        public SessionDatabase()
        {
            database = DependencyService.Get<IDatabase>().DBConnect();
            database.CreateTable<Session>();
        }
        public Session GetSession()
        {
            lock (locker)
            {
                return database.Table<Session>().FirstOrDefault(x => x.ID == 1);
            }
        }
        public int SaveSession(Session session)
        {
            lock (locker)
            {
                database.DropTable<Session>();
                database.CreateTable<Session>();
                return database.Insert(session);
            }
        }
        public void DeleteAllSessions()
        {
            lock (locker)
            {
                database.DropTable<Session>();
                database.CreateTable<Session>();
            }
        }
    }
}
