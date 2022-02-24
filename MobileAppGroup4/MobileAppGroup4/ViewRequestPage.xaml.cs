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
    public partial class ViewRequestPage : ContentPage
    {
        public ViewRequestPage(Request request)
        {
            InitializeComponent();

        }

        private void Ignor(object sender, EventArgs e)
        {

        }

        private void Accept(object sender, EventArgs e)
        {

        }
    }
}