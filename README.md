
# Paragon Bank

## Overview
Paragon Bank is a backend transaction management system built using the .NET stack. It provides a robust and secure banking platform for handling customer accounts, transactions, and external payment integrations. The system ensures data persistence, security, and scalability while following industry best practices for backend development.

## Features
### 1. Banking Transaction System
- **Account Management**: Create and manage bank accounts.
- **Account Details & History**: View account details, balances, and transaction history.
- **Transactions**:
  - Deposits
  - Withdrawals
  - Transfers between accounts
- **Monthly Statements**: Generate transaction statements for customers.

### 2. Data Persistence and Security
- Uses **MSSQL** for relational database storage.
- Implements **role-based access control (RBAC)** to manage permissions securely.
- Encrypts sensitive customer information to ensure data security.

### 3. External Payment Integration
- Integrated with **Paystack** to enable seamless deposits and withdrawals.

### 4. Performance Optimization
- Designed for **concurrent transactions** and high scalability.

### 5. Logging, Monitoring, and Error Handling
- **Structured logging** using **Serilog** for tracking system events.
- **Basic monitoring** for key performance metrics.
- **Robust error handling** to detect and manage failures effectively.


## Technology Stack
- **.NET Core** for backend API development.
- **CQRS (Command Query Responsibility Segregation)** pattern for efficient data handling.
- **Entity Framework Core** for database interactions.
- **MySQL** for relational data storage.
- **Serilog** for structured logging.
- **Flurl/HttpClient** for making external API calls.
- **Paystack API** for external payment processing.


### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/paragon-bank.git
   cd paragon-bank
   ```
2. Configure the database connection in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=yourdb;user=root;password=yourpassword;"
   }
   ```
3. Apply migrations:
   ```sh
   dotnet ef database update
   ```
4. Run the application:
   ```sh
   dotnet run
   ```

## API Documentation
The API documentation is available via Swagger UI:
- **Localhost**: `https://localhost:5001/swagger/index.html`
- **Staging (if deployed)**: `https://your-deployment-url/swagger/index.html`


## Contributing
1. Fork the repository.
2. Create a new branch for your feature/fix.
3. Commit and push your changes.
4. Submit a pull request for review.

