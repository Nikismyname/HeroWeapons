<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateWeapon.ascx.cs" Inherits="WebFormsWithDbFirst.Pages.UserComponents.CreateWeapon" %>

<div>
    <asp:Label runat="server" Text="Weapon Name"></asp:Label>
    <asp:TextBox ID="tbWeaponName" runat="server"></asp:TextBox>
    <asp:Button ID="btnCreateWeapon" runat="server" Text="Create" />
</div>