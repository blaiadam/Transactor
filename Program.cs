using Transactor;

if (args.Length != 1)
{
    Console.WriteLine($"One argument is required");
    return;
}

FileController fileController = new();
fileController.Read(args[0]);

string? userInput = "";
while (userInput != "exit")
{
    Console.WriteLine("How would you like to view your transactions? Options: [list] | [exit] to exit the program");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "list":
            Console.WriteLine("Listing your transactions...");
            break;
        default:
            break;
    }
}