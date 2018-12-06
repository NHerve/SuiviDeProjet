<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlJalon.ascx.cs" Inherits="SuiviDeProjet.CtrlJalon" %>


<style>
table, tr, th, td {
    border: 1px solid black;
    padding: 20px;
}
</style>

<div class="card" style="width: 18rem;">
  <tr class="card-body">
    <td id="idJal" runat="server">idJal</td> 
    <td id="libJal" runat="server">libJal</td>
    <td id="dateLPJal" runat="server">dateLPJal</td>
    <td id="respJal" runat="server">respJal</td> 
    <td id="dateLRJal" runat="server">dateLRJal</td> 
    <td>
        <asp:Button ID="EditButton" runat="server" Text="Editer" CommandArgument='<%#ctrlIdJalon%>' OnClick="EditButton_Click" />

    </td>
    <td>
        <asp:Button ID="DelButton" runat="server" Text="Supprimer" CommandArgument='<%#ctrlIdJalon%>' OnClick="DelButton_Click" />

    </td>
  </tr>
</div>  