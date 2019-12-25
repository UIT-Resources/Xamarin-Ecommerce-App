using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommerceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowPopUpSigOutExample : ContentPage
    {
        public ShowPopUpSigOutExample()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopUpSigOut());
        }
    }
}