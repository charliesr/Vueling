Feature: StudentBLCalcYearsOld
	I need to calculate the years between 2 Dates

@mytag
Scenario: Calcualte Years Old
	Given I have entered "16/04/2018" into the Year calculator
	And I have also entered "28/02/1988" into the calculator
	When I call CalcEdad
	Then the result should be 30 on the screen
