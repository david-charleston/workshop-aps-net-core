using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ModelsView;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService serviceService, DepartmentService departmentService)
        {
            _sellerService = serviceService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View(_sellerService.FindAll());
        }

        public IActionResult Create()
        {
            var department = _departmentService.FindAll();
            var viewModel = new SellerFormModelView { Departments = department };
            return View(viewModel);
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
            _sellerService.Insert(seller);
            // Redireciona a página para o index
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Pegando o objeto que vai ser deletado
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}