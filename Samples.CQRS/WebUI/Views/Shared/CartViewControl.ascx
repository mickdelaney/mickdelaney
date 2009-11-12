<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<Cart>" %>
<div id="cart">
    <ul>
    <% foreach (var item in Model.Items) { %>
        <li><%= item.Product.Name %></li>
    <% } %>
    </ul>
</div>
