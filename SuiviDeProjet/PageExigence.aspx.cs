using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Bean;
using ServiceDA;

namespace SuiviDeProjet
{
    public partial class PageExigence : System.Web.UI.Page
    {
        DAExigence daExigence = new DAExigence();
        DAProjet daProjet = new DAProjet();
        DAJalon daJalon = new DAJalon();
        DATrigramme daTrigramme = new DATrigramme();

        protected void Page_Load(object sender, EventArgs e)
        {

            if(Request.QueryString["idProjet"] != null)
            {
                if (!Page.IsPostBack)
                {
                    Dictionary<int, string> dicoTri = daTrigramme.GetAllTrigramme();

                    inDropTrigramme.DataSource = dicoTri;
                    inDropTrigramme.DataTextField = "Value";
                    inDropTrigramme.DataValueField = "Key";
                    inDropTrigramme.DataBind();

                }

                titreProjet.InnerText = daProjet.GetProjetById(int.Parse(Request.QueryString["idProjet"])).pro_nom;

                int idProjet = int.Parse(Request.QueryString["idProjet"]);

                List<CExigence> listExigence = daExigence.GetExigenceForProjet(idProjet);
                List<int> listId = new List<int>();
                for (int i = 0; i < listExigence.Count(); i++)
                {
                    listId.Add(listExigence[i].exi_id);
                }

                repeater.DataSource = listId;
                repeater.DataBind();

                List<CJalon> listJalon = daJalon.GetJalonForProjet(idProjet);
                List<int> listIdJal = new List<int>();
                for (int i = 0; i < listJalon.Count(); i++)
                {
                    listIdJal.Add(listJalon[i].jal_id);
                }

                repeater1.DataSource = listIdJal;
                repeater1.DataBind();
            }

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string descExi = inDescExi.Value;
            string typeExi = inDropType.SelectedItem.Value;
            if (descExi != "" && Request.QueryString["idProjet"] != null)
            {
                CExigence nexExigence = new CExigence(descExi, int.Parse(typeExi), int.Parse(Request.QueryString["idProjet"]));
                daExigence.InsertExigence(nexExigence);
                MessageBox.Show("Ajout reussi");
                Response.Redirect(Request.RawUrl);

            }
            else
            {
                MessageBox.Show("Saisie invalide");
                Response.Redirect(Request.RawUrl);
            }

        }

        protected void buttonAddJalon_Click(object sender, EventArgs e)
        {
            string libeleJal = inLibeleJal.Value;
            string datePrevu = inDatePrevu.Value.ToString();

            string responsableProjet = inResponsableProjet.Value;
            string responsableValue = inDropTrigramme.SelectedItem.Text;

            if (responsableValue == "" && responsableProjet != "")
            {
                CTrigramme newTrigramme = new CTrigramme(responsableProjet);
                daTrigramme.InsertTrigramme(newTrigramme);

                if (daTrigramme.GetTrigrammeByTri(responsableValue) == null)
                {
                    CTrigramme trigramme = daTrigramme.GetTrigrammeByTri(responsableProjet);
                    if (Request.QueryString["idProjet"] != null)
                    {
                        CJalon newJalon = new CJalon(libeleJal, datePrevu, trigramme.tri_id, "", int.Parse(Request.QueryString["idProjet"]));
                        daJalon.InsertJalon(newJalon);
                        MessageBox.Show("Ajout reussi");
                        Response.Redirect(Request.RawUrl);

                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la recherche du projet");
                    }
                }
            }
            else
            {
                if (responsableValue != "")
                {
                    if (Request.QueryString["idProjet"] != null)
                    {
                        CTrigramme trigramme = daTrigramme.GetTrigrammeByTri(responsableValue);
                        CJalon newJalon = new CJalon(libeleJal, datePrevu, trigramme.tri_id, "", int.Parse(Request.QueryString["idProjet"]));
                        daJalon.InsertJalon(newJalon);
                        MessageBox.Show("Ajout reussi");
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la recherche du projet");
                    }
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