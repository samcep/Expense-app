using Expense_Tracker.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Expense_Tracker.Data
{
    internal static class ExpenseManager
    {
        private static readonly string Path = "C:\\Users\\samue\\Desktop\\Asynchronism\\C#\\Expense-Tracker\\Expense-Tracker\\Data\\data.json";

        private static void CreateFile()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path);
            }
        }


        public static void Add(Expense expense)
        {
            CreateFile();
            if (File.Exists(Path))
            {
                var data = File.ReadAllText(Path);
                List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(data) ?? new List<Expense>();
                expenses.Add(expense);
                var updateExpenses = JsonSerializer.Serialize(expenses);
                File.WriteAllText(Path, updateExpenses);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Expense added successfully(ID: ${expense.Id})");
            }
        }

        public static List<Expense> List()
        {
            CreateFile();
            if (File.Exists(Path))
            {
                var data = File.ReadAllText(Path);
                List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(data) ?? new List<Expense>();
                return expenses;
            }
            else
            {
                return new List<Expense>();

            }
        }

        public static void Delete(string id) 
        {
            if(File.Exists(Path))
            {
                var data = File.ReadAllText(Path);
                List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(data) ?? new List<Expense>();
                var expense = expenses.FirstOrDefault(expense => expense.Id.ToString() == id);
                if (expense is null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The expense with id  ${id} dosen't exists");
                    return;
                }
                var index = expenses.IndexOf(expense);
                expenses.RemoveAt(index);
                var updateExpenses = JsonSerializer.Serialize(expenses);
                File.WriteAllText(Path, updateExpenses);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Expense deleted successfully");
            }
        }

        public static void GetSummary(int month)
        {
            if (File.Exists(Path))
            {
                var data = File.ReadAllText(Path);
                List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(data) ?? new List<Expense>();
                if(month < 0 && month >= 12)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid month");
                    return;
                }
                if(month == 0)
                {
                    var sum = expenses.Sum(expenses => expenses.Amount);
                    Console.WriteLine($"Total expenses ${sum}");
                }else
                {
                    var sum = expenses.Where(ex => ex.CreatedAt.Month == month).Sum(expenses => expenses.Amount);
                    Console.WriteLine($"Total expenses for {DateTime.Now.ToString("MMMM")} {sum}");
                }
             
            }
            else
            {
                Console.WriteLine("Nothing to show...");

            }
        }
    }
}
