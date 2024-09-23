using MathOperations.Models;
using Microsoft.AspNetCore.Mvc;

namespace MathOperations.Controllers
{
    public class MathController : Controller
    {
        // Display form to the user
        public IActionResult Index()
        {
            return View();
        }

        // Handle form submission and process the operation
        [HttpPost]
        public IActionResult Calculate(MathModel model)
        {
            if (ModelState.IsValid)
            {
                switch (model.Operation)
                {
                    case "Add":
                        model.Result = model.Number1 + model.Number2;
                        break;
                    case "Subtract":
                        model.Result = model.Number1 - model.Number2;
                        break;
                    case "Multiply":
                        model.Result = model.Number1 * model.Number2;
                        break;
                    case "Divide":
                        if (model.Number2 != 0)
                        {
                            model.Result = model.Number1 / model.Number2;
                        }
                        else
                        {
                            ModelState.AddModelError("", "Division by zero is not allowed.");
                            return View("Index", model);
                        }
                        break;
                    default:
                        ModelState.AddModelError("", "Invalid operation.");
                        return View("Index", model);
                }

                return View("Result", model);
            }

            return View("Index", model);
        }
    }
}
