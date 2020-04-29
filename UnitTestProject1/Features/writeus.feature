Feature: writeus
	Test if feedback is working
	

@mytag
Scenario: Open form of writting a letter
	Given I opened https://greenforest.com.ua/ua/journal
	When I press написать нам
	Then letter form becomes visible