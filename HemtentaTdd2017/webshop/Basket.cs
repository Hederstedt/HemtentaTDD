using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.webshop
{
    
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
        // blev lite osäker här så jag slänger in lite extra kontroller på p 
        public void AddProduct(Product p, int amount)
        {
            bool badProductFormat = p == null || string.IsNullOrEmpty(p.Name) || decimal.MinusOne == p.Price
                                            || decimal.MinValue == p.Price || decimal.Zero == p.Price;
            if (badProductFormat || amount <= 0)
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
            bool badProductFormat = p == null || string.IsNullOrEmpty(p.Name) || decimal.MinusOne == p.Price
                                           || decimal.MinValue == p.Price || decimal.Zero == p.Price;
            if (badProductFormat || amount <= 0)
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
