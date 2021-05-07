using System;
using System.Collections.Generic;
using System.Text;

namespace gestionSerie.classes
{
    public class Saison
    {
        private int id;
        //numero du dernier vu
        private int numSaisonVu;
        private int numEpisodeVu;

        public int Id { get => id; set => id = value; }
        public int NumSaisonVu { get => numSaisonVu; set => numSaisonVu = value; }
        public int NumEpisodeVu { get => numEpisodeVu; set => numEpisodeVu = value; }

        public Saison() { }
        public Saison(int id, int numSV, int numEV)
        {
            this.Id = id;
            this.numSaisonVu = numSV;
            this.numEpisodeVu = numEV;
        }
        public Saison(int numSV, int numEV)
        {
            this.numSaisonVu = numSV;
            this.NumEpisodeVu = numEV;
        }
    }
}
