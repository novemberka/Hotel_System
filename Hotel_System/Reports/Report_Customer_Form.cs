using Hotel_System.UI;

namespace Hotel_System
{
    public class Report_Customer_Form : Form
    {
        public Report_Customer_Form()
        {
            BackColor = UiTheme.PageBackground;

            Report_Customer uc = new()
            {
                Dock = DockStyle.Fill
            };
            UiTheme.EnableResponsivePage(uc);

            Controls.Add(uc);
            Text = "Customer Report";
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
