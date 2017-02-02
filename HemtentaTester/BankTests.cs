using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HemtentaTdd2017.bank;
using NUnit.Framework;

namespace HemtentaTester
{
    [TestFixture]
    public class BankTests
    {
        private Account a;

        [SetUp]
        public void SetUp()
        {
            a = new Account();
        }

        #region DepositTests
        [TestCase(null)]
        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.MinValue)]
        [TestCase(-1.2)]
        public void Deposit_Throws_Exception_On_IllegalAount(double amount)
        {
            Assert.That(() => a.Deposit(amount), Throws.TypeOf<IllegalAmountException>());
        }
        [Test]
        public void Deposit_Pass()
        {
            a.Deposit(200);
            Assert.AreEqual(a.Amount, 200);
        }
        [Test]
        public void Deposit_Fail()
        {           
            Assert.AreNotEqual(a.Amount, 200);
        }

        #endregion

        #region WithdrawTests
        [TestCase(null)]
        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.MinValue)]
        [TestCase(-1.2)]
        public void Withdraw_Throws_Exception_On_IllegalAount(double amount)
        {
            Assert.That(() => a.Withdraw(amount), Throws.TypeOf<IllegalAmountException>());
        }
        [Test]
        public void Withdraw_Throws_Exception_On_InsufficientFunds()
        {
            Assert.That(() => a.Withdraw(200), Throws.TypeOf<InsufficientFundsException>());
        }
        [Test]
        public void Withdraw_pass()
        {
            a.Deposit(450);
            a.Withdraw(200);
            Assert.AreEqual(a.Amount, 250);
        }

        #endregion

        #region TransferFundsTests
        [TestCase(null)]
        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.MinValue)]
        [TestCase(-1.2)]
        public void TramsferFunds_Throws_Exception_On_IllegalAount(double amount)
        {
            IAccount account1 = new Account();
            Assert.That(() => a.TransferFunds(account1,amount),
                Throws.TypeOf<IllegalAmountException>());
        }
        [Test]
        public void TramsferFunds_Throws_Exception_On_destinationNull()
        {          
            Assert.That(() => a.TransferFunds(null, 200),
                Throws.TypeOf<OperationNotPermittedException>());
        }

        [Test]
        public void TramsferFunds_Throws_Exception_On_InsufficientFunds()
        {
           IAccount a1 = new Account();
            IAccount a2 = new Account();
            Assert.That(() => a1.TransferFunds(a2, 200),
                Throws.TypeOf<InsufficientFundsException>());
        }
        [Test]
        public void TramsferFunds_pass()
        {
            IAccount a1 = new Account();
            a1.Deposit(500);
            IAccount a2 = new Account();
            a1.TransferFunds(a2, 200);
            Assert.AreEqual(a1.Amount, 300);

            Assert.AreEqual(a2.Amount, 200);
        }



        #endregion


    }
}
