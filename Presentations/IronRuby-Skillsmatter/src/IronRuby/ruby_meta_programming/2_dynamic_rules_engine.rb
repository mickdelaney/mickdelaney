require 'mscorlib'
require File.dirname(__FILE__) + "../../../Domain.dll"
include Domain

class RulesEngine
	attr_accessor :rules
	
	# We'll call define method on the class object. 
	def build_rules
		@rules.each do |rule|
			self.class.send(:define_method, rule.name, rule.code)
		end
	end
	
	def validate_order(order)
		@rules.each do |rule|
			send(rule.name, order)
		end
	end
	
end

class Rule
	attr_accessor :name
	attr_accessor :code
end

re = RulesEngine.new
re.rules = []

r1 = Rule.new
r1.name = :rule1
r1.code = lambda {|order| puts "Order: #{order.to_s} failed: Rule 1" unless order.price > 10 }
re.rules << r1


r2 = Rule.new
r2.name = :rule2
r2.code = lambda {|order| puts "Order: #{order.to_s} failed: Rule 2" unless order.price > 5 }
re.rules << r2

re.build_rules

order = Order.new
order.price = 9

re.validate_order order

order = Order.new
order.price = 2

re.validate_order order




	