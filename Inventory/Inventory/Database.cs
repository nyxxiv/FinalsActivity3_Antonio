using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace inventory;

public static class Database
{
    public static string DbPath { get; } = BuildDbPath();

    public static string ConnectionString =>
        @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DbPath + ";Persist Security Info=False;";

    public static OleDbConnection GetConnection() => new OleDbConnection(ConnectionString);

    public static decimal ReadScalar(string sql)
    {
        using var con = GetConnection();
        con.Open();
        using var cmd = new OleDbCommand(sql, con);
        object? result = cmd.ExecuteScalar();
        return result == null || result == DBNull.Value ? 0m : Convert.ToDecimal(result);
    }

    private static string BuildDbPath()
    {
        string? dir = AppContext.BaseDirectory;
        for (int i = 0; i < 8 && dir != null; i++, dir = Path.GetDirectoryName(dir))
        {
            if (Directory.GetFiles(dir, "*.csproj").Length > 0)
                return Path.Combine(dir, "DataBasenj.accdb");
        }
        string docs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "InventoryManagementSystem");
        Directory.CreateDirectory(docs);
        return Path.Combine(docs, "DataBasenj.accdb");
    }

    public static void Initialize()
    {
        CreateDatabaseFileIfMissing();

        using var con = GetConnection();
        con.Open();
        (string Name, string Sql)[] tables =
        {
            ("Users", "CREATE TABLE Users (UserID AUTOINCREMENT PRIMARY KEY, Username TEXT(50), PasswordHash TEXT(255), FullName TEXT(100), UserRole TEXT(20), IsActive YESNO)"),
            ("Products", "CREATE TABLE Products (ProductID AUTOINCREMENT PRIMARY KEY, ProductName TEXT(100), Category TEXT(50), Quantity LONG, UnitPrice CURRENCY, ReorderLevel LONG)"),
            ("StockTransactions", "CREATE TABLE StockTransactions (TransactionID AUTOINCREMENT PRIMARY KEY, ProductID LONG, TransactionType TEXT(20), Quantity LONG, TransactionDate DATETIME, UserID LONG, Remarks TEXT(255))"),
            ("ActivityLogs", "CREATE TABLE ActivityLogs (LogID AUTOINCREMENT PRIMARY KEY, UserID LONG, ActionDone TEXT(255), LogDate DATETIME)")
        };
        foreach (var (name, sql) in tables)
        {
            if (TableExists(con, name)) continue;
            using var cmd = new OleDbCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }

    private static bool TableExists(OleDbConnection con, string table)
    {
        using var schema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object?[] { null, null, table, "TABLE" })!;
        return schema.Rows.Count > 0;
    }

    private static void CreateDatabaseFileIfMissing()
    {
        if (File.Exists(DbPath)) return;
        try
        {
            var type = Type.GetTypeFromProgID("ADOX.Catalog")
                ?? throw new InvalidOperationException("ADOX is not available on this machine.");
            dynamic catalog = Activator.CreateInstance(type)!;
            try { catalog.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DbPath + ";"); }
            finally { Marshal.ReleaseComObject(catalog); }
        }
        catch (Exception ex)
        {
            throw new FileNotFoundException(
                "DataBasenj.accdb was not found and could not be created automatically (" + ex.Message + ").\n" +
                "Create a blank Access database named DataBasenj.accdb at the path shown below.", DbPath);
        }
    }
}
