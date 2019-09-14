using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departaments = new List<Department>();
            departaments.Add(new Department { Id = 1, Name = "Eletronics" });
            departaments.Add(new Department { Id = 2, Name = "Fashion" });

            // Enviando os dados do Controller para a View
            return View(departaments);
        }
    }
}