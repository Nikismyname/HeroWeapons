<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateHero.ascx.cs" Inherits="WebFormsWithDbFirst.Pages.UserComponents.CreateHero" %>

<div>
    <asp:Label runat="server" Text="Hero Name"></asp:Label>
    <asp:TextBox ID="TBHeroName" runat="server"></asp:TextBox>
    <asp:Button ID="btnCreateHero" runat="server" Text="Create" onclick="btnCreateHero_Click" />
    <br/>
    <asp:Label ID="msgLabel" runat="server" />
</div>
