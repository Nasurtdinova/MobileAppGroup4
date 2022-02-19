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
    public partial class AddCat : ContentPage
    {
        public AddCat()
        {
            InitializeComponent();
        }

        private async void SaveCat(object sender, EventArgs e)
        {
            Cat cat = new Cat()
            {
                Name = nameCat.Text,
                Breed = breedCat.Text
            };
            if (!String.IsNullOrEmpty(cat.Name))
            {
                App.Database.SaveProject(cat);
            }
            await this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}