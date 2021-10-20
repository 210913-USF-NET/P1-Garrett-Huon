Store App 2.0
Overview
You have stuff. Maybe you have a lot. Maybe you have a little. Either way you'll need a way to store it. That's were the Box Shoppe web app comes in. It can provide storage options for any and all storage needs, helping people of all ages keep their homes tidy and clean.




Tech Stack:
C#
HTML
CSS
Entity Framework Core
ASP.NET MVC
PostgreSQL DB
Azure App Services
Azure DevOps
Xunit
Moq
Serilog

Functionality:
Add a new store
Sign in as user
Create new product
View a store's inventory
Replenish inventory
Add items to a shopping cart
Review shopping cart
Checkout and complete transaction
View a list of all previous orders


User Stories:
As a customer, I should be able to sign in to the application.
As a customer, I should be able to see a list of stores and choose one.
As a customer, I can view a list of available products.
As a customer, I can select multiple products and add quantity to a shopping cart.
As a customer, I can view a shopping cart and go back to shopping.
As a customer, I can edit or delete items in a shopping cart.
As a customer, I can view my order histories with details.
As an admin, I can add a new branch location.
As an admin, I can add a new product.
As an admin, I can view and select products that have no inventory yet.
As an admin, I can add inventory to a specific product.
As an admin, I can view a list of products that have inventory.
As an admin, I can replenish inventory to a specific product.


Additional Features:
Exception Handling
Input validation
Logging
Unit tests
Use Moq for testing
DB methods are tested
Data are persisted
Use PostgreSQL DB to store data
WebApp is deployed using Azure App Services
A CI/CD pipeline is established use Azure Pipelines and GitActions
Use ASP.NET MVC for the UI
DB structure is 3NF
Have an ER Diagram