module Meta 
	
	def add_property(*symbols)
		symbols.each do |symbol|
			instance_eval %{def #{symbol}= (val); @#{symbol} = val; end}  
			instance_eval %{def #{symbol}; @#{symbol}; end}  
		end
	end
end


class Entity 
	include Meta
	
	def initialize
		add_property :name, :age
	end
end

e = Entity.new
e.name = "mick"
e.age = 12

puts e.name



#str = "outside"
#
#def take_a_binding(b)
#	str = "inside"
#	eval("puts str", b)
#end
#
#take_a_binding(binding)
#
#def run
#	system("dir")
#end
#
#run