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
    public class AddEtudiants : ContentPage
    {
        private Entry _nameEntry;
        private Entry _descriptionEntry;
        private Entry _priceEntry;
        private Button _saveButton;

        public string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");

        public AddEtudiants()
        {
            this.Title = "Add Company";

            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "etudiants name";
            stackLayout.Children.Add(_nameEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Email;
            _descriptionEntry.Placeholder = "products descriptions";
            stackLayout.Children.Add(_descriptionEntry);

            _priceEntry = new Entry();
            _priceEntry.Keyboard = Keyboard.Text;
            _priceEntry.Placeholder = "price products";
            stackLayout.Children.Add(_priceEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add";           
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Products>();
            var maxPk=db.Table<Products>().OrderByDescending(c=>c.Id).FirstOrDefault();

            Products products = new Products()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Name = _nameEntry.Text,
                Description = _descriptionEntry.Text,
                Price = _priceEntry.Text,
            };

            db.Insert(products);
            await DisplayAlert(null, products.Name + "Saved","Ok");
            await Navigation.PopAsync();
        }
    }
}