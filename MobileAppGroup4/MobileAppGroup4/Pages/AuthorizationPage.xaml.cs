﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppGroup4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }

        private void Authorization_Clicked(object sender, EventArgs e)
        {
            var user = App.Database.GetUsers().Where(u => u.Email == loginEntry.Text && u.Password == passwordEntry.Text).ToList().FirstOrDefault();
            if (user != null)
            {
                Application.Current.MainPage = new AppShell(user);
            }
            else
            {
                DisplayAlert("Ошибка", "Неверные данные", "ОК");
            }
            
        }
    }
}