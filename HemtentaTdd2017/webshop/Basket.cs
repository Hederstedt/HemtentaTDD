using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.webshop
{
    // Testa och implementera
    public class Basket : IBasket
    {

        //lägger till en property som sätter totalCost här
        public decimal totalCost { get; set; }
        public decimal TotalCost
        {
            get
            {
                return totalCost;
            }
        }

        public void AddProduct(Product p, int amount)
        {
            if (p == null || amount <= 0)
            {
                throw new NoProductException();
            }
            else
            {
                totalCost = p.Price * amount;
            }
        }

        public void RemoveProduct(Product p, int amount)
        {
            if (p == null || amount <= 0)
            {
                throw new NoProductException();
            }
            else
            {
                totalCost -= p.Price * amount;
            }
        }
    }
}
