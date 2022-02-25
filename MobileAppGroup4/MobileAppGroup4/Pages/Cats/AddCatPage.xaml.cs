using MobileAppGroup4.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MobileAppGroup4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCat : ContentPage
    {
        public int idUser { get; set; }
        public string pathName;
        public AddCat(int id)
        {
            InitializeComponent();
            for (int i = 0;i <= 20; i++)
            {
                pickerYear.Items.Add(i.ToString());
            }
            for (int i = 0; i <= 11; i++)
            {
                pickerMounth.Items.Add(i.ToString());
            }
            idUser = id;
            this.BindingContext = this;
        }

        private async void SaveCat(object sender, EventArgs e)
        {
            Cat cat = new Cat()
            {
                Name = nameCat.Text,
                Breed = breedCat.Text,
                Men = men.IsToggled,
                Woman = woman.IsToggled,
                Year = pickerYear.SelectedIndex,
                Mounth = pickerMounth.SelectedIndex,
                Recommend = recommendCat.Text,
                PhotoPath = pathName,
                IsFriendly = friendly.IsToggled,
                IdUser = idUser
            };
            if (!String.IsNullOrEmpty(cat.Name))
            {
                App.Database.SaveCat(cat);
            }
            await this.Navigation.PopAsync();
        }

        private void UpdateList()
        {
           catPhoto.Source = pathName;
           this.BindingContext = this;
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
            UpdateList();
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
            UpdateList();
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