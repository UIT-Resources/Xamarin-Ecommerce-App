using Xamarin.Forms;

namespace CommerceApp.Views
{
    public class ProductPreviewCardView: ContentView
    {
        public static readonly BindableProperty IconUrlProperty = BindableProperty.Create("IconUrl", typeof(string), typeof(ProductPreviewCardView), null, BindingMode.TwoWay);
        public static readonly BindableProperty ProductNameProperty = BindableProperty.Create("ProductName", typeof(string), typeof(ProductPreviewCardView), null, BindingMode.TwoWay); 
        public static readonly BindableProperty PriceProperty = BindableProperty.Create("Price", typeof(float), typeof(ProductPreviewCardView), null, BindingMode.TwoWay);

        public string IconUrl
        {
            get { return (string)GetValue(IconUrlProperty); }
            set { SetValue(IconUrlProperty, value); }
        } 
        public string ProductName
        {
            get { return (string)GetValue(ProductNameProperty); }
            set { SetValue(ProductNameProperty, value); }
        }
        public float Price
        {
            get { return (float)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

    }
}
