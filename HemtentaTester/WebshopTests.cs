using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HemtentaTdd2017.webshop;
using NUnit.Framework;
using Moq;
namespace HemtentaTester
{
    #region Frågor och svar

    #region Fråga 1 Vilka metoder och properties behöver testas?
    /*i basket behöver vi testa både add och removeproduct för att se så att
     * inte deras properties är null eller 0 då kastar vi exception
     * sen måste vi även testa så att båda metoderna ändrar totalcost
     * 
     */
    #endregion

    #region Fråga 2 Ska några exceptions kastas?
    /* 
     * Basket
     * bör kasta noproductException om man skickar in fel värden dvs null eller 0
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
        [Test]
        public void AddProductTest_throws_NoProductException()
        {
            Assert.That(() => bs.AddProduct(null, 2), Throws.TypeOf<NoProductException>());
        }
        [Test]
        public void AddProductTest_throws_NoProductException_if_amountIslesOreEqualtoZero()
        {
            Assert.That(() => bs.AddProduct(p, 0), Throws.TypeOf<NoProductException>());
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
       [Test]
        public void RemoveProductTest_throws_NoProductException()
        {
            Assert.That(() => bs.AddProduct(null, 2), Throws.TypeOf<NoProductException>());
        }
        [Test]
        public void RemoveProductTest_throws_NoProductException_if_amountIslesOreEqualtoZero()
        {
            Assert.That(() => bs.AddProduct(p, 0), Throws.TypeOf<NoProductException>());
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
            var mockBi = new Mock<IBilling>();
            IBilling bi = mockBi.Object;
            

        }


        //Börja med Checkout för att fixa så att den inte tar imot null 
        //vad behöver vi testa i MyWebshop?
        //se till så att checkout skickar ett exception ifall null skickas in 
        // skapa en DI på Ibasket för att skicka in värden till totalcost och ge det vidare till
        //billing




        #endregion

        //Arrange

        //Act

        // Assert 



    }
}
