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
        public string jal_dateLivraisonPrevue;
        public int jal_responsable;
        public string jal_dateLivraisonReel;
        public int jal_projet;

        public CJalon()
        {
        }

        public CJalon(string jal_libelle, string jal_dateLivraisonPrevue, int jal_responsable, string jal_dateLivraisonReel, int jal_projet)
        {
            this.jal_libelle = jal_libelle;
            this.jal_dateLivraisonPrevue = jal_dateLivraisonPrevue;
            this.jal_responsable = jal_responsable;
            this.jal_dateLivraisonReel = jal_dateLivraisonReel;
            this.jal_projet = jal_projet;
        }

        public CJalon(int jal_id, string jal_libelle, string jal_dateLivraisonPrevue, int jal_responsable, string jal_dateLivraisonReel, int jal_projet)
        {
            this.jal_id = jal_id;
            this.jal_libelle = jal_libelle;
            this.jal_dateLivraisonPrevue = jal_dateLivraisonPrevue;
            this.jal_responsable = jal_responsable;
            this.jal_dateLivraisonReel = jal_dateLivraisonReel;
            this.jal_projet = jal_projet;
        }
    }
}
