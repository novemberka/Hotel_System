namespace Hotel_System
{
    public class Report_Customer_Form : Form 
    {
        public Report_Customer_Form()
        {
            

            Report_Customer uc = new Report_Customer();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);

            this.Text = "Customer Report";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}