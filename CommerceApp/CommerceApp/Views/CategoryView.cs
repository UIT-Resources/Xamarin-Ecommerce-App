using Xamarin.Forms;

namespace CommerceApp.Views
{
    class CategoryView : ContentView
    {
        public static readonly BindableProperty CategoryTitleProperty = BindableProperty.Create("CategoryTitle", typeof(string), typeof(CategoryView), null);
        public static readonly BindableProperty SectionHeightProperty = BindableProperty.Create("SectionHeight", typeof(int), typeof(CategoryView), null);
        public string CategoryTitle
        {
            get { return (string)GetValue(CategoryTitleProperty); }
            set { SetValue(CategoryTitleProperty, value); }
        } 
        public int SectionHeight
        {
            get { return (int)GetValue(SectionHeightProperty); }
            set { SetValue(SectionHeightProperty, value); }
        }
        
    }
}
