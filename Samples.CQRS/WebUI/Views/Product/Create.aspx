<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>
    <% using (Html.BeginForm()) { %>
    <fieldset>
        <legend>Add Product</legend>
        <%= Html.EditorForModel() %>
        <button type="submit">Create</button>    
    </fieldset>
    <% } %>
</asp:Content>
