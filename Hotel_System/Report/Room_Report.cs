namespace Hotel_System.Report
{
    public partial class Room_Report : RdlcReportForm
    {
        public Room_Report()
            : base("Room Report", "Rooms.rdlc", ReportDataProvider.Rooms)
        {
            InitializeComponent();
        }
    }
}
