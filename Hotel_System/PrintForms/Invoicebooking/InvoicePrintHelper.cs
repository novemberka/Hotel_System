using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Hotel_System.PrintForms
{
    public class InvoicePrintHelper
    {
        public static void Print(Form form)
        {
            PrintDocument pd =
                new PrintDocument();

            pd.PrintPage += (s, e) =>
            {
                Bitmap bmp =
                    new Bitmap(form.Width, form.Height);

                form.DrawToBitmap(
                    bmp,
                    new Rectangle(
                        0,
                        0,
                        form.Width,
                        form.Height));

                e.Graphics.DrawImage(
                    bmp,
                    0,
                    0);
            };

            PrintPreviewDialog preview =
                new PrintPreviewDialog();

            preview.Document = pd;

            preview.WindowState =
                FormWindowState.Maximized;

            preview.ShowDialog();
        }
    }
}