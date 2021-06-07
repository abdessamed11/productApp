using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace productApp.Views
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();

            Button button = new Button();

            button = new Button();
            button.Text = "Add Products";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Get Products";
            button.Clicked += buttun_GetProducts;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit Products";
            button.Clicked += button_EditProducts;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete Products";
            button.Clicked += Delete_products;
            stackLayout.Children.Add(button);


            Content = stackLayout;
        }

        private async void Delete_products(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteEtudiants());
        }

        private async void button_EditProducts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditEtudiants());
        }

        private async void buttun_GetProducts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetEtudiants());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEtudiants());
        }
    }
}