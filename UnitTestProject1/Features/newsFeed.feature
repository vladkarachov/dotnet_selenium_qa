Feature: newsFeed
	checking working of news feed within categories

@mytag
Scenario: Pages checker
	Given I opened main page of journal https://greenforest.com.ua/ua/journal
	And I have selected a '<category>'
	When I press next page
	Then next page is opened
	Examples: 
	| category   |
	| Grammar    |
	| Vocabulary |
	| Listening  |

