using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _service;

        public ExpensesController(IExpensesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _service.GetExpenses();
            return View(expenses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _service.AddExpense(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }
        public IActionResult GetChart() 
        {
            return Json(_service.GetChartData());
        }
    }
}
