<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Todos2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <asp:TextBox runat ="server" ID="textbox" style="width:100px; height:30px"/>
            <asp:Button runat="server" Text = "Add Task" style="width:80px; margin-left:6px; margin-bottom:12px" OnClick="addTask"/>
            <asp:Repeater ID="tasksList" runat="server">
                <ItemTemplate>
                    <div>
                        <asp:Label ID="tasktext" runat="server" Text="<%#Container.DataItem %>" />
                        <asp:Button  runat="server" Text="edit" ID="editbtn" CommandArgument="<%#Container.ItemIndex %>" OnCommand="EditTask"/>
                        <asp:Button  runat="server" ID="deleteBtn" Text="delete" OnCommand="DeleteTask" CommandArgument="<%#Container.ItemIndex %>"/>
                        <asp:TextBox runat="server" ID="editText" Visible="false"/>
                        <asp:Button runat="server" ID="saveBtn" CommandArgument="<%#Container.ItemIndex %>" OnCommand="SaveTask" Text="save" Visible="false"/>
                        <asp:Button runat="server" ID="cancelBtn" CommandArgument="<%#Container.ItemIndex %>" OnCommand="CancelEdit" Text="cancel" Visible="false"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>
    </main>

</asp:Content>
