using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommerceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            Category[] Categories = new Category[]
            {
                new Category {Name="Quần áo", Icon="/apparel.png"},
                new Category {Name="Mỹ phẩm", Icon="/beauty.png"},
                new Category {Name="Giày dép", Icon="/shoes.png"},
                new Category {Name="Quần áo", Icon="/apparel.png"},
                new Category {Name="Mỹ phẩm", Icon="/beauty.png"},
                new Category {Name="Giày dép", Icon="/shoes.png"},
                new Category {Name="Quần áo", Icon="/apparel.png"},
                new Category {Name="Mỹ phẩm", Icon="/beauty.png"},
                new Category {Name="Giày dép", Icon="/shoes.png"},
                new Category {Name="Quần áo", Icon="/apparel.png"},
                new Category {Name="Mỹ phẩm", Icon="/beauty.png"},
                new Category {Name="Giày dép", Icon="/shoes.png"}
            };

            EventSection[] Events = new EventSection[]
            {
                new EventSection {Url="Banner.png"},
                new EventSection {Url="Banner.png"},
                new EventSection {Url="Banner.png"},
            };
            categorySection.ItemsSource = Categories;
            eventSection.ItemsSource = Events;
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