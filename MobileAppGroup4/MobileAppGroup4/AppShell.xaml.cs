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
    public partial class AppShell : Shell
    {
        public User Iuser { get; set; }
        public AppShell(User user)
        {
            InitializeComponent();
            Iuser = user;
            this.BindingContext = this;
        }

        private async void myCats_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyCatsPage(Iuser.Id));
        }
        private void becomeCatsitter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BecomeCatsitterPage(Iuser));           
        }

        private void catsitters_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CatsittersPage(Iuser.Id));
        }
    }
}