using gestionSerie.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gestionSerie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ajouter : ContentPage
    {
        public ajouter()
        {
            InitializeComponent();
        }

        private async void BTajouter_Clicked(object sender, EventArgs e)
        {
            bool test = true;
            foreach (Serie laSerie in MainPage.lesSeries)
            {
                if ((laSerie.NOMSerie == nomSerie.Text) && (test == true))
                {
                    test = false;
                }
            }
            if (test == true)
            {
                Serie s = new Serie(nomSerie.Text);
                Saison saison = new Saison(Convert.ToInt32(numeroSaison.Text), Convert.ToInt32(numDernierEpisode.Text));
                /*s.TextidSaison = numeroSaison.Text;
                s.TextidEpisode = numDernierEpisode.Text;*/
                s.LESSaisons.Add(saison);
                MainPage.lesSeries.Add(s);
                s.saveSerie();
                await DisplayAlert("Alert", "Série ajouté", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Cette série existe déja !", "OK");
            }
            await Navigation.PopAsync();
        }
    }
}