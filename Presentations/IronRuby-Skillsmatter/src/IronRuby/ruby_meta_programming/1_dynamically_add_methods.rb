module AttributeInitializer
	def attr_init(name, klass)
		eval "define_method(name) { @#{name} ||= klass.new }"
	end
end

class Statement
	extend AttributeInitializer
	
	attr_init :charges, Array
	
	def get_charges
		@charges
	end
	
	def set_charges(price)
		@charges = price
	end
	
end

scan = Statement.new
scan.set_charges 20
puts scan.get_charges