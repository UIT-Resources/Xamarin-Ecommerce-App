using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CommerceApp.Models
{
    public class User : IObject
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string PassWord { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(5)]
        public string Sex { get; set; }

    }
}
