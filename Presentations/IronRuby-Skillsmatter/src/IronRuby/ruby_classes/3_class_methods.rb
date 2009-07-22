class Person

	# the class constructor
	def initialize
		puts "in the constructor"
	end
	
	# class method, similar to static or shared method.
	def self.do_something
		"class method (defined inside) on " + object_id.to_s
	end
	
	# instance method	
	def do_something
		"instance method " + object_id.to_s
	end
	
end

person = Person.new
puts person.do_something
puts Person.do_something


# singleton method
def person.do_something
    "singleton method on " + object_id.to_s
end

puts person.do_something


def Person.do_something
	"redefined class method (defined outside) on " + object_id.to_s
end

puts Person.do_something