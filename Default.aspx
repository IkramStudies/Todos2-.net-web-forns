<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Todos2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <asp:TextBox runat ="server" ID="textbox" style="width:100px"/>
            <asp:Button runat="server" Text = "Add Task" style="width:80px; margin-left:6px" OnClick="addTask"/>
            <asp:Repeater ID="tasksList" runat="server">
                <ItemTemplate>
                    <div>
                        <%# Container.DataItem %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
    </main>

</asp:Content>
