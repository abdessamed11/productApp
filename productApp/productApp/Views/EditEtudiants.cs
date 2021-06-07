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
    public class EditEtudiants : ContentPage
    {
        private ListView _listView;

        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _descriptionEntry;
        private Entry _priceEntry;
        private Button _button;

        Products _products = new Products();
        public string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");

        public EditEtudiants()
        {
            this.Title = "Edit etudiants";
            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Products>().OrderBy(x=>x.Name).ToList();
            _listView.ItemSelected += _listView_itemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "name";         
            stackLayout.Children.Add(_nameEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "adresse";            
            stackLayout.Children.Add(_descriptionEntry);

            _priceEntry = new Entry();
            _priceEntry.Placeholder = "Email";
            _priceEntry.Keyboard = Keyboard.Numeric;
            stackLayout.Children.Add(_priceEntry);

            Button _button = new Button();
            _button.Text = "update";
            _button.Clicked += _button_clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }

        private async void _button_clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Products products = new Products()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Name = _nameEntry.Text,
                Description= _descriptionEntry.Text,
                Price= _priceEntry.Text,
            };
            db.Update(_products);
            await Navigation.PopAsync();
        }

        private void _listView_itemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _products = (Products)e.SelectedItem;
            _idEntry.Text = _products.Id.ToString();
            _nameEntry.Text = _products.Name.ToString();
            _descriptionEntry.Text = _products.Description.ToString();
            _priceEntry.Text = _products.Price.ToString();



        }
    }
}