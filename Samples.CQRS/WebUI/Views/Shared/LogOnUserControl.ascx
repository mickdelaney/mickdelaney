<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    $(".login_notice").jnotice({ openClickElement: ".action1",
        closeClickElement: ".action2, .button_red",
        toggleClickElement: ".action3",
        position: "top",
        animation: "fade",
        animationSpeed: 400
    });

</script>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
         <a href="javascript:void();" class="action1">Fade login in</a>
        [ <%= Html.ActionLink("Log On", "LogOn", "Account") %> ]
<%
    }
%>