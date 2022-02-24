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
    public partial class InfoCatsitterPage : ContentPage
    {
        public Catsitter Catsitter { get; set; }
        public int IdUser { get; set; }
        public InfoCatsitterPage(Catsitter catsit, int idUser)
        {
            InitializeComponent();
            Catsitter = catsit;
            IdUser = idUser;
            housingLabel.Text = Catsitter.Housing.ToString();
            if (Catsitter.Medicines)
            {
                isMedicine.Text = "Может";
                medPhoto.Source = "done.png";
            }
            else
            {
                isMedicine.Text = "Не может";
                medPhoto.Source = "not.png";
            }

            if (Catsitter.Child)
                childLabel.Text = "Да";
            else
                childLabel.Text = "Нет";

            this.BindingContext = this;

        }
        private async void send_Request(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SendRequestPage(Catsitter.Id,IdUser));
        }
    }
}