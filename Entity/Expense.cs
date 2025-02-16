using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Entity
{
    internal class Expense
    {
        public Guid Id { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Amount { get; set; } = default(int);

    }
}
