namespace inventory;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        try
        {
            Database.Initialize();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Database initialization failed.\n\n" + ex.Message +
                "\n\nInstall the Microsoft Access Database Engine (ACE) matching your application's platform (64-bit)." +
                "\nDatabase file: " + Database.DbPath,
                "Inventory Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        Application.Run(new SignInForm());
    }
}
