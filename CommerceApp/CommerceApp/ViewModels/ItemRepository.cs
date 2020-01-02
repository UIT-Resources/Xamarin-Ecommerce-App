using System;
using System.Collections.Generic;
using System.Text;
using CommerceApp.Models;

namespace CommerceApp.ViewModels
{
    public class ItemRepository
    {
        ItemDatabaseGeneric itemDatabase = null;

        public ItemRepository()
        {
            this.itemDatabase = new ItemDatabaseGeneric();
        }

        // ------------------------- Begin Session API ---------------------------
        public IEnumerable<Session> GetSessions()
        {
            return this.itemDatabase.GetObjects<Session>();
        }
        public Session GetSession(int id)
        {
            return this.itemDatabase.GetObject<Session>(id);
        }
        public int SaveSession(Session session)
        {
            this.DeleteAllSessions();
            return this.itemDatabase.SaveObject<Session>(session);
        }
        public int DeleteSession(int id)
        {
            return itemDatabase.DeleteObject<Session>(id);
        }
        public void DeleteAllSessions()
        {
            itemDatabase.DeleteAllObjects<Session>();
        }
        //--------------------------- End Session API -------------------------

        //--------------------------- Begin User API --------------------------
        public IEnumerable<User> GetUsers()
        {
            return this.itemDatabase.GetObjects<User>();
        }
        public User GetUser(int id)
        {
            return this.itemDatabase.GetObject<User>(id);
        }
        public int SaveUser(User user)
        {
            return this.itemDatabase.SaveObject<User>(user);
        }
        public int DeleteUser(int id)
        {
            return itemDatabase.DeleteObject<User>(id);
        }
        public void DeleteAllUsers()
        {
            itemDatabase.DeleteAllObjects<User>();
        }
        //--------------------------- End User API -------------------------
    }
}
