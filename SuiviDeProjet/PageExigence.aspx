<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageExigence.aspx.cs" Inherits="SuiviDeProjet.PageExigence" %>
<%@Register Src="~/CtrlExigence.ascx" TagPrefix="tag" TagName="Control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exigence</h1>

    <div id="tableProjet">
        <table>
            <tr>
                <th id="thId" runat="server" meta:ResourceKey="thId">
                    Id
                </th>
                <th id="thDesc" runat="server" meta:ResourceKey="thDesc">
                    Description
                </th>
                <th id="thType" runat="server" meta:ResourceKey="thType">
                    Type
                </th>
                <th id="thProjet" runat="server" meta:ResourceKey="thProjet">
                    Projet
                </th>
                <th id="thEdit" runat="server" meta:ResourceKey="thEdit">
                    Editer
                </th>
                <th id="thDelete" runat="server" meta:ResourceKey="thDelete">
                    Supprimer
                </th>
            <asp:Repeater ID="repeater" runat="server">
                <ItemTemplate>
                    <tag:Control runat="server" id="ctrlExigence" ctrlIdExigence="<%# Container.DataItem %>"></tag:Control>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <br />
    </div>
</asp:Content>
