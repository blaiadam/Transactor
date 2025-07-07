namespace Transactor;

public class Transaction(DateTime transactionDate,
                         DateTime posted,
                         string cardNumber,
                         string description,
                         string category,
                         decimal debit,
                         decimal credit)
{
    #region Public Properties
    public DateTime TransactionDate { get; set; } = transactionDate;
    public DateTime Posted { get; set; } = posted;
    public string CardNumber { get; set; } = cardNumber;
    public string Description { get; set; } = description;
    public string Category { get; set; } = category;
    public decimal Debit { get; set; } = debit;
    public decimal Credit { get; set; } = credit;
    #endregion

    #region Private Properties
    private readonly short TransactionDateColWidth = 20;
    private readonly short PostedColWidth = 20;
    private readonly short CardNumberColWidth = 15;
    private readonly short DescriptionColWidth = 50;
    private readonly short CategoryColWidth = 30;
    private readonly short DebitColWidth = 10;
    private readonly short CreditColWidth = 10;
    private readonly string TransactionDateHeader = "Transaction Date";
    private readonly string PostedHeader = "Posted";
    private readonly string CardNumberHeader = "Card Number";
    private readonly string DescriptionHeader = "Description";
    private readonly string CategoryHeader = "Category";
    private readonly string DebitHeader = "Debit";
    private readonly string CreditHeader = "Credit";
    #endregion

    #region Public Methods
    public void PrintHeaders()
    {
        Console.Write($"{TransactionDateHeader.PadRight(TransactionDateColWidth - TransactionDateHeader.Length)}");
        Console.Write($"{PostedHeader.PadRight(PostedColWidth - PostedHeader.Length)}");
        Console.Write($"{CardNumberHeader.PadRight(CardNumberColWidth - CardNumberHeader.Length)}");
        Console.Write($"{DescriptionHeader.PadRight(DescriptionColWidth - DescriptionHeader.Length)}");
        Console.Write($"{CategoryHeader.PadRight(CategoryColWidth - CategoryHeader.Length)}");
        Console.Write($"{DebitHeader.PadRight(DebitColWidth - DebitHeader.Length)}");
        Console.Write($"{CreditHeader.PadRight(CreditColWidth - CreditHeader.Length)}{Environment.NewLine}");
    }

    public void Print()
    {
        Console.Write($"{TransactionDate.ToShortDateString().PadRight(TransactionDateColWidth - TransactionDate.ToShortDateString().Length)}");
        Console.Write($"{Posted.ToShortDateString().PadRight(PostedColWidth - Posted.ToShortDateString().Length)}");
        Console.Write($"{CardNumber.PadRight(CardNumberColWidth - CardNumber.Length)}");
        Console.Write($"{Description.PadRight(DescriptionColWidth - Description.Length)}");
        Console.Write($"{Category.PadRight(CategoryColWidth - Category.Length)}");
        Console.Write($"{Debit.ToString().PadRight(DebitColWidth - Debit.ToString().Length)}");
        Console.Write($"{Credit.ToString().PadRight(CreditColWidth - Debit.ToString().Length)}{Environment.NewLine}");
    }
    #endregion
}