namespace Transactor;

internal static class Program
{
    internal static void Main()
    {
        int columnLength = 20;

        StreamReader transactionFile = new("Transactions/transactions.csv");
        string[] lineWords;
        string? line;
        while (!transactionFile.EndOfStream)
        {
            line = transactionFile.ReadLine();
            if (line is null)
                continue;

            lineWords = line.Split(',');
            for (int i = 0; i < lineWords.Length; i++)
            {
                if (lineWords[i].Length < columnLength)
                    lineWords[i] = lineWords[i].PadRight(columnLength);
                else
                    lineWords[i] = lineWords[i].Substring(0, columnLength);

                Console.Write(lineWords[i]);
            }

            Console.Write("\n");
        }
        transactionFile.Close();
    }
}