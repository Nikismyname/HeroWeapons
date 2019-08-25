<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HeroPage.aspx.cs" Inherits="WebFormsWithDbFirst.Pages.Hero.HeroPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-4" id="side-nav">
            <asp:Button runat="server" ID="CreateHeroBtn" Text="Create Hero" OnClick="CreateHeroBtn_Click" />
            <br />
            <asp:Button runat="server" ID="CreateWeaponBtn" Text="Create Weapon" OnClick="CreateWeaponBtn_Click" />
            <br />
            <asp:Button runat="server" ID="test" Text="test" OnClick="test_Click" />
        </div>

        <asp:UpdatePanel ID="HeroUpdatePanel" runat="server" UpdateMode="Always">
            <Triggers>
            </Triggers>
            <ContentTemplate>
                <div class="col-sm-8" id="user-control">
                    <asp:PlaceHolder ID="PH1" runat="server" />
                </div>

                <div class="col-sm-12" id="hero-table">
                    <asp:Repeater ID="TableRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered">
                                <tr>
                                    <th>Hero Name</th>
                                    <th>Weapon Name</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("HeroName") %></td>
                                <td><%# Eval("WeaponName") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-sm-6" id="all-hero-names">
                    <asp:Repeater ID="HeroNameRepeater" runat="server" OnItemCommand="HeroNameRepeater_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered">
                                <tr>
                                    <th>All Name</th>
                                    <th>Actions</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                                <td>
                                    <asp:LinkButton CssClass="btn btn-default" runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Text="DELETE" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-sm-6" id="all-weapons-names">
                    <asp:Repeater ID="WeaponNameRepeater" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered">
                                <tr>
                                    <th>All Weapons</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Name") %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <pre runat="server" id="TestPre" />

</asp:Content>
