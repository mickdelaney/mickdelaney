class Person
	attr_accessor :firstname
	attr_accessor :lastname
	attr_accessor :email
end


class Pilot < Person
	attr_accessor :plane
	
	def description
		"#{firstname} #{lastname} flying #{plane}"
	end
end	


p = Pilot.new
p.firstname = "john"
p.lastname = "smith"
p.plane = "ryanair no 1"


puts p.description	