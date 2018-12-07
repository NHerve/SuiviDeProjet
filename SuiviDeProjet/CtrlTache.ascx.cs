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
    public partial class CtrlTache : System.Web.UI.UserControl
    {
        public int ctrlIdTache;
        DAProjet daProjet = new DAProjet();
        DAExigence daExigence = new DAExigence();
        DATrigramme daTrigramme = new DATrigramme();

        protected void Page_Load(object sender, EventArgs e)
        {
            int idProjet = int.Parse(Request.QueryString["idProjet"]);
            CProjet projet = daProjet.GetProjetById(idProjet);
            CExigence exigence = daExigence.GetExigenceById(ctrlIdTache);

            idExi.InnerText = exigence.exi_id.ToString();

            DescExi.InnerText = exigence.exi_description.ToString();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //int idExi = Int32.Parse(EditButton.CommandArgument.ToString());
            //Response.Redirect("PageTache.aspx?idExigence=" + idExi);
        }

        protected void DelButton_Click(object sender, EventArgs e)
        {
            //int idExiDel = Int32.Parse(DelButton.CommandArgument.ToString());
            //daExigence.DelExigence(idExiDel);
            //Response.Redirect(Request.RawUrl);

        }
    }
}