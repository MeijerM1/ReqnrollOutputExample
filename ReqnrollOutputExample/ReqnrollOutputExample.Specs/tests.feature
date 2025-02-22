Feature: Weather forecast
In order to plan my day
As a weather enthusiast
I want to know the weather forecast

    Scenario: Get the weather forecast
        When I request the weather forecast
        Then the response should be OK
