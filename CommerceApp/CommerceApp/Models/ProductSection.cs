using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CommerceApp.Models
{
    public class ProductSection
    {
        public Category category { get; set; }
        public ObservableCollection<Product> products { get; set; }

    }
}
