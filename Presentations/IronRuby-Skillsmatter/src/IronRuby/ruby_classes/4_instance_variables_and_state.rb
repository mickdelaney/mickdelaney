class Person
	def initialize
		@name = ""
	end
	
	def name
		@name 
	end
	
	def name=(value)
		@name = value
		name = "john"
		@name
	end
end


p = Person.new
p.name = "michael"

puts p.name