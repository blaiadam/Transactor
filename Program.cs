using Microsoft.Data.SqlClient;
using System.Data;
using Transactor;

// ***** Get List of Files from Directory *****
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

// ***** Setup SQL Connection *****
// TODO: Need to update my service account.
using SqlConnection conn = new(Globals.ConnectionString);
conn.Open();
using SqlCommand cmd = new(
    @"INSERT INTO Transactions
        (TransactionDate, 
         PostedDate, 
         CardNumber, 
         Description, 
         Category, 
         Debit, 
         Credit)
      VALUES (@TransactionDate,
              @PostedDate,
              @CardNumber,
              @Description,
              @Category,
              @Debit,
              @Credit)",
    conn
);
cmd.Parameters.Add("@TransactionDate", SqlDbType.Date);
cmd.Parameters.Add("@PostedDate", SqlDbType.Date);
cmd.Parameters.Add("@CardNumber", SqlDbType.NVarChar);
cmd.Parameters.Add("@Description", SqlDbType.NVarChar);
cmd.Parameters.Add("@Category", SqlDbType.NVarChar);
cmd.Parameters.Add("@Debit", SqlDbType.Decimal);
cmd.Parameters.Add("@Credit", SqlDbType.Decimal);

// ***** Read Files *****
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
        if (line.Length == 0)
            continue;

        lineWords = line.Split(',');

        cmd.Parameters["@TransactionDate"].Value = DateTime.TryParse(lineWords[0], out transDate) ? transDate : default;
        cmd.Parameters["@PostedDate"].Value = DateTime.TryParse(lineWords[1], out postedDate) ? postedDate : default;
        cmd.Parameters["@CardNumber"].Value = lineWords[2];
        cmd.Parameters["@Description"].Value = lineWords[3];
        cmd.Parameters["@Category"].Value = lineWords[4];
        cmd.Parameters["@Debit"].Value = decimal.TryParse(lineWords[5], out debit) ? debit : 0;
        cmd.Parameters["@Credit"].Value = decimal.TryParse(lineWords[6], out credit) ? credit : 0;
        cmd.ExecuteNonQuery();
    }
    transFileReader.Close();
}

Console.WriteLine($"Completed reading from {transFiles.Length} files");
Console.WriteLine();

// ***** Get User Input *****
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