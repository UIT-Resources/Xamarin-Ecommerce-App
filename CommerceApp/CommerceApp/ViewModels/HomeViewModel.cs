using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CommerceApp.ViewModels
{
    public class HomeViewModel
    {
        Category[] Categories;
        EventSection[] Events;

        public HomeViewModel()
        {
             Categories= new Category[]
            {
                new Category {Name="Quần áo", Icon="/apparel.png"},
                new Category {Name="Mỹ phẩm", Icon="/beauty.png"},
                new Category {Name="Giày dép", Icon="/shoes.png"},
                new Category {Name="Quần áo", Icon="/apparel.png"},
            };

            Events = new EventSection[]
            {
                new EventSection {Url="Banner.png"},
                new EventSection {Url="Banner.png"},
                new EventSection {Url="Banner.png"},
            };
        }
        protected async void ButtonClicked(object sender, EventArgs e)
        {
            await ((ImageButton)sender).ScaleTo(1.2);
            await Task.Delay(100);
            await ((ImageButton)sender).ScaleTo(1);
        }
        public class Category
        {
            public string Name { get; set; }
            public string Icon { get; set; }
        }
        public class EventSection
        {
            public string Url { get; set; }
        }

    }
}
