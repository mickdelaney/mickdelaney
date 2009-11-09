<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<OrderCommand>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
    
        <% using (Html.BeginForm()) { %>
            <fieldset>
                <legend>Order Details</legend>
                <%= Html.EditorForModel() %>            
                
                <button type="Submit">Place Order</button>
                
            </fieldset>
        <% } %>

</asp:Content>
