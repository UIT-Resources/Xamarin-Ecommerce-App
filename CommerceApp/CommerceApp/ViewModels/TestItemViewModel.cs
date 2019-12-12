using System;
using System.Collections.Generic;
using System.Text;

using CommerceApp.Models;

namespace CommerceApp.ViewModels
{
    public class TestItemViewModel
    {
        public TestItem Items { get; set; }
        public TestItemViewModel()
        {
            Items = new TestItem { Title = "Title", Detail = "Detail" };
        }
    }
}
