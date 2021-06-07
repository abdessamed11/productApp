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
    public class GetEtudiants : ContentPage
    {
        ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.db3");

        public GetEtudiants()
        {
            this.Title = "Listes des produits";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            _listView = new ListView();
            _listView.ItemsSource = db.Table<Products>().ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
    }
}