using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public double AccountBalance { get; set; }
        public double RequiredBalance { get; set; }
        public InsufficientFundsException(double accountBalance, double requiredBalance)
        {
            RequiredBalance = requiredBalance;
            AccountBalance = accountBalance;
        }

        public InsufficientFundsException(double accountBalance, double requiredBalance, string message) : base(message)
        {
            RequiredBalance = requiredBalance;
            AccountBalance = accountBalance;
        }

        public InsufficientFundsException(double accountBalance, double requiredBalance, string message, Exception innerException) : base(message, innerException)
        {
            RequiredBalance = requiredBalance;
            AccountBalance = accountBalance;
        }
    }
}
