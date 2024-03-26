using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    public class CartoesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
