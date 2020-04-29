Feature: siteMainPage
	In order to test site main page
	We check if features is working

@mytag
Scenario: Clicking on elements on site menu
	Given I have go to the main page https://greenforest.com.ua/journal
	When I press grammar
	Then I should see grammar web page

Scenario: Clicking on Read more on main page
	Given I have go to the main page https://greenforest.com.ua/journal
	When I press Читать далее
	Then I should get new articles
