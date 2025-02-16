using Expense_Tracker.Commands;
using System.CommandLine;

var rootCommand = CommandHandle.GenerateCommand();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Title = "Expense App";
Console.WriteLine("Welcome to your expense app!");

while (true)
{   
    Console.ResetColor();
    Console.Write("\nexpense-tracker> ");
    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) continue;
    if (input.Trim().ToLower() == "exit") break; 
    await rootCommand.InvokeAsync(input);
}