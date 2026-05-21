namespace Hotel_System.Report
{
    public partial class Payment_Report : RdlcReportForm
    {
        public Payment_Report()
            : base("Payment Report", "payment.rdlc", ReportDataProvider.Payments)
        {
            InitializeComponent();
        }
    }
}
