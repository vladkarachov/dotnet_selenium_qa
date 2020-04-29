Feature: coursesSelection
	Testing functionality of page
	where you can choose between courses

@mytag
Scenario: Change city
	Given I have go to courses selection page https://greenforest.com.ua/courses/
	When change my city to '<city>'
	Then i am redirected to my '<city>' page
	Examples: 
		| city   |
		| Киев   |
		| Днепр |

Scenario: Course entry when not authorized
	Given I have go to courses selection page https://greenforest.com.ua/courses/
	When i press "тест та запис онлайн"
	And im not authorized
	Then I redirected to login page		
