Feature: languageChange
	I want to assure that language switch works

@mytag
Scenario: Change language
	Given I go to main page
	When I press ukr
	Then I shoud be redirected to ukranian version
