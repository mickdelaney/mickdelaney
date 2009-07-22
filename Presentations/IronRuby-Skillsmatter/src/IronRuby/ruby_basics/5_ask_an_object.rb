# Respond_to?
obj = Object.new 
puts "Object 2 responds to to string: "  + obj.respond_to?(:to_s).to_s
puts "Object 2 responds to to name: "  + obj.respond_to?(:name).to_s
