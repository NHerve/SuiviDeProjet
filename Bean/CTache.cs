using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bean
{
    public class CTache
    {
        public int tac_id;
        public string tac_libelle;
        public string tac_description;
        public int tac_responsable;
        public string tac_dateDebutPrevue;
        public int tac_nbJours;
        public int tac_tachePrecedente;
        public string tac_dateDebutReel;
        public int tac_statut;
        public int tac_jalon;

        public CTache()
        {
        }

        public CTache(string tac_libelle, string tac_description, int tac_responsable, string tac_dateDebutPrevue, int tac_nbJours, int tac_tachePrecedente, string tac_dateDebutReel, int tac_statut, int tac_jalon)
        {
            this.tac_libelle = tac_libelle;
            this.tac_description = tac_description;
            this.tac_responsable = tac_responsable;
            this.tac_dateDebutPrevue = tac_dateDebutPrevue;
            this.tac_nbJours = tac_nbJours;
            this.tac_tachePrecedente = tac_tachePrecedente;
            this.tac_dateDebutReel = tac_dateDebutReel;
            this.tac_statut = tac_statut;
            this.tac_jalon = tac_jalon;
        }

        public CTache(int tac_id, string tac_libelle, string tac_description, int tac_responsable, string tac_dateDebutPrevue, int tac_nbJours, int tac_tachePrecedente, string tac_dateDebutReel, int tac_statut, int tac_jalon)
        {
            this.tac_id = tac_id;
            this.tac_libelle = tac_libelle;
            this.tac_description = tac_description;
            this.tac_responsable = tac_responsable;
            this.tac_dateDebutPrevue = tac_dateDebutPrevue;
            this.tac_nbJours = tac_nbJours;
            this.tac_tachePrecedente = tac_tachePrecedente;
            this.tac_dateDebutReel = tac_dateDebutReel;
            this.tac_statut = tac_statut;
            this.tac_jalon = tac_jalon;
        }
    }
}
