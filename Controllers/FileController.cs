namespace Transactor.Controllers;

public class FileController
{
    #region Private Members
    private readonly int MaxTransactionListCapacity = 1000;
    #endregion

    #region Public Methods
    public void Read(string folderPath)
    {
        // Get list of files from given directory.
        Console.WriteLine();
        string[] transFiles = Directory.GetFiles(folderPath);
        if (transFiles.Length == 0)
        {
            Console.WriteLine($"No files found in folder: {folderPath}");
            return;
        }

        // Read files.
        Console.WriteLine($"Reading files in folder: {folderPath}");
        List<Transaction> transactions = new(MaxTransactionListCapacity);
        string[] lineWords;
        string? line;
        DateTime transDate;
        DateTime postedDate;
        decimal credit;
        decimal debit;
        DatabaseController dbController = new();
        foreach (string transFile in transFiles)
        {
            // Read file
            Console.WriteLine($"Reading from file: {transFile}");
            StreamReader transFileReader = new(transFile);
            transFileReader.ReadLine(); // Read past the headers.
            line = transFileReader.ReadLine();

            while (!transFileReader.EndOfStream)
            {
                if (line is null)
                    throw new Exception($"Null line in file");
                if (line.Length == 0)
                    continue;

                lineWords = line.Split(',');

                transactions.Add(new Transaction(
                    DateTime.TryParse(lineWords[0], out transDate) ? transDate : default,
                    DateTime.TryParse(lineWords[1], out postedDate) ? postedDate : default,
                    lineWords[2],
                    lineWords[3],
                    lineWords[4],
                    decimal.TryParse(lineWords[5], out debit) ? debit : 0,
                    decimal.TryParse(lineWords[6], out credit) ? credit : 0
                ));

                if (transactions.Count == MaxTransactionListCapacity)
                {
                    // Insert and clear transaction list if at max capacity.
                    dbController.Insert(transactions);
                    transactions = new(MaxTransactionListCapacity);
                }

                line = transFileReader.ReadLine();
            }
            transFileReader.Close();

            // Insert remaining transactions.
            if (transactions.Count > 0)
            {
                dbController.Insert(transactions);
                transactions = new(MaxTransactionListCapacity);
            }
        }

        Console.WriteLine($"Completed reading {transFiles.Length} files");
    }
    #endregion
}