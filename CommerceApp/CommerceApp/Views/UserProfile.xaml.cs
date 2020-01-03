using CommerceApp.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CommerceApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommerceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    [DesignTimeVisible(false)]
    public partial class UserProfile : ContentPage
    {
        public class thaydoimatkahu :BindableBase {
            public string matkhaucu { get; set; }
            public string matkhaumoi { get; set; }
            public string xacnhanmatkhau { get; set; }
            public string Matkhaucu { get { return matkhaucu; } set { matkhaucu = value; OnPropertyChanged("Matkhaucu"); } }
            public string Matkhaumoi { get { return matkhaumoi; } set { matkhaumoi = value; OnPropertyChanged("Matkhaumoi"); } }
            public string Xacnhanmatkhau { get { return xacnhanmatkhau; } set { xacnhanmatkhau = value; OnPropertyChanged("Xacnhanmatkhau"); } }
        }
        public User user { get; set; }
        public User uSer { get { return user; } set { user = value;OnPropertyChanged("uSer"); } }
        public thaydoimatkahu thaydoi = new thaydoimatkahu();
        public UserProfile()
        {

            InitializeComponent();
            uSer = new User();
            int userid = App.Database.GetSession(1).UserID;
            List<User> temp= (List<User>)App.Database.GetUsers();
            uSer = temp[0];
            
            
            if (uSer.IconUrl != "")
            {
                image.Source = uSer.IconUrl;
            }
            if (Thaydoimatkhau.IsChecked)
            {
                uSer.PassWord = thaydoi.Matkhaumoi;
            }
            uSer.Sex = "";
            frame.BindingContext = uSer;
            matkhauthaydoi.BindingContext = thaydoi;
            BindingContext = new ViewModels.UserProfileViewModel();
            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    Directory = "Sample",
                    Name = "test.jpg"
                    
                });

                uSer.IconUrl= file.Path;
                if (file == null)
                    return;

                //await DisplayAlert("File Location", file.Path, "OK");

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });


                if (file == null)
                    return;

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
            deletePhoto.Clicked += async (sender, args) =>
            {
                image.Source = "userdefault.png";
            };
            luu.Clicked += async (sender, args) =>
            {
                if (!thaydoi.Matkhaumoi.Equals(thaydoi.Xacnhanmatkhau))
                {
                    await DisplayAlert("Thông báo", "Mặt khẩu xác nhận không chính xác!", "OK");
                    return;
                }
                App.Database.SaveUser(uSer);
                await App.Current.MainPage.Navigation.PushAsync(new Profile());
            };
        }
    }
}