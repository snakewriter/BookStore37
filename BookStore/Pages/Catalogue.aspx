<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogue.aspx.cs" Inherits="Pages_Catalogue"
    MasterPageFile="~/Pages/Master.master" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <asp:Repeater ItemType="Book" SelectMethod="GetBooks" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.Title %></h3>
                    <%# Item.Author %>
                    <h4><%# Item.Price.ToString("c") %></h4>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="pagination">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                var active = i == CurrentPage ? "active" : string.Empty;
                var link = $"<a href='/Pages/Catalogue.aspx?page={i}'" +
                    $" class='{active}'>{i}</a>";
                Response.Write(link);
            }
            %>
    </div>
</asp:Content>

        
