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
        public Catsitter catsitter { get; set; }
        public WasCatsitterPage(Catsitter catsit)
        {
            InitializeComponent();
            catsitter = catsit;
            this.BindingContext = this;
        }
    }
}