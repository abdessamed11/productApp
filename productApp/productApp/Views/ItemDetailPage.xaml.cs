﻿using productApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace productApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}