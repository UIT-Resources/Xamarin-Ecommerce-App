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
        public IEnumerable<Users> GetUsers()
        {
            return this.itemDatabase.GetObjects<Users>();
        }
        public Users GetUser(int id)
        {
            return this.itemDatabase.GetObject<Users>(id);
        }
        public int SaveUser(Users user)
        {
            return this.itemDatabase.SaveObject<Users>(user);
        }
        public int DeleteUser(int id)
        {
            return itemDatabase.DeleteObject<Users>(id);
        }
        public void DeleteAllUsers()
        {
            itemDatabase.DeleteAllObjects<Users>();
        }
        //--------------------------- End User API -------------------------
    }
}
