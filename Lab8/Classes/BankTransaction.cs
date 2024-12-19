using System;

namespace Lab8
{

    public class BankTransaction
    {
        public readonly DateTime time = DateTime.Now;

        public readonly decimal oprationSum;

        public BankTransaction(decimal money)
        {
            this.oprationSum = money;
        }
        public override string ToString()
        {
            return $"{time:G} - Операция: {(oprationSum >= 0 ? "Депозит" : "Снятие")} на сумму: {oprationSum:C}";
        }


    }
}
