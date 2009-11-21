<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">

        $(function () {
            $('.add-product').submit(function () {
                $.post("/Cart/Add", $(this).serialize(), function (data) {
                    $("#cart").html('<span class="message">Updating cart....</span>');
                    window.setTimeout(function () {
                        $.get("/Cart/Get", function (data) {
                            $("#cart").html(data);
                        });
                    }, 2000);
                });
                return false;
            });
        });
    
    
    </script>
    
    
    <h2>Products</h2>
    
     <div id="content" class="span-16">        
        <table>
            <tr><td>Name</td><td>Price</td></tr>
            <% foreach(var product in Model) { %>
            <tr>
                <td><%= product.Name %></td>
                <td><%= product.Price %></td>
                <td><%= Html.ActionLink("Home", "Details", new { Id = product.Id })%> </td>
                
                <td>
                    <form class="add-product" action="">
                        <%= Html.Hidden("Id", product.Id)%>
                        <button type="submit">Add To Cart</button>
                    </form>
                </td>                        
                
            </tr>
            <% } %>
        </table>
        
        <%= Html.ActionLink("Create Product", "Create", "Product")%>

    </div>
    <div id="right-column" class="span-6 last">
        <div id="cart" class="span-6">
            <% Html.RenderPartial("CartViewControl", ViewData["Cart"]); %>
        </div>
    </div>
</asp:Content>
