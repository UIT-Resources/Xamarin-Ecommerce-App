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
    public partial class Success : ContentPage
    {
        AddressOfUser addressOfUser;

        public Success()
        {
            InitializeComponent();
        }
    }
}