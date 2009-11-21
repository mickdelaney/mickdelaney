<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Cart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Cart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">

        $(function () {

//            $.ajaxPollSettings.pollingType = "timed";
//            $.ajaxPollSettings.interval = 250;
//            $.ajaxPollSettings.maxInterval = 5000;
//            $.ajaxPollSettings.durationUntilMaxInterval = 6000;

            $('#refresh-button').click(function () {
                $("#cart").html('<span>Updating....</span>');
                $.get("/Cart/Get", function (data) {
                    $("#cart").html(data);
                });
            });
           
//            $.ajaxPoll({
//                url: "/Cart/Get",
//                successCondition: function (result) {
//                    return result != null;
//                },
//                success: function (data) {
//                    $("#cart").html(data);
//                }
//            });
        });
    </script>
    <div id="content" class="span-16">        
        <h2>Index</h2>
        <button id="refresh-button" class="refresh">Refresh</button>
    </div>
    
    <div id="right-column" class="span-6 last">
        <div id="cart" class="span-6">
            <% Html.RenderPartial("CartViewControl"); %>
        </div>
    </div>
</asp:Content>
