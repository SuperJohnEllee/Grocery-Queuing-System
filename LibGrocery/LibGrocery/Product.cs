using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGrocery
{
    public class Product
    {
        public string prodName { get; set; }
        public string prodType { get; set; }
        public double prodPrice { get; set; }

        public Product()
        {
            prodName = "";
            prodType = "";
            prodPrice = 0;
        }

        public Product(string pn, string pt, double pp)
        {
            prodName = pn;
            prodType = pt;
            prodPrice = pp;
        }

        public Product(Product prod)
        {
            prodName = prod.prodName;
            prodType = prod.prodType;
            prodPrice = prod.prodPrice;
        }

        ~Product() { }

    }
}
