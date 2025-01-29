# eCommerce Project

## Description

This is a modern eCommerce platform built with **.NET 8** to provide a seamless online shopping experience. The platform allows users to browse and purchase products, with integrated features like **authentication and authorization**, **role management**, **external login via Google**, and **payment processing with Paymob**. It supports admin and dealer roles for managing products, categories, and orders, while providing a rich, user-friendly interface with **dark mode** for better accessibility.

The system is designed to be scalable, secure, and highly customizable to fit various business needs. Whether you're an admin managing orders or a user shopping for products, the platform ensures smooth, efficient operations. The project follows the **SOLID principles** and uses **Dependency Injection** for better code modularity and maintainability.

## Key Features

### 1. **Authentication and Authorization**
   - User registration and login functionality with **ASP.NET Core Identity**.
   - Role-based access control (Admin, Dealer, Customer).
   - Secure password management with hashing and salting.
   - **Google OAuth** for external login, making it easier for users to register and sign in with their Google accounts.

### 2. **Product and Category Management**
   - **Admins and Dealers** can create, update, and delete products and categories.
   - Manage product attributes such as price, description, stock, images, and more.
   - Categories allow for better product organization and browsing by customers.

### 3. **Order Management**
   - **Admins** can view all orders, change their states (e.g., pending, shipped, completed), and manage the overall order workflow.
   - Customers can track the status of their orders from creation to delivery.

### 4. **Payment Integration**
   - **Paymob** payment gateway integration for secure online payments.
   - Customers can choose from different payment methods supported by Paymob.
   - Complete and secure checkout process with order confirmation.

### 5. **Dark Mode Support**
   - The platform includes a toggle for **dark mode**, providing a better experience for users who prefer a darker theme, especially in low-light environments.

### 6. **Cart and Order Management**
   - **Cart**: Allows users to add, update, and remove products from their shopping cart.
   - **Order Management**: Handles order placement, status updates, and payment integration.

### 7. **SOLID Principles & Dependency Injection**
   - The project follows the **SOLID principles** to ensure clean, maintainable, and flexible code.
     - **Single Responsibility Principle**: Classes are designed to have one responsibility.
     - **Open/Closed Principle**: The system is open for extension but closed for modification.
     - **Liskov Substitution Principle**: Derived classes can be used interchangeably with their base class.
     - **Interface Segregation Principle**: Interfaces are split into smaller, more specific ones.
     - **Dependency Inversion Principle**: High-level modules do not depend on low-level modules, but both depend on abstractions.
   - **Dependency Injection (DI)** is used for better modularity and decoupling between components, making it easy to swap implementations or add new features.

### 8. **Repository and Service Classes**
   - **Repository Pattern**: The application uses the **Repository** pattern to abstract data access and allow for easier testing and data management.
   - **Service Layer**: The **Service** classes encapsulate the business logic and interact with the repository to retrieve and manage data, providing a clear separation of concerns.

## Installation
run script sql file
Colne Repo
add migration and update database
run
### Prerequisites
- **.NET 8** SDK: To develop and run the application.
- **SQL Server or another relational database**: For storing user, product, and order data.
- **Paymob API credentials**: To enable payment processing.
