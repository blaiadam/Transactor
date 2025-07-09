namespace Transactor.Controllers;

public static class UIController
{
    #region Public Properties
    public enum View
    {
        invalid,
        exit,
        read,
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
            Console.WriteLine($"{Environment.NewLine}Type in what actoin you would like to take:{Environment.NewLine}" +
                              $"[{View.exit}] - Close the program{Environment.NewLine}" +
                              $"[{View.read}] - Read all transactions from a given folder{Environment.NewLine}" +
                              $"[{View.list}] - Show all transactions in a table{Environment.NewLine}");

            userInput = Console.ReadLine();
            if (userInput is null || !Enum.TryParse(userInput, out userCommand))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            switch (userCommand)
            {
                case View.exit:
                    break;
                case View.read:
                    Console.WriteLine("Enter the folder to read from: ");
                    userInput = Console.ReadLine();

                    if (userInput is null || userInput.Length <= 5)
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                    
                    Read(userInput);
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
    private static void Read(string folder)
    {   
        FileController fileController = new();
        fileController.Read(folder);
    }
    
    private static void List()
    {
        DatabaseController dbController;
        Console.WriteLine();

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
    }
    #endregion
}