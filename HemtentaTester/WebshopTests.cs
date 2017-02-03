using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HemtentaTdd2017.webshop;
using NUnit.Framework;

namespace HemtentaTester
{
    #region Frågor och svar

    #region Fråga 1 Vilka metoder och properties behöver testas?
    /* basket 
     * behöver vi testa både add och removeproduct för att se så att
     * inte deras properties är null eller 0 då kastar vi exception
     * sen måste vi även testa så att båda metoderna ändrar totalcost
     * och även göra en kontroll så att produkt objektens medlemsvariabler inte har fel format
     * 
     * MyWebshop
     * behöver vi testa så att checkout kastar exception om billing är null 
     * vi behöver även testa så att vår fake Ibilling.balance får ett nytt värde efter vi kört checkout    
     */
    #endregion

    #region Fråga 2 Ska några exceptions kastas?
    /* 
     * Basket
     * bör kasta noproductException om man skickar in fel värden dvs null eller 0
     * eller om objektet produk p medlemsvariabler p.name och p.prise har fel värden
    *  
    *  MyWebshop
    *  kastar en NullInputException om vi försöker skicka in null i Checkout eller om vår 
    *  Ibasket inte har något returvärde
    */
    #endregion

    #region Fråga 3 Vilka är domänerna för IWebshop och IBasket?
    /* IWebshop
    * Ibasket basket { get;} Object = Null eller Objekt
    * void Checkout(IBilling billing = Object = null eller objekt)
    * 
    * IBasket
    * Addproduct(Product p = Object kan ha domänerna null eller objekt
    *              int amount = alla heltal mellan -2147483648 och +2147483647)
    * RemoveProduct(har samma domäner som Add)
    * decimal TotalCost{ get;} decimal = domänerna max och min Value sen har den
    *                          One, MinusOne, och zero.
    */
    #endregion
    #endregion
    [TestFixture]
    public class WebshopTests
    {
        #region SetUP

        
        private Product p;
        private Basket bs;
        private MyWebshop ws;

        [SetUp]
        public void Setup()
        {
            p = new Product();
            ws = new MyWebshop(bs);
            bs = new Basket();
        }
        #endregion

        #region BasketTests

        [TestCase("hej",20,0)]
        [TestCase("", 20, 2)]
        [TestCase("hej", null, 3)]
        public void AddProductTest_throws_NoProductException(string name, decimal price, int amount )
        {
            Product pb = new Product { Name = name, Price = price };
            Assert.That(() => bs.AddProduct(pb, amount), Throws.TypeOf<NoProductException>());
        }
     
        [Test]
        public void AddProductTest_Product_times_Amount_changes_TotalCost()
        {
            p.Name = "banan";
            p.Price = 10;
            bs.AddProduct(p, 5);
            var result = bs.TotalCost;
            Assert.AreEqual(result, 50);
        }
        [TestCase("hej", 20, 0)]
        [TestCase("", 20, 2)]
        [TestCase("hej", null, 3)]
        [TestCase(null, null, null)]
        public void RemoveProductTest_throws_NoProductException(string name, decimal price, int amount)
        {
            Product pb = new Product { Name = name, Price = price };
            Assert.That(() => bs.RemoveProduct(pb, amount), Throws.TypeOf<NoProductException>());
        }       
        [Test]
        public void RemoveProductTest_Product_minus_Amount_changes_TotalCost()
        {
            p.Name = "banan";
            p.Price = 10;
            bs.AddProduct(p, 5);
            bs.RemoveProduct(p, 3);            
            Assert.AreEqual(bs.TotalCost, 20);
        }
        #endregion

        #region MyWebshopTests
        [Test]
        public void Checkout_throws_NullInputexception()
        {
            Assert.That(() => ws.Checkout(null), Throws.TypeOf<NullInputException>());
        }
        [Test]
        public void Checkout_bills_the_totalcost()
        {
            p.Name = "såg";
            p.Price = 150;
            IBasket basket = new Basket();
            basket.AddProduct(p, 1);
            IWebshop webshop = new MyWebshop(basket);
            IBilling billing = new FakeIBilling();
            billing.Balance = 200;
            webshop.Checkout(billing);
            Assert.AreEqual(billing.Balance, 50);
        }
        #endregion

        #region FakeIBIlling
    }
    public class FakeIBilling : IBilling
    {
        private decimal balance;
        public decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public void Pay(decimal amount)
        {
            if (amount <= 0)
            {
                throw new NullInputException();
            }
            Balance -= amount;
        }
    }
    #endregion
}
