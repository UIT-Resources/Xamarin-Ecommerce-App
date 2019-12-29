using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace CommerceApp.Views.Product

{

    public partial class DetailProduct : ContentPage

    {
        private int id;
        public DetailProduct()
        {
            InitializeComponent();
        }

        protected async void Click(object recever, EventArgs args)
        {

            bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");

        }

    }

}