using FinanceApp.Models;

namespace FinanceApp.Data.Service
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetExpenses();
        Task<Expense> GetExpense(int id);
        Task AddExpense(Expense expense);
        Task UpdateExpense(Expense expense);
        Task DeleteExpense(int id);
    }
}
