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