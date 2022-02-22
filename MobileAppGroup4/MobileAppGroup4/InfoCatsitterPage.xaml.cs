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
    public partial class InfoCatsitterPage : ContentPage
    {
        public Catsitter Catsitter { get; set; }
        public InfoCatsitterPage(Catsitter catsit)
        {
            InitializeComponent();
            Catsitter = catsit;
            housingLabel.Text = Catsitter.Housing.ToString();
            this.BindingContext = this;
            if (Catsitter.Child)
                childLabel.Text = "Да";
            else
                childLabel.Text = "Нет";
            
        }
    }
}