Feature: Calculation
  In order to calculate tax correctly
  As a administrator 
  I want to be told the percentage of a number 

  Scenario Outline: Calculate percentage
	Given I have entered <input_1> price and <input_2> into the percentage field
    When I press calculate
    Then the result should be <output> on the screen

  Examples:
    | input_1 | input_2 | output |
    | 20      | 1       | 0.2    |
    | 100     | 10      | 10     |
    | 120     | 5       | 6      |
