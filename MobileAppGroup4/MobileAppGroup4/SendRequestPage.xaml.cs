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
        public int idUser { get; set; }
        public SendRequestPage(int id)
        {
            InitializeComponent();
            idUser = id;
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            catsList.ItemsSource = App.Database.GetCatsId(idUser);
            base.OnAppearing();
        }

        private async void catsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cat selectedProject = (Cat)e.SelectedItem;
            EditCat projectPage = new EditCat(selectedProject);
            projectPage.BindingContext = selectedProject;
            await Navigation.PushAsync(projectPage);
        }

        private void add_Request(object sender, EventArgs e)
        {

        }

        private void Cancel(object sender, EventArgs e)
        {

        }
    }
}