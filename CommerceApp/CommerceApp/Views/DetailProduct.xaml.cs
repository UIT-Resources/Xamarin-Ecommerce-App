using System;
using System.Collections.Generic;
using CommerceApp.ViewModels;
using Xamarin.Forms;
namespace CommerceApp.Views.Product

{

    public partial class DetailProduct : ContentPage

    {
        public int id;
        public DetailProduct(int id)
        {
            this.id = id;
            InitializeComponent();
            this.BindingContext = new ProductModel(this,id);
        }

        protected async void Click(object recever, EventArgs args)
        {

            bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");

        }

    }

}