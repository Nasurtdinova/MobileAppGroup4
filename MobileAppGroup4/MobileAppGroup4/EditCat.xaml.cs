using MobileAppGroup4.SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppGroup4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCat : ContentPage
    {
        public string pathName;
        public EditCat(Cat cat)
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
            if (cat.IsFriendly)
            {
                friendly.IsToggled = true;
            }
            else
            {
                noFriendly.IsToggled = true;
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
            project.IsFriendly = friendly.IsToggled;
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

        private async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Debug.WriteLine($"Путь фото {photo.FullPath}");

                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }

        private void friendly_Toggled(object sender, ToggledEventArgs e)
        {
            noFriendly.IsToggled = false;
        }

        private void noFriendly_Toggled(object sender, ToggledEventArgs e)
        {
            friendly.IsToggled = false;
        }
    }
}