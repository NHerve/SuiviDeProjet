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
    public partial class CtrlExigence : System.Web.UI.UserControl
    {
        public int ctrlIdExigence;
        DAProjet daProjet = new DAProjet();
        DAExigence daExigence = new DAExigence();
        DATrigramme daTrigramme = new DATrigramme();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idProjet = int.Parse(Request.QueryString["idProjet"]);
            CTrigramme trigrammeResponsable = new CTrigramme();
            CProjet projet = daProjet.GetProjetById(idProjet);
            CExigence exigence = daExigence.GetExigenceById(ctrlIdExigence);

            idExi.InnerText = exigence.exi_id.ToString();
            DescExi.InnerText = exigence.exi_description.ToString();
            proExi.InnerText = projet.pro_idTrigramme.ToString();

            //FAIRE LE TRUC POUR LE TYPE D'EXI
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //int idProjet = Int32.Parse(EditButton.CommandArgument.ToString());
            //Response.Redirect("PageExigence.aspx?idProjet="+ idProjet);
        }

        protected void DelButton_Click(object sender, EventArgs e)
        {
            int idExiDel = Int32.Parse(DelButton.CommandArgument.ToString());
            daProjet.DelProjet(idExiDel);
            Response.Redirect(Request.RawUrl);

        }
    }
}