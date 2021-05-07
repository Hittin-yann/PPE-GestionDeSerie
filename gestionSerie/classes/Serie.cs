using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace gestionSerie.classes
{
    public class Serie
    {
        private int IdSerie;
        private string NomSerie;
        private byte[] Blob;
        private ObservableCollection<Saison> LesSaisons;

        /*private string textidSaison;
        private string textidEpisode;*/

        public int IDSerie { get => IdSerie; set => IdSerie = value; }
        public string NOMSerie { get => NomSerie; set => NomSerie = value; }
        public ObservableCollection<Saison> LESSaisons { get => LesSaisons; set => LesSaisons = value; }
        public byte[] BlobGS { get => Blob; set => Blob = value; }

        /*public string TextidSaison { get => textidSaison; set => textidSaison = value; } 
          public string TextidEpisode { get => textidEpisode; set => textidEpisode = value; }*/

        public Serie() { }
        public Serie(int id, string nom)
        {
            this.IdSerie = id;
            this.NomSerie= nom;
            this.LesSaisons = new ObservableCollection<Saison>();
        }
        public Serie(string nom)
        {
            this.NomSerie = nom;
            this.LesSaisons = new ObservableCollection<Saison>();
        }
        public void saveSerie()
        {
            string toSaveText = "";
            int increment = 0;
            foreach (Serie s in MainPage.lesSeries)
            {
                toSaveText += s.NomSerie + ";" + s.LesSaisons[s.LesSaisons.Count - 1].NumSaisonVu + ";" + s.LesSaisons[s.LesSaisons.Count - 1].NumEpisodeVu;
                foreach (Saison saison in MainPage.lesSeries[increment].LesSaisons)
                {
                    toSaveText += "|";
                    toSaveText += saison.NumSaisonVu + ";" + saison.NumEpisodeVu;
                }
                toSaveText += "\n";
                increment++;
            }
            DependencyService.Get<ISaveAndLoad>().SaveText("serie.txt", toSaveText);
        }
    }
}
