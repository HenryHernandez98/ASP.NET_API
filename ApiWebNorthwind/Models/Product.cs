using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebNorthwind.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public String QuantityPerUnit { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public Boolean Discontinued { get; set; }
    }
}