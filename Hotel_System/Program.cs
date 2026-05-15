namespace Hotel_System
{
    internal static class Program
    {
      
        [STAThread]
        static void Main()
        {
           
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}