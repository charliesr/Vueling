Feature: StudentBLAdd
	I want to add an Student to a TXT file.

@mytag
Scenario: Add student to TXT
	Given The following new Student:
	| Guid | ID | Nombre | Apellidos | DNI | FechaDeNacimiento | FechaHoraRegistro |
	| {ac668043-ce2d-40de-9663-53cd670db543}  | 1 | Carlos | Sanchez Romero | 12121212A | 28-02-1988 | 12-04-2018  |

	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
