namespace Transactor;

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