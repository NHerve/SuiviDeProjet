using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bean
{
    public class CJalon
    {
        public int jal_id;
        public string jal_libelle;
        public DateTime jal_dateLivraisonTheorique;
        public string jal_responsable;
        public DateTime jal_dateLivraisonReel;
        public int jal_projet;

        public CJalon()
        {
        }

        public CJalon(string jal_libelle, DateTime jal_dateLivraisonTheorique, string jal_responsable, DateTime jal_dateLivraisonReel, int jal_projet)
        {
            this.jal_libelle = jal_libelle;
            this.jal_dateLivraisonTheorique = jal_dateLivraisonTheorique;
            this.jal_responsable = jal_responsable;
            this.jal_dateLivraisonReel = jal_dateLivraisonReel;
            this.jal_projet = jal_projet;
        }

        public CJalon(int jal_id, string jal_libelle, DateTime jal_dateLivraisonTheorique, string jal_responsable, DateTime jal_dateLivraisonReel, int jal_projet)
        {
            this.jal_id = jal_id;
            this.jal_libelle = jal_libelle;
            this.jal_dateLivraisonTheorique = jal_dateLivraisonTheorique;
            this.jal_responsable = jal_responsable;
            this.jal_dateLivraisonReel = jal_dateLivraisonReel;
            this.jal_projet = jal_projet;
        }
    }
}
