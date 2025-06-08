namespace Transactor;
/*
public class List
{
    public List<Transaction> Transactions { get; }

    public void Print()
    {
        Console.Write("Transaction Date".PadRight(Column_Length["TransactionDate"]));
        Console.Write("Posted Date".PadRight(Column_Length["Posted"]));
        Console.Write("Card Number".PadRight(Column_Length["CardNumber"]));
        Console.Write("Description".PadRight(Column_Length["Description"]));
        Console.Write("Category".PadRight(Column_Length["Category"]));
        Console.Write("Debit".PadRight(Column_Length["Debit"]));
        Console.Write("Credit".PadRight(Column_Length["Credit"]));

        foreach (Transaction transaction in Transactions)
        {
            Console.Write(transaction.TransactionDate.ToShortDateString(), Column_Length["TransactionDate"]);
            Console.Write("Posted Date", Column_Length["Posted"]);
            Console.Write("Card Number", Column_Length["CardNumber"]);
            Console.Write("Description", Column_Length["Description"]);
            Console.Write("Category", Column_Length["Category"]);
            Console.Write("Debit", Column_Length["Debit"]);
            Console.Write("Credit", Column_Length["Credit"]);
        }
    }

    public void Add(DateTime transactionDate,
                    DateTime posted,
                    int cardNumber,
                    string description,
                    string category,
                    decimal debit,
                    decimal credit)
    {
        Transactions.Add(new Transaction(transactionDate,
                                         posted,
                                         cardNumber,
                                         description,
                                         category,
                                         debit,
                                         credit));
    }

    public class Transaction(DateTime transactionDate,
                              DateTime posted,
                              int cardNumber,
                              string description,
                              string category,
                              decimal debit,
                              decimal credit)
    {
        public DateTime TransactionDate { get; set; } = transactionDate;
        public DateTime Posted { get; set; } = posted;
        public int CardNumber { get; set; } = cardNumber;
        public string Description { get; set; } = description;
        public string Category { get; set; } = category;
        public decimal Debit { get; set; } = debit;
        public decimal Credit { get; set; } = credit;
    }
}
*/