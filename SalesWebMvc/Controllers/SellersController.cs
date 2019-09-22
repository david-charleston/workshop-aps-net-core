using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _serviceService;

        public SellersController(SellerService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View(_serviceService.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        /**
         * Este método vai receber um objeto seller que 
         * vai vir por meio da requisição
         */
         // Esta anotação indica que o método é post
         [HttpPost]
         [ValidateAntiForgeryToken] // Evita ataque CSRF
        public IActionResult Create(Seller seller)
        {
            _serviceService.Insert(seller);
            // Redireciona a página para o index
            return RedirectToAction(nameof(Index));
        }
    }
}