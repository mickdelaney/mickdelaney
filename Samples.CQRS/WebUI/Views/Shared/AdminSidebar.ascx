<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div id="sidebar">
	<div class="side-col ui-sortable">
		<div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
			<div class="portlet-header ui-widget-header">Theme Switcher</div>
			<div class="portlet-content">
				<ul class="side-menu">
					<li>
						<a class="set_theme" id="default" href="javascript:void(0);" style="font-weight:bold;" title="Default Theme">Default Theme</a>
					</li>
					<li>
						<a class="set_theme" id="light_blue" href="javascript:void(0);" title="Light Blue Theme">Light Blue Theme</a>
					</li>
				</ul>
			</div>
		</div>
		<div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
			<div class="portlet-header ui-widget-header">Layout Options</div>
			<div class="portlet-content">
				<ul class="side-menu">
					<li>
						Here, you can set the page width, either fixed or fluid. You decide!<br /><br />
					</li>
					<li id="fluid_layout">
						<a href="javascript:void(0);" title="Fluid Layout">Switch to <b>Fluid Layout</b></a>
					</li>
					<li id="fixed_layout">
						<a href="javascript:void(0);" title="Fixed Layout">Switch to <b>Fixed Layout</b></a>
					</li>
				</ul>
			</div>
		</div>
		<div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
			<div class="portlet-header ui-widget-header">Navigation Menu</div>
			<div class="portlet-content">
				<div id="accordion">
					<div>
						<h3><a href="#">Dashboard</a></h3>
						<div>
							<ul class="side-menu">
								<li><a href="index.php" title="Administration">Administration</a></li>
								<li><a href="forms.php" title="Forms">Forms Example</a></li>
								<li><a href="tables.php" title="Tables">Tables example</a></li>
							</ul>
						</div>
					</div>
					<div>
						<h3><a href="#">Dummy drop down</a></h3>
						<div>
							<ul class="side-menu">
								<li><a href="index.php" title="Administration">Administration</a></li>
								<li><a href="forms.php" title="Forms">Forms Example</a></li>
								<li><a href="tables.php" title="Tables">Tables example</a></li>
							</ul>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="other-box yellow-box ui-corner-all">
			<div class="cont tooltip ui-corner-all" title="Tooltips, tooltips, tooltips !">
				<h3>Tooltip !</h3>
				<p>This is a sample tooltip !</p>
			</div>
		</div>
		<div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
			<div class="portlet-header ui-widget-header">Accordion</div>
			<div class="portlet-content">
				<div id="datepicker"></div>
			</div>
		</div>
	</div>
	<div class="clearfix"></div>
</div>
