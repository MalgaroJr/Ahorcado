Feature: login
	An existing user tries to login and succeeds

@tag1
Scenario: Login for an existing user
	Given I navigated to the Ahorcado web app
	And I have entered hangman as my user name
	And I have entered 12345 as my password
	When I click on login 
	Then I should be logged in
