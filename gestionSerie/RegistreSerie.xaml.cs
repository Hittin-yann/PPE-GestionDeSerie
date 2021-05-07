using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gestionSerie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistreSerie : ContentPage
    {
        public RegistreSerie(string nom, string[,]lesSaisons)
        {
            InitializeComponent();

            label.Text = "Registre de la série " + nom;
            string text = "";
            for (int i = 0; i < lesSaisons.Length / 2; i++)
            {
                text += "Numéro de saison : " + lesSaisons[i, 0] + " | Numéro d'épisode : " + lesSaisons[i, 1] + "\n";
            }
            span.Text = text;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            Navigation.PopAsync();
        }
    }
}