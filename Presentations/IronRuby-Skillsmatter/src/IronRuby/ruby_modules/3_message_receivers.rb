class Person
	
	def do_something
		puts "something great!!"
	end


end

p = Person.new 
p.send(:do_something)

