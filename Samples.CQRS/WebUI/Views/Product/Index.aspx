<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    
    <table>
    <tr><td>Name</td><td>Price</td></tr>
    <% foreach(var product in Model) { %>
    <tr>
        <td><%= product.Name %></td>
        <td><%= product.Price %></td>
        <td><%= Html.ActionLink("Home", "Details", new { Id = product.Id })%> </td>
    </tr>
    <% } %>
    </table>

    <br />
    
    <%= Html.ActionLink("Create Product", "Create", "Product")%>

</asp:Content>
