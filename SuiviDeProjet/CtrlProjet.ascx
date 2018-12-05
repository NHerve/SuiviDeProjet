<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProjet.ascx.cs" Inherits="SuiviDeProjet.CtrlProjet" %>


<style>
table, tr, th, td {
    border: 1px solid black;
    padding: 20px;
}
</style>


<div class="card" style="width: 18rem;">
  <tr class="card-body">
    <td id="idProjet" runat="server">idProjet</td> 
    <td><h4 id="nomProjet" runat="server">nomProjet</h4></td>
    <td id="trigramme" runat="server">trigramme</td> 
    <td id="responsable" runat="server">NbPage</td>
    <td>
        <asp:Button ID="EditButton" runat="server" Text="Editer" CommandArgument='<%#ctrlIdProjet%>' OnClick="EditButton_Click" />

    </td>
    <td>
        <asp:Button ID="DelButton" runat="server" Text="Supprimer" CommandArgument='<%#ctrlIdProjet%>' OnClick="DelButton_Click" />

    </td>
  </tr>
</div>  