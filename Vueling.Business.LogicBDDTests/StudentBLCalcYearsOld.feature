Feature: StudentBLCalcYearsOld
	I need to calculate the years between 2 Dates

@mytag
Scenario: Calculate Years Old
	Given I have entered "04/16/2018" into the Year calculator
	And I have also entered "02/28/1988" into the calculator
	When I call CalcEdad
	Then the result should be 30 on the screen
