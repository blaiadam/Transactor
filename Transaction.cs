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
    private readonly short TransactionDateColWidth = 15;
    private readonly short PostedColWidth = 15;
    private readonly short CardNumberColWidth = 5;
    private readonly short DescriptionColWidth = 30;
    private readonly short CategoryColWidth = 20;
    private readonly short DebitColWidth = 8;
    private readonly short CreditColWidth = 8;
    private readonly string TransactionDateHeader = "Transaction";
    private readonly string PostedHeader = "Posted";
    private readonly string CardNumberHeader = "Card";
    private readonly string DescriptionHeader = "Description";
    private readonly string CategoryHeader = "Category";
    private readonly string DebitHeader = "Debit";
    private readonly string CreditHeader = "Credit";
    #endregion

    #region Public Methods
    public void PrintHeaders()
    {
        Console.WriteLine($"{TransactionDateHeader.PadRight(TransactionDateColWidth)}" +
                          $"{PostedHeader.PadRight(PostedColWidth)}" +
                          $"{CardNumberHeader.PadRight(CardNumberColWidth)}" +
                          $"{DescriptionHeader.PadRight(DescriptionColWidth)}" +
                          $"{CategoryHeader.PadRight(CategoryColWidth)}" +
                          $"{DebitHeader.PadRight(DebitColWidth)}" +
                          $"{CreditHeader.PadRight(CreditColWidth)}");
    }

    public void Print()
    {
        Console.WriteLine($"{TransactionDate.ToShortDateString().PadRight(TransactionDateColWidth)}" +
                          $"{Posted.ToShortDateString().PadRight(PostedColWidth)}" + 
                          $"{CardNumber.PadRight(CardNumberColWidth)}" +
                          $"{Description.PadRight(DescriptionColWidth)}" +
                          $"{Category.PadRight(CategoryColWidth)}" +
                          $"{Debit.ToString().PadRight(DebitColWidth)}" +
                          $"{Credit.ToString().PadRight(CreditColWidth)}");
    }
    #endregion
}