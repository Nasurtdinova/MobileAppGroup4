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
    public partial class BecomeCatsitterPage : ContentPage
    {
        public int idUser { get; set; }
        public User User { get; set; }
        public BecomeCatsitterPage(User user)
        {
            InitializeComponent();
            idUser = user.Id;
            User = user;
            
            if (App.Database.GetCatsitterId(User.Id) != null)
            {
                Navigation.PushAsync(new WasCatsitterPage(App.Database.GetCatsitterId(User.Id)));
            }
            for (int i = 0; i <= 20; i++)
            {
                pickerYears.Items.Add(i.ToString());
            }
            this.BindingContext = this;
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

        private async void become_Clicked(object sender, EventArgs e)
        {
            Catsitter catsitter = new Catsitter()
            {
                Name = nameCattsiter.Text,
                Surname = surnameCattsiter.Text,
                birthdayDate = birthdayDate.Date,
                Address = address.Text,
                Child = child.IsToggled,
                Housing = pickerHousing.SelectedIndex.ToString(),
                Info = info.Text,
                Phone = Convert.ToInt64(phoneNumber.Text),
                PracYears = pickerYears.SelectedIndex,
                Medicines = medicines.IsToggled,
                IsAdd = true,
                IdUser = idUser
            };
            if (!String.IsNullOrEmpty(catsitter.Name))
            {
                App.Database.SaveCatsitter(catsitter);
            }
            await Navigation.PushAsync(new WasCatsitterPage(catsitter)); 
        }
    }
}