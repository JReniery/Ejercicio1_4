using Ejercicio1_4.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_4
{
    public partial class App : Application
    {
        static GalleryDB db;
        public static GalleryDB DB
        {
            get
            {
                if (db == null)
                {
                    string FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GalleryDB.db3");
                    db = new GalleryDB(FolderPath);
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
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
