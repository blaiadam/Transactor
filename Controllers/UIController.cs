namespace Transactor.Controllers;

public static class UIController
{
    #region Public Properties
    public enum View
    {
        invalid,
        exit,
        list
    }
    #endregion

    #region Public Methods
    public static void Start()
    {
        string? userInput = "";
        View userCommand = View.invalid;
        do
        {
            Console.WriteLine($"How would you like to view your transactions?{Environment.NewLine}" +
                              $"Options:{Environment.NewLine}" +
                              $"[{View.exit}] - Close the program{Environment.NewLine}" +
                              $"[{View.list}] - Show all transactions in a table{Environment.NewLine}");

            userInput = Console.ReadLine();
            if (userInput is null || !Enum.TryParse(userInput, out userCommand))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine();
                continue;
            }

            switch (userCommand)
            {
                case View.exit:
                    break;
                case View.list:
                    List();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Console.WriteLine();
                    break;
            }
        } while (userCommand != View.exit);
    }
    #endregion

    #region Private Methods
    private static void List()
    {
        DatabaseController dbController;
        Console.WriteLine($"***** BEGIN LIST *****");

        dbController = new();
        List<Transaction> transactions = dbController.Get();
        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions were retrieved.");
            return;
        }

        transactions[0].PrintHeaders();
        foreach (Transaction transaction in transactions)
            transaction.Print();

        Console.WriteLine("***** END LIST *****");
    }
    #endregion
}