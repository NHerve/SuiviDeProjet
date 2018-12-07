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
            CProjet projet = daProjet.GetProjetById(idProjet);
            CExigence exigence = daExigence.GetExigenceById(ctrlIdExigence);

            idExi.InnerText = exigence.exi_id.ToString();
            if(exigence.exi_type.ToString() == "1")
            {
                typeExi.InnerText = "Fonctionnelle";
            }
            else if(exigence.exi_type.ToString() == "2")
            {
                typeExi.InnerText = "Données";
            }else if(exigence.exi_type.ToString() == "3")
            {
                typeExi.InnerText = "Preformance";
            }else if (exigence.exi_type.ToString() == "4")
            {
                typeExi.InnerText = "Interface utilisateur";
            }else if (exigence.exi_type.ToString() == "5")
            {
                typeExi.InnerText = "Qualité";
            }else if (exigence.exi_type.ToString() == "6")
            {
                typeExi.InnerText = "Services";
            }
            DescExi.InnerText = exigence.exi_description.ToString();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            int idExi = Int32.Parse(EditButton.CommandArgument.ToString());
            Response.Redirect("PageTache.aspx?idExigence=" + idExi);
        }

        protected void DelButton_Click(object sender, EventArgs e)
        {
            int idExiDel = Int32.Parse(DelButton.CommandArgument.ToString());
            daExigence.DelExigence(idExiDel);
            Response.Redirect(Request.RawUrl);

        }
    }
}