using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Hotel_System.Reports
{
    internal class ReportPreviewForm : Form
    {
        // Used by BookingReport
        public ReportPreviewForm(DataTable reportData, DateTime fromDate, DateTime toDate)
            : this("Booking Report", reportData, fromDate, toDate,
                new[]
                {
                    ("CustomerName", "Customer Name", 1.8, "Left"),
                    ("PhoneNumber",  "Phone",         1.2, "Center"),
                    ("RoomType",     "Room Type",     1.3, "Center"),
                    ("CheckInDate",  "Check In",      1.7, "Center"),
                    ("CheckoutDate", "Check Out",     1.7, "Center"),
                    ("TotalAmout",   "Total ($)",     1.3, "Right"),
                })
        { }

        // General constructor used by all reports
        public ReportPreviewForm(string title, DataTable reportData, DateTime fromDate, DateTime toDate,
            (string Field, string Label, double WidthIn, string Align)[] columns)
        {
            Text = title + " Preview";
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

            var viewer = new ReportViewer
            {
                Dock = DockStyle.Fill,
                ProcessingMode = ProcessingMode.Local
            };

            string rdlc = BuildRdlcXml(title, fromDate, toDate, columns);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(rdlc));
            viewer.LocalReport.LoadReportDefinition(stream);

            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", reportData));

            viewer.RefreshReport();
            Controls.Add(viewer);
        }

        private static string BuildRdlcXml(string title, DateTime fromDate, DateTime toDate,
            (string Field, string Label, double WidthIn, string Align)[] columns)
        {
            string dateLabel = $"From: {fromDate:yyyy-MM-dd}     To: {toDate:yyyy-MM-dd}";
            double totalWidth = 0;
            foreach (var c in columns) totalWidth += c.WidthIn;

            var fields = new StringBuilder();
            var tablixCols = new StringBuilder();
            var headerCells = new StringBuilder();
            var dataCells = new StringBuilder();
            var colMembers = new StringBuilder();

            for (int i = 0; i < columns.Length; i++)
            {
                var col = columns[i];
                fields.AppendLine($@"<Field Name=""{col.Field}""><DataField>{col.Field}</DataField><rd:TypeName>System.String</rd:TypeName></Field>");
                tablixCols.AppendLine($"<TablixColumn><Width>{col.WidthIn}in</Width></TablixColumn>");
                headerCells.Append(HeaderCell($"hC{i}", col.Label));
                dataCells.Append(DataCell($"dC{i}", $"=Fields!{col.Field}.Value", col.Align));
                colMembers.AppendLine("<TablixMember/>");
            }

            return $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Report xmlns=""http://schemas.microsoft.com/sqlserver/reporting/2016/01/reportdefinition""
        xmlns:rd=""http://schemas.microsoft.com/SQLServer/reporting/reportdesigner"">
  <DataSources>
    <DataSource Name=""DataSet1"">
      <ConnectionProperties>
        <DataProvider>System.Data.DataSet</DataProvider>
        <ConnectString>/* Local Connection */</ConnectString>
      </ConnectionProperties>
    </DataSource>
  </DataSources>
  <DataSets>
    <DataSet Name=""DataSet1"">
      <Query>
        <DataSourceName>DataSet1</DataSourceName>
        <CommandText>/* Local Query */</CommandText>
      </Query>
      <Fields>
        {fields}
      </Fields>
    </DataSet>
  </DataSets>
  <ReportSections>
    <ReportSection>
      <Body>
        <Height>6in</Height>
        <ReportItems>

          <Textbox Name=""txtTitle"">
            <CanGrow>true</CanGrow>
            <KeepTogether>true</KeepTogether>
            <Paragraphs>
              <Paragraph>
                <TextRuns>
                  <TextRun>
                    <Value>{title}</Value>
                    <Style><FontFamily>Segoe UI</FontFamily><FontSize>16pt</FontSize><FontWeight>Bold</FontWeight><Color>#1F4E79</Color></Style>
                  </TextRun>
                </TextRuns>
                <Style><TextAlign>Center</TextAlign></Style>
              </Paragraph>
            </Paragraphs>
            <Top>0in</Top><Left>0in</Left><Width>{totalWidth}in</Width><Height>0.4in</Height>
            <Style><VerticalAlign>Middle</VerticalAlign></Style>
          </Textbox>

          <Textbox Name=""txtDate"">
            <CanGrow>true</CanGrow>
            <KeepTogether>true</KeepTogether>
            <Paragraphs>
              <Paragraph>
                <TextRuns>
                  <TextRun>
                    <Value>{dateLabel}</Value>
                    <Style><FontFamily>Segoe UI</FontFamily><FontSize>10pt</FontSize></Style>
                  </TextRun>
                </TextRuns>
                <Style><TextAlign>Center</TextAlign></Style>
              </Paragraph>
            </Paragraphs>
            <Top>0.45in</Top><Left>0in</Left><Width>{totalWidth}in</Width><Height>0.3in</Height>
            <Style><VerticalAlign>Middle</VerticalAlign></Style>
          </Textbox>

          <Tablix Name=""Tablix1"">
            <TablixBody>
              <TablixColumns>
                {tablixCols}
              </TablixColumns>
              <TablixRows>
                <TablixRow>
                  <Height>0.3in</Height>
                  <TablixCells>
                    {headerCells}
                  </TablixCells>
                </TablixRow>
                <TablixRow>
                  <Height>0.25in</Height>
                  <TablixCells>
                    {dataCells}
                  </TablixCells>
                </TablixRow>
              </TablixRows>
            </TablixBody>
            <TablixColumnHierarchy>
              <TablixMembers>
                {colMembers}
              </TablixMembers>
            </TablixColumnHierarchy>
            <TablixRowHierarchy>
              <TablixMembers>
                <TablixMember><KeepWithGroup>After</KeepWithGroup></TablixMember>
                <TablixMember><Group Name=""Details""/></TablixMember>
              </TablixMembers>
            </TablixRowHierarchy>
            <DataSetName>DataSet1</DataSetName>
            <Top>0.85in</Top><Left>0in</Left><Width>{totalWidth}in</Width>
          </Tablix>

        </ReportItems>
        <Style/>
      </Body>
      <Width>{totalWidth}in</Width>
      <Page>
        <PageHeight>11in</PageHeight><PageWidth>{totalWidth + 0.5}in</PageWidth>
        <LeftMargin>0.25in</LeftMargin><RightMargin>0.25in</RightMargin>
        <TopMargin>0.25in</TopMargin><BottomMargin>0.25in</BottomMargin>
        <Style/>
      </Page>
    </ReportSection>
  </ReportSections>
</Report>";
        }

        private static string HeaderCell(string name, string label) => $@"
                    <TablixCell>
                      <CellContents>
                        <Textbox Name=""{name}"">
                          <CanGrow>true</CanGrow>
                          <Paragraphs>
                            <Paragraph>
                              <TextRuns>
                                <TextRun>
                                  <Value>{label}</Value>
                                  <Style><FontFamily>Segoe UI</FontFamily><FontSize>9pt</FontSize><FontWeight>Bold</FontWeight><Color>White</Color></Style>
                                </TextRun>
                              </TextRuns>
                              <Style><TextAlign>Center</TextAlign></Style>
                            </Paragraph>
                          </Paragraphs>
                          <Style>
                            <BackgroundColor>#1F4E79</BackgroundColor>
                            <VerticalAlign>Middle</VerticalAlign>
                            <PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight>
                          </Style>
                        </Textbox>
                      </CellContents>
                    </TablixCell>";

        private static string DataCell(string name, string expr, string align) => $@"
                    <TablixCell>
                      <CellContents>
                        <Textbox Name=""{name}"">
                          <CanGrow>true</CanGrow>
                          <Paragraphs>
                            <Paragraph>
                              <TextRuns>
                                <TextRun>
                                  <Value>{expr}</Value>
                                  <Style><FontFamily>Segoe UI</FontFamily><FontSize>9pt</FontSize></Style>
                                </TextRun>
                              </TextRuns>
                              <Style><TextAlign>{align}</TextAlign></Style>
                            </Paragraph>
                          </Paragraphs>
                          <Style>
                            <Border><Style>Solid</Style><Color>#DDDDDD</Color></Border>
                            <VerticalAlign>Middle</VerticalAlign>
                            <PaddingLeft>4pt</PaddingLeft><PaddingRight>4pt</PaddingRight>
                          </Style>
                        </Textbox>
                      </CellContents>
                    </TablixCell>";
    }
}
