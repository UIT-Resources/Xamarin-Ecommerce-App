using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CommerceApp.Models
{
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set}
        public int UserID { get; set; }
        public bool State { get; set; }
    }
}
