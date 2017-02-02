using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.bank
{
    public class Account : IAccount
    {
        // Representerar ett konto. Implementera den här!
        // Obs: i vanliga fall ska datatypen decimal användas
        // i stället för double när man hanterar pengar.
        // behöver inte testas
        public double Balance { get; set; }
        public double Amount
        {
            get
            {
                return Balance;
            }
        }
        // Sätter in ett belopp på kontot
        public void Deposit(double amount)
        {
            if (IllegalAmountHelper(amount))
            {
                throw new IllegalAmountException();
            }
            else
            {
                Balance += amount;
            }
        }

        // Överför ett belopp från ett konto till ett annat
        public void TransferFunds(IAccount destination, double amount)
        {

            if (IllegalAmountHelper(amount))
            {
                throw new IllegalAmountException();
            }
            if (destination == null)
            {
                throw new OperationNotPermittedException();
            }
            if (Amount <= 0)
            {
                throw new InsufficientFundsException();
            }
            Withdraw(amount);
            destination.Deposit(amount);

        }
        // Gör ett uttag från kontot
        public void Withdraw(double amount)
        {
            if (IllegalAmountHelper(amount))
            {
                throw new IllegalAmountException();
            }
            if (Amount < amount)
            {
                throw new InsufficientFundsException();
            }
            else
            {
                Balance -= amount;
            }
        }

        #region HelperMethods
        private bool IllegalAmountHelper(double amount)
        {
            bool IllegalAmount = amount <= 0 || double.IsNaN(amount)
              || double.IsInfinity(amount);
            if (IllegalAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }

}
