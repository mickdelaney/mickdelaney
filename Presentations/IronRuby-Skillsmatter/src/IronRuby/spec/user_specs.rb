require 'spec_helper'
require File.dirname(__FILE__) + "../../Domain.dll"

describe Domain::User do
	before(:each) do
		@user = Domain::User.make
	end

	it "should have a name" do
		@user.name.should_not == nil
	end
end

