﻿using MobileAppGroup4.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppGroup4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCat : ContentPage
    {
        public AddCat()
        {
            InitializeComponent();
            for (int i = 0;i<=20; i++)
            {
                pickerYear.Items.Add(i.ToString());
            }
            for (int i = 0; i <= 11; i++)
            {
                pickerMounth.Items.Add(i.ToString());
            }
            this.BindingContext = this;
        }

        private async void SaveCat(object sender, EventArgs e)
        {
            Cat cat = new Cat()
            {
                Name = nameCat.Text,
                Breed = breedCat.Text,
                Men = men.IsToggled,
                Woman = woman.IsToggled,
                Year = pickerYear.SelectedIndex,
                Mounth = pickerMounth.SelectedIndex
            };
            if (!String.IsNullOrEmpty(cat.Name))
            {
                App.Database.SaveCat(cat);
            }
            await this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void men_Toggled(object sender, ToggledEventArgs e)
        {
            woman.IsToggled = false;
        }

        private void woman_Toggled(object sender, ToggledEventArgs e)
        {
            men.IsToggled = false;
        }
    }
}