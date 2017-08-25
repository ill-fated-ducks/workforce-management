# Bangazon - Workforce Management

## Steps to install the code
 - Clone from github using `git clone https://github.com/ill-fated-ducks/workforce-management 
 - cd into the created directory
 - open `Bangazon.sln` in Visual Studio
 - In Package Manager Console run `Update-Database`. This console can be found under View menu and Other Windows
 - `Ctrl + F5` will open a browser and run the program

## How to install any dependencies
 - Requires Visual Studio. Visit https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio for steps to install on your machine.

## Contributors
- Azim Sodikov - https://github.com/azimsodikov
- Andrew Rock - https://github.com/arock83
- Jordan Dhaenens - https://github.com/jordandhaenens
- Dilshod Nurmamatov - https://github.com/cleverbek1991
- Mitchell Blom - https://github.com/mitchellblom

# Features

1. HR should be able to see a list of employees
	- Given an HR employee wants to view employees
	- When the employee clicks on the Employees item in the navigation bar
	- Then all current employees should be listed with the following information
		- First name and last name
		- Department

2. HR should be able to add an employee
	- Given the user is viewing the list of employees
	- When the user clicks the Create New link
	- Then a form for be displayed on which the following information can be entered
		- First name
		- Last name
		- Employment start date
		- Select a department from a drop down

3. HR should be able to view employee details
	- Given a user is viewing the employee list
	- When the user clicks on an individual employee
	- Then the user should be shown a detail view of that employee, and it must contain the following information
		- First name and last name
		- Department
		- Currently assigned computer
		- Training programs they have attended, or plan on attending

4. HR should be able to edit an employee
	-	Given user is viewing an employee
	-	When user clicks on the Edit link
	-	Then user should be able to edit the last name of the employee
	-	Or change the department to which the employee is assigned
	-	Or change the computer assigned to the employee
	-	Or add/remove training programs for the employee to attend in the future

5. HR should be able to view all departments
	-	Given user wants to view departments
	-	When user clicks on the Departments section in the navigation bar
	-	Then all current departments should be listed

6. HR should be able to create a 
	-	Given user is viewing all departments
	-	When user clicks on the Create New link
	-	Then a form should be presented in which the new department name can be entered

7. HR should be able to view department details 
	-	Given user is viewing list of departments
	-	When user clicks on a department
	-	Then a view should be presented with the department name as a header
	-	And a list of employees currently assigned to that department should be listed

8. IT should be able to view, create and delete computers
	Given a user wants to view all computers
	When the user clicks on the Computers item in the navigation bar
	Then the user should see a list of all computers
	And each item should be a hyperlink that can be clicked to view the details

	Given a user is viewing all computers
	When the user clicks the Create New link
	Then the user should be presented with a form in which the following information can be entered

		- Computer manufacturer
		- Computer make
		- Purchase date

	Given user is viewing a single computer
	When the user clicks on the Delete link
	Then the user should be presented with a screen to verify that it should be deleted
	And if the user chooses Yes from that screen, the computer should be deleted only if it is has never been assigned to an employee

9. HR should be able to view a list and create training programs
	Given a user wants to view all training programs
	When the user clicks the Training Programs item in the navigation bar
	Then the user will see a list of all training programs that have not taken place yet

	Given the user is viewing all training programs
	When the user clicks the Create New link
	Then the user should be presented with a form in which the following information can be entered

		- Name
		- Description
		- Start day
		- End day
		- Maximum number of attendees

10. HR should be able to view training program details
	Given user is viewing the list of training programs
	When the user clicks on a training program
	Then the user should see all details of that training program
	And any employees that are currently attending the program

11. HR should be able to see specific data on the Home Page
	List last five Employees added to system - First, Last, Dept, clickable to details
	List all Training Programs starting within next month - Name, Day it starts, clickable to details
