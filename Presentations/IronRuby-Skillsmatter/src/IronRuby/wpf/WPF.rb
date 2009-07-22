require 'mscorlib'
require 'PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
require 'PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
require 'WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'
require 'UIAutomationProvider, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'

require File.dirname(__FILE__) + "../../WPFAutomation.exe"
require File.dirname(__FILE__) + "../../UIAutomation.dll"
require File.dirname(__FILE__) + "../../Domain.dll"

include System::Windows::Automation::Peers
include System::Windows::Automation::Provider
include WPFAutomation
include Domain
include UIAutomation

app = App.new
app.run



module ActsAsWpf
	def test
		puts "Acting like Wpf"
	end
end

class MyObject 
	include ActsAsWpf
	
	def run
		test
	end
end
	
myObject = MyObject.new
myObject.run


