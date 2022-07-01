Feature: ahorcadoGana
	the user enters the correct characters so he should win the game

@tag1
Scenario: User win the game
	Given I have entered hola as the word to guess
	When I entered the correct sequence of chars 'h' 'o' 'l' 'a'
	Then I won the game
