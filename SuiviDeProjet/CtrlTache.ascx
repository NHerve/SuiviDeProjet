<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlTache.ascx.cs" Inherits="SuiviDeProjet.CtrlTache" %>


<style>
table, tr, th, td {
    border: 1px solid black;
    padding: 20px;
}
</style>

<div class="card" style="width: 18rem;">
  <tr class="card-body">
    <td id="idExi" runat="server">idExi</td> 
    <td id="DescExi" runat="server">descExi</td>
    <td id="typeExi" runat="server">typeExi</td>
    <td>
        <asp:Button ID="EditButton" runat="server" Text="Editer" CommandArgument='<%#ctrlIdTache%>' OnClick="EditButton_Click" />

    </td>
    <td>
        <asp:Button ID="DelButton" runat="server" Text="Supprimer" CommandArgument='<%#ctrlIdTache%>' OnClick="DelButton_Click" />

    </td>
  </tr>
</div>  