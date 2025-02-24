using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Service
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppContext _context;
        public ExpensesService(FinanceAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }
        public async Task<Expense> GetExpense(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }
        public async Task AddExpense(Expense expense)
        {
            _context.Add(expense);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateExpense(Expense expense)
        {
            _context.Update(expense);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
        public IQueryable GetChartData()
        {
            return _context.Expenses.GroupBy(e => e.Category)
                .Select(g => new { 
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount)
                });
        }
    }
}
