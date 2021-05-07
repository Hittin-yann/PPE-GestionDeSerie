using gestionSerie.classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gestionSerie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            List<Serie> lesS = await App.AppelGet();
            foreach (Serie s in lesS)
            {
                gestionSerie.MainPage.lesSeries.Add(s);
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static async Task<List<Serie>> AppelGet()
        {
            RestService rsrv = new RestService();
            return await rsrv.loadAllSerie();
        }
    }
}
