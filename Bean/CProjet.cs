using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bean
{
    public class CProjet
    {
        public int pro_id;
        public string pro_nom;
        public string pro_idTrigramme;
        public int pro_responsable;

        public CProjet()
        {
        }

        public CProjet(string pro_nom, string pro_idTrigramme, int pro_responsable)
        {
            this.pro_nom = pro_nom;
            this.pro_idTrigramme = pro_idTrigramme;
            this.pro_responsable = pro_responsable;
        }

        public CProjet(int pro_id, string pro_nom, string pro_idTrigramme, int pro_responsable)
        {
            this.pro_id = pro_id;
            this.pro_nom = pro_nom;
            this.pro_idTrigramme = pro_idTrigramme;
            this.pro_responsable = pro_responsable;
        }
    }
}
