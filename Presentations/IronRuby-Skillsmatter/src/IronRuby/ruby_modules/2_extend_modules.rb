module S3

	def iniialize_s3(account_name)
		@connection = account_name	
	end
	
	def save_to_s3(data)
		if @connection
			"saving to s3: " + data.to_s
		end
	end
	
end

module Twitter
		
	def post_to_twitter(message)
		puts "Twitter: " + message 
	end
	
end

p = Object.new 
p.extend(S3, Twitter)

p.iniialize_s3("mick")
result = p.save_to_s3("test")
p.post_to_twitter(result)



