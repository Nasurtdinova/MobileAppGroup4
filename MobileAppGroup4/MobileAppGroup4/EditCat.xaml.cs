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
    public partial class EditCat : ContentPage
    {
        public EditCat()
        {
            InitializeComponent();
            for (int i = 0; i <= 20; i++)
            {
                pickerYear.Items.Add(i.ToString());
            }
            for (int i = 0; i <= 11; i++)
            {
                pickerMounth.Items.Add(i.ToString());
            }
            this.BindingContext = this;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var project = (Cat)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите удалить {project.Name}?", "Удалить", "Отмена"))
            {
                App.Database.DeleteCat(project.Id);
                await Navigation.PushAsync(new MyCatsPage());
            }
        }

        private async void SaveProject(object sender, EventArgs e)
        {
            var project = (Cat)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите изменить {project.Name}?", "Изменить", "Отмена"))
            {
                if (!String.IsNullOrEmpty(project.Name))
                {
                    App.Database.SaveCat(project);
                }
                await this.Navigation.PopAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private void men_Toggled(object sender, ToggledEventArgs e)
        {
            woman.IsToggled = false;
        }

        private void woman_Toggled(object sender, ToggledEventArgs e)
        {
            men.IsToggled = false;
        }
    }
}