using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Retorna todos os departamentos
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(dep => dep.Name).ToList();
        }
    }
}
