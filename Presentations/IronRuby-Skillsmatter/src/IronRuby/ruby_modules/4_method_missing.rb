class Person
	attr_accessor :firstname
	attr_accessor :lastname
	attr_accessor :email
	
	def method_missing(method_name, *args)
		if method_name.to_s.match(/^find_by_/)
			puts "building finder method: " + method_name.to_s
			return
		end
		super
	end
	
	
end

p = Person.new 
p.find_by_firstname
