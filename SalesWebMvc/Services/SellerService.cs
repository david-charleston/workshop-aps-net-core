using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        // readonly evita a alteração do conteúdo da váriavel
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            // Retorna todos os vendedores
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            // Inseri o objeto no banco de dados
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
