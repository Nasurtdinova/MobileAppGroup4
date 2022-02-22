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
    public partial class WasCatsitterPage : ContentPage
    {
        public Catsitter Catsitter { get; set; }
        public WasCatsitterPage(Catsitter catsit)
        {
            InitializeComponent();
            Catsitter = catsit;
            this.BindingContext = this;
            if (Catsitter.Child)
            {
                child.IsToggled = true;
            }
            else
            {
                noChild.IsToggled = true;
            }
            if (Catsitter.Medicines)
            {
                medicines.IsToggled = true;
            }
            else
            {
                noMedicines.IsToggled = true;
            }
        }

        private void child_Toggled(object sender, ToggledEventArgs e)
        {
            noChild.IsToggled = false;
        }

        private void noChild_Toggled(object sender, ToggledEventArgs e)
        {
            child.IsToggled = false;
        }

        private void noMedicines_Toggled(object sender, ToggledEventArgs e)
        {
            medicines.IsToggled = false;
        }

        private void medicines_Toggled(object sender, ToggledEventArgs e)
        {
            noMedicines.IsToggled = false;
        }

        private async void remove_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(" ", $"Вы не хотите быть котситтером?", "Да", "Отмена"))
            {
                App.Database.DeleteCatsitter(Catsitter.Id);
                await Navigation.PushAsync(new BecomeCatsitterPage(App.Database.GetUser(Catsitter.IdUser)));
            }
        }
    }
}