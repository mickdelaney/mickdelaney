Feature: Basket
  In order to purchase products
  As a shopper 
  I want to be able to add products to a basket 

  Scenario Outline: Calculate basket total
	Given I have added <product_1> and <product_2> to my basket
    When I check the total
    Then the result should be <output> on the screen

  Examples:
    | product_1 | product_2 | output |
    | 20        | 11        | 31     |
    | 100       | 10        | 110    |
    | 120       | 5         | 125    |
