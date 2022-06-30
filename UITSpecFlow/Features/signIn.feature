Feature: signIn
	Testing the sign in for an user

@ToDoApp
Scenario: Sign In for an user
	Given I navigate to Ahorcado web app
	And I select sign in
	And I entered my user name
	And I entered my name
	And I entered my password
	And I confirmed my password
	When I click on the sign in button
	Then A new User is created
