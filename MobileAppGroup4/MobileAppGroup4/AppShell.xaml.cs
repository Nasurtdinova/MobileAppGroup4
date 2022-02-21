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
    }
}