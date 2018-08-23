using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibGrocery
{
    public class Transaction : Product
    {
        public double quantity { get; set; }
        private double totalPrice;

        public Transaction()
            : base()
        {
            quantity = 0;
        }

        public Transaction(string pn, string pt, double pp, int q)
            : base(pn, pt, pp)
        {
            quantity = q;
        }

        public Transaction(Product prod, int q)
            : base(prod)
        {
            quantity = q;
        }

        public Transaction(Transaction trans)
            : base(trans.prodName, trans.prodType, trans.prodPrice)
        {
            quantity = trans.quantity;
        }

        ~Transaction() { }

        private void calcTotalPrice()
        {
            totalPrice = prodPrice * quantity;
        }

        public double getTotalPrice()
        {
            calcTotalPrice();
            return totalPrice;
        }
    }
}
