require 'rubygems'
require 'spec'
require 'machinist'
require 'machinist/object'
require 'sham'
require 'faker'

Sham.name  { Faker::Name.name }
Sham.email { Faker::Internet.email }
Sham.street { Faker::Address.street_name }
Sham.city { Faker::Address.city }
Sham.postcode { Faker::Address.uk_postcode }

Domain::User.blueprint do
  name
  email
end

Domain::Address.blueprint do
	street
	city
	postcode
end



