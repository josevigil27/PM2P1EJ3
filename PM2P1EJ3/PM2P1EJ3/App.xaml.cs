using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM2P1EJ3.Models;
using System.IO;

namespace PM2P1EJ3
{
    public partial class App : Application
    {
        static PersonasDB bd;

        public static PersonasDB BaseDatos
        {
            get {

                if (bd == null) {
                    bd = new PersonasDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PersonasDB.db3"));
                }

                return bd; 

            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PersonasPage());
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
