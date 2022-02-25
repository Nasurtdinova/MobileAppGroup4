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
        public int IdUser { get; set; }
        public MessagePage(int idUser)
        {
            InitializeComponent();            
            IdUser = idUser;
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            if (App.Database.GetCatsitterId(IdUser) != null)
            {
                UpdateMessage();
                base.OnAppearing();
            }
            else
            {
                DisplayAlert("Уведомление","У вас нет актуальныйх сообщений","Закрыть");
            }
        }

        public void UpdateMessage()
        {
            Catsitter = App.Database.GetCatsitterId(IdUser);
            messagesList.ItemsSource = App.Database.GetRequestCatsitter(Catsitter.Id);
            acceptMessagesList.ItemsSource = App.Database.GetAcceptRequestUser(IdUser); ;
        }

        private async void messagesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Request selectedRequest = (Request)e.SelectedItem;
            if (await DisplayAlert("Уведомление", $"Вы хотите принять запрос от {selectedRequest.NameUser}?", "Принять", "Отклонить"))
            {
                AcceptedNoAcceptedRequest accept = new AcceptedNoAcceptedRequest()
                {
                    Event = "принял",
                    IdCatsitter = IdUser,
                    IdUser = selectedRequest.IdUser,
                    IdRequest = selectedRequest.IdRequest,
                    NameCatsitter = selectedRequest.NameCatsitter,
                    NameUser = selectedRequest.NameUser
                };
                App.Database.SaveAcceptedRequest(accept);
                App.Database.DeleteRequest(selectedRequest.IdRequest);
                UpdateMessage();
            }
            else
            {
                AcceptedNoAcceptedRequest accept = new AcceptedNoAcceptedRequest()
                {
                    Event = "отклонил",
                    IdCatsitter = IdUser,
                    IdUser = selectedRequest.IdUser,
                    IdRequest = selectedRequest.IdRequest,
                    NameCatsitter = selectedRequest.NameCatsitter,
                    NameUser = selectedRequest.NameUser
                };
                App.Database.SaveAcceptedRequest(accept);
                App.Database.DeleteRequest(selectedRequest.IdRequest);
                UpdateMessage();
            }            
        }

        private void acceptMessagesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}