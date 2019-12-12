using System;
using System.Collections.Generic;
using System.Text;


namespace CommerceApp.Models
{
    public class TestItem:BindableBase
    {
        string title;
        string detail;
        public string Title
        {
            get { return title;  }
            set
            {
                if (!value.Equals(title,StringComparison.Ordinal))
                {
                    title = value;
                    OnPropertyChanged("Title");
                };
            }
        }
        public string Detail 
        {
            get 
            {
                return detail;
            }
            set
            {
                if(!value.Equals(detail, StringComparison.Ordinal))
                {
                    detail = value;
                    OnPropertyChanged("Detail");
                }
            }
        }
    }
}
