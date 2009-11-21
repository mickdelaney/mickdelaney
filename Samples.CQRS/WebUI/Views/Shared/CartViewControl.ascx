<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<Cart>" %>
<div id="cart">
    
    <% if (Model.Items.Count > 0) { %>
    <ul>
    <% foreach (var item in Model.Items)
       { %>
        <li>
            <%= item.Product.Name%> x <%= item.Quantity %> @ <%= item.Value %>
        </li>
    <% } %>
    </ul>
    <% } %>
    <% else { %>
        No items in cart.
    <% } %>
</div>
