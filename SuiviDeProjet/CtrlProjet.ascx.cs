using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bean;
using ServiceDA;

namespace SuiviDeProjet
{
    public partial class CtrlProjet : System.Web.UI.UserControl
    {
        public int ctrlIdProjet;
        DAProjet daProjet = new DAProjet();
        DATrigramme daTrigramme = new DATrigramme();

        protected void Page_Load(object sender, EventArgs e)
        {

            CTrigramme trigrammeResponsable = new CTrigramme();

            CProjet projet = daProjet.GetProjetById(ctrlIdProjet);

            idProjet.InnerText = projet.pro_id.ToString();
            nomProjet.InnerText = projet.pro_nom;
            trigramme.InnerText = projet.pro_idTrigramme.ToString();
            trigrammeResponsable = daTrigramme.GetTrigrammeById(projet.pro_responsable);
            responsable.InnerText = trigrammeResponsable.tri_trigramme;
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            int idProjet = Int32.Parse(EditButton.CommandArgument.ToString());
            Response.Redirect("PageExigence.aspx?idProjet="+ idProjet);
        }

        protected void DelButton_Click(object sender, EventArgs e)
        {
            int  idProjetDel = Int32.Parse(DelButton.CommandArgument.ToString());
            daProjet.DelProjet(idProjetDel);
            Response.Redirect(Request.RawUrl);

        }
    }
}