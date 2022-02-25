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
    public partial class CatsittersPage : ContentPage
    {
        public int IdUser { get; set; }
        public CatsittersPage(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
            catsittersList.ItemsSource = App.Database.GetCatsittersId(idUser);
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            catsittersList.ItemsSource = App.Database.GetCatsittersId(IdUser);
            base.OnAppearing();
        }

        private async void catsittersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Catsitter selectedProject = (Catsitter)e.SelectedItem;
            await Navigation.PushAsync(new InfoCatsitterPage(selectedProject, IdUser));
        }
    }
}