namespace Hotel_System.Report
{
    public partial class Checkin_Report : RdlcReportForm
    {
        public Checkin_Report()
            : base("Check-In Report", "checkin.rdlc", ReportDataProvider.CheckIns)
        {
            InitializeComponent();
        }
    }
}
