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
    public partial class SendRequestPage : ContentPage
    {
        public int IdCatsitter { get; set; }
        public int IdUser { get; set; }
        public int IdCat { get; set; }
        public User User { get; set; }
        public SendRequestPage(int id,int idUser)
        {
            InitializeComponent();
            IdCatsitter = id;
            IdUser = idUser;
            User = App.Database.GetUser(idUser);
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            catsList.ItemsSource = App.Database.GetCatsId(IdUser);
            base.OnAppearing();
        }

        private void catsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cat selectedCat = (Cat)e.SelectedItem;
            IdCat = selectedCat.Id;
        }

        private void add_Request(object sender, EventArgs e)
        {
            Request request = new Request()
            {
                IdUser = IdUser,
                IdCatsitter = IdCatsitter,
                IdCat = IdCat,
                NameCatsitter = App.Database.GetCatsitter(IdCatsitter).Name,
                NameUser = User.Name,
                Date = transferDate.Date,
                Message = message.Text,
                PhoneNumber = Convert.ToInt64(phoneNumber.Text)
            };
            App.Database.SaveRequest(request);
            Navigation.PushAsync(new CatsittersPage(IdUser));
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}