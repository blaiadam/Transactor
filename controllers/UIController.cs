namespace Transactor.controllers;

public static class UIController
{
    public enum View
    {
        invalid,
        exit,
        list
    }

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
                    Console.WriteLine("Listing your transactions...");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Console.WriteLine();
                    break;
            }
        } while (userCommand != View.exit);
    }
}