Feature: ahorcadoFalla
	given 7 wrong inputs, the user should lose the game

@tag1
Scenario: User lose the game after 7 wrong inputs
	Given I have entered skere as the word to guess
	When I entered seven wrong letters one at a time
	Then I losed the game
