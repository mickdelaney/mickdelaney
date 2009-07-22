# Object ID

obj1 = Object.new 
puts "obj1's id is " + obj1.object_id.to_s

obj2 = obj1
puts "obj2's id is " + obj2.object_id.to_s
	
puts "obj1 is equal to obj2 " + (obj2 == obj1).to_s
