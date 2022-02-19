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
        public MyCatsPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            catsList.ItemsSource = App.Database.GetCats();
            base.OnAppearing();
        }

        private async void AddCat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCat());
        }

        private async void catsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cat selectedProject = (Cat)e.SelectedItem;
            EditCat projectPage = new EditCat();
            projectPage.BindingContext = selectedProject;
            await Navigation.PushAsync(projectPage);
        }
    }
}