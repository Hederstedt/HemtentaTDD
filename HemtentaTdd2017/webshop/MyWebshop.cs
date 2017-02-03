using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.webshop
{
    // En del av uppgiften är att fundera över vad
    // det är som inte står i specen. När du stöter
    // på något som är osäkert, skriv ner som en
    // kommentar hur du tänkt.
    // Testa och implementera
    public class MyWebshop : IWebshop
    {
        //public IList<Product> inventory = new List<Product>
        //{
        //    new Product() { Name = "Banan", Price = 10 },
        //    new Product() { Name = "Kniv", Price = 159 },
        //    new Product() { Name = "Kanin", Price = 200 }
        //};
        //public int InventoryCounter()
        //{
        //    return inventory.Count();
        //}
        private IBasket Bs;
        public MyWebshop(IBasket bs)
        {
            this.Bs = bs;
        }
        public IBasket Basket
        {
            get
            {
                return Bs;
            }
        }

        public void Checkout(IBilling billing)
        {
            if (billing == null)
            {
                throw new NullInputException();
            }
        }
    }
}
