using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bean;
using ServiceDA;
using System.Windows.Forms;

namespace SuiviDeProjet
{
    public partial class pageTache : System.Web.UI.Page
    {
        DAProjet daProjet = new DAProjet();
        DATrigramme daTrigramme = new DATrigramme();
        DATache daTache = new ServiceDA.DATache();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Dictionary<int, string> dicoTri = daTrigramme.GetAllTrigramme();

                inDropTrigramme.DataSource = dicoTri;
                inDropTrigramme.DataTextField = "Value";
                inDropTrigramme.DataValueField = "Key";
                inDropTrigramme.DataBind();

            }
            if (Request.QueryString["idExigence"] != null)
            {
                //List<CTache> listTache = daTache.GetTacheByExi(int.Parse(Request.QueryString["idExi"]));
                //List<int> listId = new List<int>();
                //for (int i = 0; i < listTache.Count(); i++)
                //{
                //    listId.Add(listTache[i].tac_id);
                //}

                //repeater.DataSource = listId;
                //repeater.DataBind();

            }else if (Request.QueryString["idJalon"] != null)
            {
                List<CTache> listTache = daTache.GetTacheByJalon(int.Parse(Request.QueryString["idJalon"]));
                List<int> listId = new List<int>();
                for (int i = 0; i < listTache.Count(); i++)
                {
                    listId.Add(listTache[i].tac_id);
                }

                repeater.DataSource = listId;
                repeater.DataBind();
            }

        }


        protected void addButton_Click(object sender, EventArgs e)
        {

            string nomProjet = inNomProjet.Value;
            string triProjet = inTrigrammeProjet.Value;
            string responsableProjet = inResponsableProjet.Value;
            string responsableValue = inDropTrigramme.SelectedItem.Text;

            if(responsableValue == "" && responsableProjet != "")
            {
                CTrigramme newTrigramme = new CTrigramme(responsableProjet);
                daTrigramme.InsertTrigramme(newTrigramme);

                if(daTrigramme.GetTrigrammeByTri(responsableValue) == null)
                {
                    CTrigramme trigramme = daTrigramme.GetTrigrammeByTri(responsableProjet);
                    CProjet newProjet = new CProjet(nomProjet, triProjet,trigramme.tri_id);
                    daProjet.InsertProjet(newProjet);
                    MessageBox.Show("Ajout reussi");
                    Response.Redirect(Request.RawUrl);
                }
            }
            else
            {
                if(responsableValue != "")
                {
                    CTrigramme trigramme = daTrigramme.GetTrigrammeByTri(responsableValue);
                    CProjet newProjet = new CProjet(nomProjet, triProjet, trigramme.tri_id);
                    daProjet.InsertProjet(newProjet);
                    MessageBox.Show("Ajout reussi");
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    MessageBox.Show("Responsable de projet invalide");
                    Response.Redirect(Request.RawUrl);
                }
                
            }
        }
    }
}