using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    class Categories : BindableBase
    {
        int categoryid { get; set; }
        string name { get; set; }
        string desciption { get; set; }
        string iconurl { get; set; }

        public int CategoryID { get { return categoryid; } set { categoryid = value; OnPropertyChanged("CategoryID"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string Desciption { get { return desciption; } set { desciption = value; OnPropertyChanged("Desciption"); } }
        public string IconUrl { get { return iconurl; } set { iconurl = value; OnPropertyChanged("IconUrl"); } }
    }
}
