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
        public BecomeCatsitterPage()
        {
            InitializeComponent();
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
    }
}