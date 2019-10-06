using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        // Define como vai aparecer na View
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        // Esta propriedade informa que o Id do Department não deve ser nulo
        public int DepartmentId { get; set; }
        public ICollection<SalesRecords> SalesRecords { get; set; } = new List<SalesRecords>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecords sr)
        {
            SalesRecords.Add(sr);
        }

        public void RemoveSales(SalesRecords sr)
        {
            SalesRecords.Remove(sr);
        }

        // Retorna o valor de todas as venda feitas em um determinado tempo
        public double TotalSales(DateTime intial, DateTime final)
        {
            return SalesRecords.Where(sr => sr.Date >= intial && sr.Date <= final)
                .Select(sr => sr.Amount)
                .DefaultIfEmpty(0.0)
                .Sum();
        }
    }
}
