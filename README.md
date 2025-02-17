# Expense Tracker CLI

![image](https://github.com/user-attachments/assets/98e66d98-3894-4f15-86c5-990851ad8c58)


A simple command-line application to manage your personal finances. This application allows users to add, delete, and view their expenses efficiently.

## Features
- Add an expense with a description and amount.
- Update an existing expense.
- Delete an expense.
- View all recorded expenses.
- View a summary of all expenses.
- View a summary of expenses for a specific month (current year).
## Installation
To install and run the Expense Tracker CLI, follow these steps:


## Usage
### Add an Expense
```sh
$ expense-tracker add --description "Lunch" --amount 20
# Expense added successfully (ID: 1)
```

### List Expenses
```sh
$ expense-tracker list
# ID   Date       Description  Amount
# 1    2024-08-06  Lunch       $20
```

### View Expense Summary
```sh
$ expense-tracker summary
# Total expenses: $20
```

### Delete an Expense
```sh
$ expense-tracker delete --id 1
# Expense deleted successfully
```

### View Monthly Summary
```sh
$ expense-tracker summary --month 8
# Total expenses for August: $20
```

## Implementation Details
- The application is built using C#.
- Expenses are stored in a JSON file.
- Command-line arguments are parsed using `System.CommandLine`.
- Error handling is implemented for invalid inputs, non-existent expense IDs, and negative amounts.
- Functions are modularized to ensure maintainability and ease of testing.


