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
    public partial class CtrlJalon : System.Web.UI.UserControl
    {
        public int ctrlIdJalon;
        DAProjet daProjet = new DAProjet();
        DAExigence daExigence = new DAExigence();
        DATrigramme daTrigramme = new DATrigramme();
        DAJalon daJalon = new DAJalon();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idProjet = int.Parse(Request.QueryString["idProjet"]);
            CProjet projet = daProjet.GetProjetById(idProjet);
            CJalon jalon = daJalon.GetJalonById(ctrlIdJalon);
            CTrigramme trigrammeResponsable = daTrigramme.GetTrigrammeById(jalon.jal_responsable);

            idJal.InnerText = jalon.jal_id.ToString();
            libJal.InnerText = jalon.jal_libelle.ToString();
            string[] date = jalon.jal_dateLivraisonPrevue.ToString().Split(' ');
            dateLPJal.InnerText = date[0];
            respJal.InnerText = trigrammeResponsable.tri_trigramme.ToString();

            if(jalon.jal_dateLivraisonReel.ToString() == "")
            {
                dateLRJal.InnerText = "Date réel non déterminer";
            }
            else
            {
                dateLRJal.InnerText = jalon.jal_dateLivraisonReel.ToString();
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //int idProjet = Int32.Parse(EditButton.CommandArgument.ToString());
            //Response.Redirect("PageExigence.aspx?idProjet="+ idProjet);
        }

        protected void DelButton_Click(object sender, EventArgs e)
        {
            int idJalDel = Int32.Parse(DelButton.CommandArgument.ToString());
            daJalon.DelJalon(idJalDel);
            Response.Redirect(Request.RawUrl);

        }
    }
}