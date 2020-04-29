Feature: searchField
	Testing if site search is working 

@mytag
Scenario: Search for some text
	Given I have go to main page of journal https://greenforest.com.ua/journal
	And I have pressed search button
	And I entered '<some text>'
	When I press enter
	Then I shoud be redirected on search page

	Examples: 
		| some text |
		| null      |
		| B1        |
		
