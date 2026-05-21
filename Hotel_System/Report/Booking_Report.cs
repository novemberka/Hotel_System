namespace Hotel_System.Report
{
    public partial class Booking_Report : RdlcReportForm
    {
        public Booking_Report()
            : base("Booking Report", "Booking.rdlc", ReportDataProvider.Bookings)
        {
            InitializeComponent();
        }
    }
}
