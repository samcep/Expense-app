using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CommandLine;
using Expense_Tracker.Data;
using Expense_Tracker.Entity;
namespace Expense_Tracker.Commands
{
    internal static class CommandHandle
    {
        static public RootCommand GenerateCommand()
        {
            RootCommand RootCommand = new RootCommand("expense-tracker");

            var addDescriptionOption = new Option<string>("--description", "sets expense's descrption") { IsRequired = true};
            var addAmountOption = new Option<int>("--amount", "sets expense's descrption") { IsRequired = true };
            Command expenseAddCommand = new Command("add" , "Adds a new expense");
            expenseAddCommand.AddOption(addAmountOption);
            expenseAddCommand.AddOption(addDescriptionOption);
            RootCommand.Add(expenseAddCommand);
            Command expeseDeleteCommand = new Command("delete", "Delete a specific expense");
            var deleteExpenseOption = new Option<string>("--id", "Expense's Id") { IsRequired = true };
            expeseDeleteCommand.AddOption(deleteExpenseOption);
            RootCommand.Add(expeseDeleteCommand);
            Command expeseListsCommand = new Command("list", "Lists all the expenses");
            RootCommand.Add(expeseListsCommand);
            Command expeseSummaryCommand = new Command("summary", "gets a total of all expenses");
            var summaryByMonthOption = new Option<int>("--month", "gets total of all expenses by month");
            expeseSummaryCommand.AddOption(summaryByMonthOption);
            RootCommand.Add(expeseSummaryCommand);
            expenseAddCommand.SetHandler((description, amount) =>
            {
                var expense = new Expense()
                {
                    Id =  Guid.NewGuid(),
                    Description = description,
                    Amount = amount
                };
                ExpenseManager.Add(expense);
                Console.WriteLine("Adding new expense....");
            },
                addDescriptionOption, addAmountOption);
            expeseListsCommand.SetHandler(() =>
            {
                var expenses = ExpenseManager.List();
                foreach (var expense in expenses)
                {
                    Console.WriteLine($"\n{expense.Id}   {expense.Description}   {expense.Amount}");
                }
            });

            expeseSummaryCommand.SetHandler((month) =>
            {
                ExpenseManager.GetSummary(month);
            } , summaryByMonthOption);

            expeseDeleteCommand.SetHandler((id) =>
            {
                ExpenseManager.Delete(id);
            }, deleteExpenseOption);
            return RootCommand;
        }
    }
}
