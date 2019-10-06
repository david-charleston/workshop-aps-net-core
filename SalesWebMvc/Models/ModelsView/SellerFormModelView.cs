using System.Collections.Generic;

namespace SalesWebMvc.Models.ModelsView
{
    public class SellerFormModelView
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
