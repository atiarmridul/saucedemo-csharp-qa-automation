# This file contains human-readable Reqnroll scenarios.

Feature: SauceDemo purchase journey
  As a SauceDemo customer
  I want to log in, shop, and checkout
  So that I can buy products from the store

  # This scenario checks the most important business flow: a user buys a product.
  Scenario: Happy path - user completes an end-to-end purchase
    Given I am on the SauceDemo login page
    When I log in as a standard user
    And I add the "Sauce Labs Backpack" product to the cart
    And I open the shopping cart
    And I start checkout
    And I enter checkout information
    And I finish the order
    Then I should see the order confirmation message

  # This scenario checks that bad login details show an error.
  Scenario: Negative scenario - user submits invalid login input and sees an error message
    Given I am on the SauceDemo login page
    When I log in with username "wrong_user" and password "wrong_password"
    Then I should see a login error message

  # This scenario checks that going back from the cart does not remove the selected product.
  Scenario: Navigation - user can return to products without losing their cart selection
    Given I am on the SauceDemo login page
    When I log in as a standard user
    And I add the "Sauce Labs Backpack" product to the cart
    And I open the shopping cart
    And I return to the products page
    Then the cart should still contain 1 item
