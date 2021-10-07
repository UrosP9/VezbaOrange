Feature: CreateUser

Background:   
Given I am logged in with username 'Admin' and password 'admin123'

@SuccessfulUserCreate
Scenario: User is successfully created
	Given user can see dashboard page
		And user moves mouse to Admin button
		And user moves mouse to User Management button
		And user clicks on Users button
	When user can see System Users page
		And user clicks on Add button
		And user can see Add User page   
		And user selects value 'ESS' from UserRole
		And user enters value 'Cecil Bonaparte' for EmployeeName
		And user enters value for Username
		And user enters value for Password 
		And user enters value for ConfirmPassword
		And user selects value 'Enabled' from Status
		And user clicks on Save button
		And user can see System Users page
		And user enters value for Username on System Users page
		And user clicks on Search button
		And user can see created users with usernames
		And user clicks on created user
		And user can see Edit page
		And user clicks on Edit button
		And user edits value for Username 
		And user clicks on SaveEdit button
		And user can see System Users page
		And user enters value for EditedUsername on System Users page
		And user clicks on Search button
		And user can see created users with usernames 
		And user checkmarks an user
		And user clicks on Delete button
		And user can see alert message
		And user accept alert
		And user can see System Users page
		And user enters value for EditedUsername on System Users page
		And user clicks on Search button
	Then user cannnot see user 