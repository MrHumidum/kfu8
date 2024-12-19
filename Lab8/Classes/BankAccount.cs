using System;

namespace Lab8;
/// <summary>
/// Перечисление, представляющее виды банковских счетов.
/// </summary>
enum BankAccountType
{
    /// <summary>
    /// Текущий счет.
    /// </summary>
    Current,

    /// <summary>
    /// Сберегательный счет.
    /// </summary>
    Savings
}

/// <summary>
/// Класс, представляющий банковский счет.
/// </summary>
class BankAccount
{

    /// <summary>
    /// Номер счета.
    /// </summary>
    private int accountNumber;

    /// <summary>
    /// Статическая переменная для генерации уникальных номеров счетов.
    /// </summary>
    private static int nextAccountNumber = 0;

    /// <summary>
    /// Баланс счета.
    /// </summary>
    private decimal balance;

    /// <summary>
    /// Тип банковского счета.
    /// </summary>
    private BankAccountType accountType;

    private Queue<BankTransaction> Transactions = new Queue<BankTransaction>();

    /// <summary>
    /// Конструктор, создающий банковский счет с заданным балансом и типом.
    /// </summary>
    /// <param name="balance">Начальный баланс счета.</param>
    /// <param name="type">Тип банковского счета.</param>
    public BankAccount(decimal balance, BankAccountType type)
    {
        this.accountNumber = AccountNumberGenerator();
        this.balance = balance;
        this.accountType = type;
    }

    /// <summary>
    /// Конструктор по умолчанию, создающий счет с нулевым балансом.
    /// </summary>
    public BankAccount()
    {
        this.accountNumber = AccountNumberGenerator();
    }

    public BankAccount(decimal balance)
    {
        this.accountNumber = AccountNumberGenerator();
        this.balance = balance;
    }
    public BankAccount(BankAccountType type)
    {
        this.accountNumber = AccountNumberGenerator();
        this.accountType = type;
    }

    /// <summary>
    /// Метод для вывода информации о банковском счете.
    /// </summary>
    public void PrintAccountInfo()
    {
        Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance:C}\nТип банковского счета: {accountType}");
    }

    /// <summary>
    /// Генерирует уникальный номер счета.
    /// </summary>
    /// <returns>Уникальный номер счета.</returns>
    private int AccountNumberGenerator()
    {
        return nextAccountNumber++;
    }


    /// <summary>
    /// Снимает указанную сумму с баланса счета, если средств достаточно.
    /// </summary>
    /// <param name="money">Сумма для снятия с счета.</param>
    public void WithdrawMoney(decimal money)
    {
        if ((this.balance - money) >= 0)
        {
            this.balance -= money;
            Transactions.Enqueue(new BankTransaction(-money));
        }
        else
        {
            Console.WriteLine("Недостаточно средств на счету");
        }
    }

    /// <summary>
    /// Вносит указанную сумму на баланс счета.
    /// </summary>
    /// <param name="money">Сумма для депозита на счет.</param>
    public void DepositMoney(decimal money)
    {
        this.balance += money;
        Transactions.Enqueue(new BankTransaction(money));

    }


    public void TransferMoneyTo(BankAccount bankAccount, decimal money)
    {
        if ((bankAccount.balance - money) >= 0)
        {
            bankAccount.balance -= money;
            this.balance += money;
            this.Transactions.Enqueue(new BankTransaction(money));
            bankAccount.Transactions.Enqueue(new BankTransaction(-money));
        }
        else
        {
            Console.WriteLine("Недостаточно средств на счету");
        }
    }
    public void Dispose()
    {
        File.WriteAllText("../../../result.txt", string.Join("\n", Transactions.Select(t => t.ToString())));
        GC.SuppressFinalize(this);
    }

}



