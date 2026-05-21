namespace Hotel_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, e) => ShowUnhandledError(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (_, e) =>
                ShowUnhandledError(e.ExceptionObject as Exception);

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }

        private static void ShowUnhandledError(Exception? exception)
        {
            string message = exception?.Message ?? "An unexpected error occurred.";

            MessageBox.Show(
                "The hotel system ran into a problem, but it did not close.\n\n" + message,
                "Hotel Management System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
