namespace Hotel_System.Report
{
    public partial class Checkout_Report : RdlcReportForm
    {
        public Checkout_Report()
            : base("Check-Out Report", "checkout.rdlc", ReportDataProvider.CheckOuts)
        {
            InitializeComponent();
        }
    }
}
