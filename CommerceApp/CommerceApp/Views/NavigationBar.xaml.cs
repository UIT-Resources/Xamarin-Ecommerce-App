using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommerceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationBar : ContentView
    {
        public NavigationBar(string PageTitle)
        {
            InitializeComponent();
            pageTitle.Text = PageTitle;
            this.BindingContext = App.navigationBarModel;
        }
    }
}