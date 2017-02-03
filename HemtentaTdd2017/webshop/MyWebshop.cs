using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.webshop
{

    public class MyWebshop : IWebshop
    {
        //DI här för jag antar att jag måste ha det för att kunna frigöra så att klassen Ibasket inte skall vara kopplad till mywebshop
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
            else
            {
                billing.Pay(Bs.TotalCost);
            }

        }
    }
}
