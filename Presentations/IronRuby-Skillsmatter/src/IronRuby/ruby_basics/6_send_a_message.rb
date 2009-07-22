# send a message
obj1 = Object.new 
puts obj1.send(:to_s) 

# use this method for safety, i.e. someone may redefine send
puts obj1.__send__(:to_s) 