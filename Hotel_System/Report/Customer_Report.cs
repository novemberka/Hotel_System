namespace Hotel_System.Report
{
    public partial class Customer_Report : RdlcReportForm
    {
        public Customer_Report()
            : base("Customer Report", "Customer.rdlc", ReportDataProvider.Customers)
        {
            InitializeComponent();
        }
    }
}
