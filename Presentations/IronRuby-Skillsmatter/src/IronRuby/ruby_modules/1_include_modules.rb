module ActsAsNameable

#	self.included(base)
#		
#	end
	
	def module_method
		puts "hello from module"
	end
end

class MyObject 
	include ActsAsNameable
	
	def run
		module_method
	end
end


	
myObject = MyObject.new
myObject.run


