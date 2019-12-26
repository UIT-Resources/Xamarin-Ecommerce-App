using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CommerceApp.Models
{
    public class Users : BindableBase, IObject
    {
        [Ignore]
        int id { get; set; }
        [Ignore]
        string username { get; set; }
        [Ignore]
        string password { get; set; }
        [Ignore]
        DateTime birthday { get; set; }
        [Ignore]
        int phonenumber { get; set; }
        [Ignore]
        string email { get; set; }
        [Ignore]
        string sex { get; set; }
        [Ignore]
        string iconurl { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get { return id; } set { id = value; OnPropertyChanged("ID"); } }
        [MaxLength(50)]
        public string UserName { get { return username; } set { username = value; OnPropertyChanged("UserName"); } }
        [MaxLength(50)]
        public string PassWord { get { return password; } set { password = value; OnPropertyChanged("PassWord"); } }
        public DateTime BirthDay { get { return birthday; } set { birthday = value; OnPropertyChanged("BirthDay"); } }
        public int PhoneNumber { get { return phonenumber; } set { phonenumber = value; OnPropertyChanged("PhoneNumber"); } }
        [MaxLength(50)]
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        [MaxLength(5)]
        public string Sex { get { return sex; } set { sex = value; OnPropertyChanged("Sex"); } }
        public string IconUrl { get { return iconurl; } set { iconurl = value; OnPropertyChanged("IconUrl"); } }
    }
}
