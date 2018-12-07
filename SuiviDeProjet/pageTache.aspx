<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pageTache.aspx.cs" Inherits="SuiviDeProjet.pageTache" EnableEventValidation="false" %>
<%--<%@Register Src="~/CtrlTache.ascx" TagPrefix="tag" TagName="ControlTache" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Tache :</h1>

    <div id="tableProjet">
        <table>
            <tr>
                <th id="thid" runat="server" meta:ResourceKey="thId">
                    Id
                </th>
                <th id="thLibelle" runat="server" meta:ResourceKey="thNom">
                    Libelle
                </th>
                <th id="thDesc" runat="server" meta:ResourceKey="thTrigramme">
                    Description
                </th>
                <th id="thResp" runat="server" meta:ResourceKey="thResponsable">
                    Responsable
                </th>
                <th id="thDateDP" runat="server" meta:ResourceKey="thEdit">
                    Date de debut prévu
                </th>
                <th id="thNbJour" runat="server" meta:ResourceKey="thDelete">
                    Durée de la tache
                </th>
                <th id="thTachePrec" runat="server" meta:ResourceKey="thDelete">
                    Tache précedente
                </th>
                <th id="thDateDR" runat="server" meta:ResourceKey="thDelete">
                    Date de debut réel
                </th>
                <th id="thStatut" runat="server" meta:ResourceKey="thDelete">
                    statut
                </th>
                <th id="thEdit" runat="server" meta:ResourceKey="thEdit">
                    Editer
                </th>
                <th id="thDelete" runat="server" meta:ResourceKey="thDelete">
                    Supprimer
                </th>
            <asp:Repeater ID="repeater" runat="server">
                <ItemTemplate>
                    <%--<tag:Control runat="server" id="ctrlProjet" ctrlIdProjet="<%# Container.DataItem %>"></tag:Control>--%>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <br />
    </div>

    <div id="divForm" runat="server">
        <br />
        ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        <h2>Ajouter un  projet :</h2>
        <br />
    <form method="post" >
        <fieldset>
            <div>
                <label for="nomProjet">Nom du projet :</label>
                <input type="text" id="inNomProjet" value="" runat="server" />
            </div>
            <div>
                <label for="trigrammeProjet">Trigramme du projet :</label>
                <input type="text" id="inTrigrammeProjet" value="" maxlength="3" runat="server"/>
            </div>
            <div>
                <label for="inDropTrigramme">Responsable existant :</label>

                <asp:DropDownList ID="inDropTrigramme" runat="server">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <label for="responsableProjet">Nouveau responsable :</label>
                <input type="text" id="inResponsableProjet" value=""  maxlength="3" runat="server"/>

            </div>
            <div>
                <label>&nbsp;</label>
                <asp:Button ID="addButton" runat="server" Text="Ajouter" OnClick="addButton_Click" />
            </div>
            </fieldset>
        </form>

    </div>

</asp:Content>
