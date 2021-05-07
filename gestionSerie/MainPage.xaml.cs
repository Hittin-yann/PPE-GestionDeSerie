using gestionSerie.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gestionSerie
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Serie> lesSeries = new ObservableCollection<Serie>();
        //string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serie.txt");
        public MainPage()
        {
            InitializeComponent();

            /*if (DependencyService.Get<ISaveAndLoad>().ExistFile(_fileName))
            {
                LoadLesSeries();
            }*/
            //DependencyService.Get<ISaveAndLoad>().DeleteText(_fileName);
            SerieView.ItemsSource = lesSeries;
            SerieView.ItemSelected += SerieView_ItemSelected;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ajouter());
        }

        public void LoadLesSeries()
        {
            lesSeries.Clear();
            String recupere = DependencyService.Get<ISaveAndLoad>().LoadText("serie.txt");
            String[] lesLignesSeries = recupere.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var item in lesLignesSeries) // LesSerie
            {
                if (item.Length > 0) // laSerie
                {

                    string[] lesSaisons = item.Split('|');
                    string[] laSerie = lesSaisons[0].Split(';');
                    Serie c = new Serie(laSerie[0]);
                    //c.TextidSaison = laSerie[1];
                    //c.TextidEpisode = laSerie[2];

                    if (lesSaisons.Length > 0)
                    {
                        for (int i = 1; i < lesSaisons.Length; i++)
                        {
                            string[] laSaison = lesSaisons[i].Split(';');
                            Saison s = new Saison(Convert.ToInt32(laSaison[0]), Convert.ToInt32(laSaison[1]));
                            c.LESSaisons.Add(s);
                        }
                    }
                    lesSeries.Add(c);
                }
            }
        }

        private async void SerieView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Serie s = (Serie)e.SelectedItem;
            bool test = false;
            int increment = 0;
            string action = "";
            ObservableCollection<Serie> laNewListSeries = lesSeries;
            foreach(Serie laSerie in lesSeries){
                if (test == false)
                {
                    if (s.NOMSerie == laSerie.NOMSerie) //&& (s.TextidSaison == laSerie.TextidSaison) && (s.TextidEpisode == laSerie.TextidEpisode)
                    {
                        test = true;
                        await DisplayAlert("Voici les information associer a cette série", "Nom : " + s.NOMSerie + " Saison : A faire Episode : A faire", "OK");
                        action = await DisplayActionSheet("Voulez-vous modifier vos information ?", "Annuler", null, "Nom", "Saison et Episode", "Registre de l'avancement");
                        //Debug.WriteLine("Action: " + action);

                    }
                    else
                    {
                        increment++;
                    }
                }
            }
            switch (action)
            {
                case "Nom":
                    string nom = await DisplayPromptAsync("Le Nom", "Quel est le nouveau nom ?");
                    laNewListSeries[increment].NOMSerie = nom;
                    lesSeries = laNewListSeries;
                    this.updateFile();
                    await Navigation.PopAsync();
                    break;

                case "Saison et Episode":
                    /*string saison = await DisplayPromptAsync("La dernier saison regarder", "A quel saison étes-vous ?");
                    laNewListSeries[increment].TextidSaison = saison;
                    string episode = await DisplayPromptAsync("Et le dernier épisode de cette saison ?", "A quel épisode étes-vous ?");
                    laNewListSeries[increment].TextidEpisode = episode;
                    Saison laNewSaison = new Saison(Convert.ToInt32(saison), Convert.ToInt32(episode));
                    laNewListSeries[increment].LesSaisons.Add(laNewSaison);
                    lesSeries = laNewListSeries;
                    this.updateFile();
                    await Navigation.PopAsync();*/
                    break;

                case "Registre de l'avancement":
                    string[,] infoSaison = new string[s.LESSaisons.Count, 2];
                    int i = 0;
                    foreach (Saison laSaison in s.LESSaisons)
                    {
                        infoSaison[i, 0] = laSaison.NumSaisonVu.ToString();
                        infoSaison[i, 1] = laSaison.NumEpisodeVu.ToString();
                        i++;
                    }
                    Navigation.InsertPageBefore(new RegistreSerie(s.NOMSerie,infoSaison), this);
                    //await Navigation.PushAsync(new RegistreSerie(s.Nom, infoSaison));
                    await Navigation.PopAsync();
                    break;
            }
            SerieView.ItemsSource = null;
        }
        public void updateFile()
        {
            Serie s = new Serie();
            s.saveSerie();
            Navigation.InsertPageBefore(new MainPage(), this);
        }
    }
}
