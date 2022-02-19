
using MobileAppGroup4.Services;
using MobileAppGroup4.SQLite;
using MobileAppGroup4.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias = "Font")]
namespace MobileAppGroup4
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "cats.db";
        public static TablesRepository database;
        public static TablesRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new TablesRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Main());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
