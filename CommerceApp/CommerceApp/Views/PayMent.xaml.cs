using CommerceApp.Models;
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
    public partial class PayMent : ContentPage
    {
        public PayMent(List<ProductOfUser> productOfUsers)
        {
            InitializeComponent();
            BindingContext = new ViewModels.PayMentViewModel(productOfUsers);
        }
    }
}