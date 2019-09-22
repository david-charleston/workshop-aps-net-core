using Microsoft.AspNetCore.Mvc;
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
    }
}