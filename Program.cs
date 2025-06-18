// ***** Read Files *****
using Transactor;

if (args.Length != 1)
{
    Console.WriteLine($"One argument is required");
    return;
}
string transFolder = args[0];

Console.WriteLine($"Reading files from: {args[0]}");
string[] transFiles = Directory.GetFiles(transFolder);
if (transFiles.Length == 0)
{
    Console.WriteLine($"No files found in folder: {transFolder}");
    return;
}

List<Transaction> transactions = [];
string[] lineWords;
string? line;
DateTime transDate;
DateTime postedDate;
decimal credit;
decimal debit;
foreach (string transFile in transFiles)
{
    Console.WriteLine($"Reading from file: {transFile}");
    StreamReader transFileReader = new(transFile);
    transFileReader.ReadLine(); // Read past the headers.
    while (!transFileReader.EndOfStream)
    {
        line = transFileReader.ReadLine();
        if (line is null)
            throw new Exception($"Null line in file");

        // TODO: The list's default capacity seems to be 100. Update this to use SQL lite or something else instead.
        lineWords = line.Split(',');
        transactions.Add(new Transaction(DateTime.TryParse(lineWords[0], out transDate) ? transDate : default, // Transaction Date
                                         DateTime.TryParse(lineWords[1], out postedDate) ? postedDate : default, // Posted Date
                                         lineWords[2], // Card Number
                                         lineWords[3], // Description
                                         lineWords[4], // Category
                                         decimal.TryParse(lineWords[5], out debit) ? debit : 0, // Debit
                                         decimal.TryParse(lineWords[6], out credit) ? credit : 0)); // Credit
    }
    transFileReader.Close();
}

Console.WriteLine($"Completed reading from {transFiles.Length} files");
Console.WriteLine();

// ***** Get User Input *****
string? userInput = "";
while (userInput != "exit")
{
    Console.WriteLine("How would you like to view your transactions? Options: [list]");
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