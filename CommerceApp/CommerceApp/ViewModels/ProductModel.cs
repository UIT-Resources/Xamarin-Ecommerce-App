using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommerceApp.Models;
using Xamarin.Forms;

namespace CommerceApp.ViewModels
{
    public class ProductModel : INotifyPropertyChanged
    {
        private string name;
        public Product product;
        public ICommand Get { get; set; }
        public ProductModel()
        {
            // product = new Product(2);
            Console.WriteLine("******c***c******c****c*********");
            name = "Khoa";
            Get = new Command(GetData);
            
        }
        public string Name { get { return name; } set
            {
                name = value;
                OnPropertyChanged("Name");
            } } 
        private async void GetData()
        {
            product = new Product(2);
            await product.GetData();
            Name = product.item.full_name;

          //  name = product.item.full_name;
            Console.WriteLine("**************************** {0}",name);
        }
        // Command="{Binding UpdateTypeFlower}
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
