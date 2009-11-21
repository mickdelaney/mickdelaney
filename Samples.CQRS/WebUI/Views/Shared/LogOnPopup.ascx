<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="login_notice"> 
    <div class="wrapper"> 
   	  <div class="left"> 
        	<div class="title">CMS Login</div> 
          <div class="description">Et harum quidem rerum facilis est et  expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi  optio cumque nihil impedit quo minus id quod maxime. </div> 
        </div> 
        <div class="right"> 
          <table width="100%" border="0" cellspacing="0" cellpadding="4"> 
            <tr> 
              <td width="50%"><label for="username">Username</label> 
          <input type="text" name="username" id="username" /> 
          <label for="password">Password</label> 
          <input type="text" name="password" id="password" /></td> 
              <td width="50%" valign="bottom"><input type="button" class="button_green" name="button" id="button" value="Log in" /><input type="submit" class="button_red" name="button" id="button" value="Close" /></td> 
            </tr> 
          </table> 
        </div> 
    </div> 
</div> 
