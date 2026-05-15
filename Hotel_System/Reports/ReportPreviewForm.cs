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
        public ReportPreviewForm(DataTable reportData, DateTime fromDate, DateTime toDate)
        {
            Text = "Booking Report Preview";
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

            var viewer = new ReportViewer
            {
                Dock = DockStyle.Fill,
                ProcessingMode = ProcessingMode.Local
            };

            string rdlc = BuildRdlcXml(fromDate, toDate);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(rdlc));
            viewer.LocalReport.LoadReportDefinition(stream);

            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", reportData));

            viewer.RefreshReport();
            Controls.Add(viewer);
        }

        private static string BuildRdlcXml(DateTime fromDate, DateTime toDate)
        {
            string dateLabel = $"From: {fromDate:yyyy-MM-dd}     To: {toDate:yyyy-MM-dd}";

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
        <Field Name=""CustomerName""><DataField>CustomerName</DataField><rd:TypeName>System.String</rd:TypeName></Field>
        <Field Name=""PhoneNumber""><DataField>PhoneNumber</DataField><rd:TypeName>System.String</rd:TypeName></Field>
        <Field Name=""RoomType""><DataField>RoomType</DataField><rd:TypeName>System.String</rd:TypeName></Field>
        <Field Name=""CheckInDate""><DataField>CheckInDate</DataField><rd:TypeName>System.String</rd:TypeName></Field>
        <Field Name=""CheckoutDate""><DataField>CheckoutDate</DataField><rd:TypeName>System.String</rd:TypeName></Field>
        <Field Name=""TotalAmout""><DataField>TotalAmout</DataField><rd:TypeName>System.String</rd:TypeName></Field>
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
                    <Value>Booking Report</Value>
                    <Style><FontFamily>Segoe UI</FontFamily><FontSize>16pt</FontSize><FontWeight>Bold</FontWeight><Color>#1F4E79</Color></Style>
                  </TextRun>
                </TextRuns>
                <Style><TextAlign>Center</TextAlign></Style>
              </Paragraph>
            </Paragraphs>
            <Top>0in</Top><Left>0in</Left><Width>9in</Width><Height>0.4in</Height>
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
            <Top>0.45in</Top><Left>0in</Left><Width>9in</Width><Height>0.3in</Height>
            <Style><VerticalAlign>Middle</VerticalAlign></Style>
          </Textbox>

          <Tablix Name=""Tablix1"">
            <TablixBody>
              <TablixColumns>
                <TablixColumn><Width>1.8in</Width></TablixColumn>
                <TablixColumn><Width>1.2in</Width></TablixColumn>
                <TablixColumn><Width>1.3in</Width></TablixColumn>
                <TablixColumn><Width>1.7in</Width></TablixColumn>
                <TablixColumn><Width>1.7in</Width></TablixColumn>
                <TablixColumn><Width>1.3in</Width></TablixColumn>
              </TablixColumns>
              <TablixRows>
                <TablixRow>
                  <Height>0.3in</Height>
                  <TablixCells>
                    {HeaderCell("hC1", "Customer Name")}
                    {HeaderCell("hC2", "Phone")}
                    {HeaderCell("hC3", "Room Type")}
                    {HeaderCell("hC4", "Check In")}
                    {HeaderCell("hC5", "Check Out")}
                    {HeaderCell("hC6", "Total ($)")}
                  </TablixCells>
                </TablixRow>
                <TablixRow>
                  <Height>0.25in</Height>
                  <TablixCells>
                    {DataCell("dC1", "=Fields!CustomerName.Value", "Left")}
                    {DataCell("dC2", "=Fields!PhoneNumber.Value", "Center")}
                    {DataCell("dC3", "=Fields!RoomType.Value", "Center")}
                    {DataCell("dC4", "=Fields!CheckInDate.Value", "Center")}
                    {DataCell("dC5", "=Fields!CheckoutDate.Value", "Center")}
                    {DataCell("dC6", "=Fields!TotalAmout.Value", "Right")}
                  </TablixCells>
                </TablixRow>
              </TablixRows>
            </TablixBody>
            <TablixColumnHierarchy>
              <TablixMembers>
                <TablixMember/><TablixMember/><TablixMember/>
                <TablixMember/><TablixMember/><TablixMember/>
              </TablixMembers>
            </TablixColumnHierarchy>
            <TablixRowHierarchy>
              <TablixMembers>
                <TablixMember><KeepWithGroup>After</KeepWithGroup></TablixMember>
                <TablixMember><Group Name=""Details""/></TablixMember>
              </TablixMembers>
            </TablixRowHierarchy>
            <DataSetName>DataSet1</DataSetName>
            <Top>0.85in</Top><Left>0in</Left><Width>9in</Width>
          </Tablix>

        </ReportItems>
        <Style/>
      </Body>
      <Width>9in</Width>
      <Page>
        <PageHeight>11in</PageHeight><PageWidth>9.5in</PageWidth>
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
