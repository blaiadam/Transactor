using Microsoft.Data.Sqlite;

namespace Transactor;

public class DatabaseController
{
    #region Members
    private readonly string ConnectionString = "Data Source=transactor.db";

    private readonly string CreateTableCommand = @"CREATE TABLE IF NOT EXISTS Transactions (
        Id INTEGER PRIMARY KEY AUTOINCREMENT,
        TransactionDate TEXT,
        PostedDate TEXT,
        CardNumber TEXT,
        Description TEXT,
        Category TEXT,
        Debit REAL,
        Credit REAL
    );";

    private readonly string InsertCommand = @"INSERT INTO Transactions (
        TransactionDate, 
        PostedDate, 
        CardNumber, 
        Description, 
        Category, 
        Debit, 
        Credit
    )
    VALUES (
        $TransactionDate, 
        $PostedDate, 
        $CardNumber, 
        $Description, 
        $Category, 
        $Debit, 
        $Credit
    );";
    #endregion

    #region Constructor
    public DatabaseController()
    {
        using SqliteConnection connection = new(ConnectionString);
        connection.Open();

        SqliteCommand createTableCmd = connection.CreateCommand();
        createTableCmd.CommandText = CreateTableCommand;
        createTableCmd.ExecuteNonQuery();
    }
    #endregion

    #region Public Methods
    public void Insert(List<Transaction> transactions)
    {
        using SqliteConnection connection = new(ConnectionString);
        connection.Open();

        SqliteCommand insertCmd = connection.CreateCommand();
        insertCmd.CommandText = InsertCommand;
        insertCmd.Parameters.Add("$TransactionDate", SqliteType.Text);
        insertCmd.Parameters.Add("$PostedDate", SqliteType.Text);
        insertCmd.Parameters.Add("$CardNumber", SqliteType.Text);
        insertCmd.Parameters.Add("$Description", SqliteType.Text);
        insertCmd.Parameters.Add("$Category", SqliteType.Text);
        insertCmd.Parameters.Add("$Debit", SqliteType.Real);
        insertCmd.Parameters.Add("$Credit", SqliteType.Real);

        foreach (Transaction transaction in transactions)
        {
            insertCmd.Parameters["$TransactionDate"].Value = transaction.TransactionDate.Date;
            insertCmd.Parameters["$PostedDate"].Value = transaction.Posted.Date;
            insertCmd.Parameters["$CardNumber"].Value = transaction.CardNumber;
            insertCmd.Parameters["$Description"].Value = transaction.Description;
            insertCmd.Parameters["$Category"].Value = transaction.Category;
            insertCmd.Parameters["$Debit"].Value = transaction.Debit;
            insertCmd.Parameters["$Credit"].Value = transaction.Credit;

            insertCmd.ExecuteNonQuery();
        }
    }
    #endregion
}