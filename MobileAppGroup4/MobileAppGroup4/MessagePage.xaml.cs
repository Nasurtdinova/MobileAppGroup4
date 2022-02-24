using MobileAppGroup4.SQLite;
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
    public partial class MessagePage : ContentPage
    {
        public Catsitter Catsitter { get; set; }
        public MessagePage(int idUser)
        {
            InitializeComponent();
            Catsitter = App.Database.GetCatsitterId(idUser);
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            messagesList.ItemsSource = App.Database.GetRequestCatsitter(Catsitter.Id);
            base.OnAppearing();
        }
    }
}