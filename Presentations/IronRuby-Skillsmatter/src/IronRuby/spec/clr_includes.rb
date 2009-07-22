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
window = FrontScreen.new
window.show
peer = WindowAutomationPeer.new(window)
children = peer.get_children
buttonPeer = children[0]