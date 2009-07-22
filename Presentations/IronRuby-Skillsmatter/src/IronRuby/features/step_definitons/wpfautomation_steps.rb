require 'mscorlib'
require 'PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
require 'PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
require 'WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
require 'UIAutomationProvider, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'

require File.dirname(__FILE__) + "../../../../Libs/WPFAutomation.exe"
require File.dirname(__FILE__) + "../../../../Libs/UIAutomation.dll"
require File.dirname(__FILE__) + "../../../../Libs/Domain.dll"

include System::Windows::Automation::Peers
include System::Windows::Automation::Peers
include System::Windows::Automation::Provider

include WPFAutomation
include Domain
include UIAutomation

Before do
	@screen = FrontScreen.new
end

Given "I have entered $p price and &pr into the percentage field" do |p, pr|
  @priceText = @screen.find_name "priceText"
  @priceText.Text = p
  @percentageText = @screen.find_name "percentageText"
  @percentageText.Text = pr
end

When /I press calculate/ do
	@saveButton = @screen.find_name "autoMateButton"
	@autoMateButtonPeer = ButtonAutomationPeer.new autoMateButton
	@ih = InvokeHelper.new(@autoMateButtonPeer)
	@ih.invoke
end

Then /the result should be (.*)/ do |result|
  @costLabel = @screen.find_name "costLabel"
  @costLabel.content.should == result.to_s
end
