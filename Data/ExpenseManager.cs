using Expense_Tracker.Entity;
using System;
using System.Collections.Generic;
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
    }
}
