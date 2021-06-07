using productApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace productApp.Views
{
    public class DeleteEtudiants : ContentPage
    {
        private ListView _listView;
        private Button _button;
        Products _products = new Products();
        public string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");

        

        public DeleteEtudiants()
        {
            this.Title = "Delete etudiants";
            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Products>().OrderBy(x => x.Name).ToList();
            _listView.ItemSelected += _listView_itemSelected;
            stackLayout.Children.Add(_listView);

            Button _button = new Button();
            _button.Text = "Delete";
            _button.Clicked += _button_clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private void _listView_itemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _products = (Products)e.SelectedItem;

        }

        private async void _button_clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            db.Table<Products>().Delete(X => X.Id == _products.Id);
            await Navigation.PopAsync();
        }
    }
}