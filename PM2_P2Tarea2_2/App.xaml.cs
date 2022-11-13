using PM2_P2Tarea2_2.Controller;
using System;
using System.IO;
using Xamarin.Forms;

namespace PM2_P2Tarea2_2
{
    public partial class App : Application
    {
        static BDFirmas db;
        public static BDFirmas DBaseFirma
        {
            get
            {
                if (db == null)
                {
                    String folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Firmas.db3");
                    db = new BDFirmas(folderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

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
