using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public interface IDatabase
    {
        SQLiteConnection DBConnect();
    }
}
