using System;
using System.Web.Mvc;

namespace ExpenseManager.Web.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
