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
    public partial class MyCatsPage : ContentPage
    {
        public int idUser { get; set; }
        public MyCatsPage(int id)
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

        private async void AddCat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCat(idUser));
        }

        private async void catsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cat selectedCat = (Cat)e.SelectedItem;
            EditCat editCatPage = new EditCat(selectedCat);
            editCatPage.BindingContext = selectedCat;
            await Navigation.PushAsync(editCatPage);
        }
    }
}