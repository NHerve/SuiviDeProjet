<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageExigence.aspx.cs" Inherits="SuiviDeProjet.PageExigence" EnableEventValidation="false" %>
<%@Register Src="~/CtrlExigence.ascx" TagPrefix="tag" TagName="ControlExi" %>
<%@Register Src="~/CtrlJalon.ascx" TagPrefix="tag" TagName="ControlJal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 id="titreProjet" runat="server"></h1>

    <div class="row">
        <div id="tableExi" class="col-md-6">
            <h1>Exigence</h1>
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
                    <th id="thEdit" runat="server" meta:ResourceKey="thEdit">
                        Editer
                    </th>
                    <th id="thDelete" runat="server" meta:ResourceKey="thDelete">
                        Supprimer
                    </th>
                <asp:Repeater ID="repeater" runat="server">
                    <ItemTemplate>
                        <tag:ControlExi runat="server" id="ctrlExigence" ctrlIdExigence="<%# Container.DataItem %>"></tag:ControlExi>
                    </ItemTemplate>
                </asp:Repeater>

            </table>    
        </div>
        <div id="tableJal"class="col-md-6">
            <h1>Jalons</h1>
            <table>
                <tr>
                    <th id="th1" runat="server" meta:ResourceKey="thId">
                        Id
                    </th>
                    <th id="th2" runat="server" meta:ResourceKey="thDesc">
                        Libelle
                    </th>
                    <th id="th3" runat="server" meta:ResourceKey="thType">
                        Date de livraison prevu
                    </th>
                    <th id="th4" runat="server" meta:ResourceKey="thProjet">
                        Responsable
                    </th>
                    <th id="th7" runat="server" meta:ResourceKey="thProjet">
                        Date de livraison Réel
                    </th>
                    <th id="th5" runat="server" meta:ResourceKey="thEdit">
                        Editer
                    </th>
                    <th id="th6" runat="server" meta:ResourceKey="thDelete">
                        Supprimer
                    </th>
                <asp:Repeater ID="repeater1" runat="server">
                    <ItemTemplate>
                        <tag:ControlJal runat="server" id="ctrlExigence" ctrlIdJalon="<%# Container.DataItem %>"></tag:ControlJal>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
            <br />
        </div>
    </div>

    <br />
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    <div class="row">


        <div class="col-md-6">
            <h2>Ajouter une exigence :</h2>
            <br />
            <form method="post" >
                <fieldset>
                    <div>
                        <label for="descExi">Description de l'exigence :</label>
                        <input type="text" id="inDescExi" value="" runat="server" />
                    </div>
                    <div>
                        <label for="inDropType">Type de l'exigence :</label>

                        <asp:DropDownList ID="inDropType" runat="server">
                            <asp:ListItem Value=1>Fonctionnelle</asp:ListItem>
                            <asp:ListItem Value=2>Données</asp:ListItem>
                            <asp:ListItem Value=3>Preformance</asp:ListItem>
                            <asp:ListItem Value=4>Interface utilisateur</asp:ListItem>
                            <asp:ListItem Value=5>Qualité</asp:ListItem>
                            <asp:ListItem Value=6>Services</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <div>
                        <label>&nbsp;</label>
                        <asp:Button ID="addButton" runat="server" Text="Ajouter" OnClick="addButton_Click" />
                    </div>
                    </fieldset>
                </form>
            </div>


            <div class="col-md-6">
                <h2>Ajouter un jalon :</h2>
                <br />
                <form method="post" >
                    <fieldset>
                        <div>
                            <label for="libeleExi">Libele du jalon :</label>
                            <input type="text" id="inLibeleJal" value="" runat="server" />
                        </div>
                        <div>
                        <div>
                            <label for="inDropTrigramme">Responsable existant :</label>

                            <asp:DropDownList ID="inDropTrigramme" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                            <label for="responsableProjet">Nouveau responsable :</label>
                            <input type="text" id="inResponsableProjet" value=""  maxlength="3" runat="server"/>

                        </div>
                        <div>
                            <label for="inDatePrevu">Date de livraison prévu :</label>
                            <input id="inDatePrevu" type="date" placeholder="From" runat="server"/>
                        </div>
                        <div>
                            <label>&nbsp;</label>
                            <asp:Button ID="buttonAddJalon" runat="server" Text="Ajouter" OnClick="buttonAddJalon_Click" CausesValidation="false"/>
                        </div>
                        </fieldset>
                </form>
            </div>
    </div>
</asp:Content>
