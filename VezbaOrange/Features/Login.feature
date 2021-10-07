Feature: Login
In order to test if login works
As a user
I want to be able to access the system after I enter my credentials

@ValidLogin
Scenario: Login to OrangeHM website with valid credentials
	Given user navigates to OrangeHM website
	When user enters value 'Admin' for username
	And user enters value 'admin123' for password
	And user clicks on login button
	Then user can see dashboard page

@InvalidLogin
Scenario: Login to OrangeHM website with invalid credentials
	Given User is on Login page
	When user enters invalid credentials for <Username> and <Password>
	And user clicks on login button
	Then user can see errormessage for <Username> and <Password>

	Examples: 
	| Username   | Password  |
	| admin      | Admin123  |
	| admin      | admin12   |
	| Adminn     | Admin123  |
	| Adminn     | admin12   |
	|            | admin123  |
	| Admin      |           |
	|            |           |