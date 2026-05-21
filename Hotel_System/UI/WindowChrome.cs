using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_System.UI
{
    internal static class WindowChrome
    {
        public const int StripWidth = 132;

        public static void AddWindowButtons(Form form, Control host, Action closeAction, int top = 10, int right = 12)
        {
            Guna2Button minimizeButton = CreateButton("_");
            Guna2Button maximizeButton = CreateButton("□");
            Guna2Button closeButton = CreateButton("X", isClose: true);

            minimizeButton.Click += (_, _) => form.WindowState = FormWindowState.Minimized;
            maximizeButton.Click += (_, _) => ToggleMaximize(form);
            closeButton.Click += (_, _) => closeAction();

            host.Controls.Add(minimizeButton);
            host.Controls.Add(maximizeButton);
            host.Controls.Add(closeButton);

            void LayoutButtons()
            {
                int x = host.ClientSize.Width - right - StripWidth;
                minimizeButton.Location = new Point(x, top);
                maximizeButton.Location = new Point(x + 44, top);
                closeButton.Location = new Point(x + 88, top);
                minimizeButton.BringToFront();
                maximizeButton.BringToFront();
                closeButton.BringToFront();
            }

            host.Resize += (_, _) => LayoutButtons();
            LayoutButtons();
        }

        public static void MatchWindow(Form source, Form target)
        {
            target.StartPosition = FormStartPosition.Manual;

            if (source.WindowState == FormWindowState.Maximized)
            {
                target.Bounds = Screen.FromControl(source).WorkingArea;
                target.WindowState = FormWindowState.Maximized;
                return;
            }

            target.Bounds = source.Bounds;
            target.WindowState = source.WindowState;
        }

        private static Guna2Button CreateButton(string text, bool isClose = false)
        {
            return new Guna2Button
            {
                Animated = true,
                BorderRadius = 6,
                Cursor = Cursors.Hand,
                FillColor = Color.Transparent,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(58, 73, 96),
                HoverState =
                {
                    FillColor = isClose ? Color.FromArgb(232, 73, 73) : Color.FromArgb(228, 236, 247),
                    ForeColor = isClose ? Color.White : Color.FromArgb(31, 42, 62)
                },
                Size = new Size(40, 30),
                Text = text
            };
        }

        private static void ToggleMaximize(Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
                return;
            }

            form.WindowState = FormWindowState.Maximized;
        }
    }
}
