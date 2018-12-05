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
    public partial class PageExigence : System.Web.UI.Page
    {
        DAExigence daExigence = new DAExigence();
        DAProjet daProjet = new DAProjet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["idProjet"] != null)
            {
                int idProjet = int.Parse(Request.QueryString["idProjet"]);

                List<CExigence> listExigence = daExigence.GetExigenceForProjet(idProjet);
                List<int> listId = new List<int>();
                for (int i = 0; i < listExigence.Count(); i++)
                {
                    listId.Add(listExigence[i].exi_id);
                }

                repeater.DataSource = listId;
                repeater.DataBind();
            }

        }
    }
}