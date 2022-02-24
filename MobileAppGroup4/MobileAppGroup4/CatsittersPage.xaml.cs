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
        public int idUser { get; set; }
        public CatsittersPage(int id)
        {
            InitializeComponent();
            idUser = id;
            catsittersList.ItemsSource = App.Database.GetCatsittersId(id);
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            catsittersList.ItemsSource = App.Database.GetCatsittersId(idUser);
            base.OnAppearing();
        }

        private async void catsittersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Catsitter selectedProject = (Catsitter)e.SelectedItem;
            await Navigation.PushAsync(new InfoCatsitterPage(selectedProject, idUser));
        }
    }
}