using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CommerceApp.Models
{
    public class Session : BindableBase, IObject
    {
        [Ignore]
        int id { get; set; }
        [Ignore]
        int userID { get; set; }
        [Ignore]
        bool state { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        public int UserID { get { return userID; } set { userID = value; OnPropertyChanged("UserID"); } }
        public bool State { get { return state; } set { state = value; OnPropertyChanged("State"); } }
    }
}
