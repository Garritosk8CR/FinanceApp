using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly FinanceAppContext _context;

        public ExpensesController(FinanceAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return View(expenses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expense);
        }
    }
}
