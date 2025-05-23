using Microsoft.AspNetCore.Mvc;

namespace Calculator.UI.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Input
        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

        // POST: /Home/Result
        [HttpPost]
        public IActionResult Result(double left, double right, string op)
        {
            double result;
            switch (op)
            {
                case "+":
                    result = left + right;
                    break;
                case "−":
                    result = left - right;
                    break;
                case "×":
                    result = left * right;
                    break;
                case "÷":
                    result = right != 0 ? left / right : double.NaN;
                    break;
                default:
                    ModelState.AddModelError("", "Invalid operator");
                    return View("Input");
            }

            ViewBag.Left = left;
            ViewBag.Right = right;
            ViewBag.Operator = op;
            ViewBag.Result = result;

            return View("Result");
        }
    }
}
