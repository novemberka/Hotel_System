using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using Hotel_System.UI;

namespace Hotel_System
{
    public partial class Dashboard : Form
    {
        private IReadOnlyList<IconButton> navigationButtons = Array.Empty<IconButton>();
        private IconButton? activeMenuButton;
        private Label? userNameLabel;
        private Label? userRoleLabel;
        private Label? sidebarBrandLabel;
        private Label? sidebarBrandSubLabel;
        private Label? sidebarSectionLabel;
        private Guna2Panel? sidebarBrandPill;
        private Panel? activeMenuIndicator;
        private Guna2Button? addNewButton;
        private Guna2TextBox? searchBox;
        private IconPictureBox? notificationIcon;
        private IconPictureBox? headerLogoutIcon;
        private Panel? headerDivider;
        private bool headerResizeHooked;

        public Dashboard(string fullName, string role, string imgPath)
        {
            InitializeComponent();

            ApplyShellDesign(fullName, role);
            LoadUserControl(new DashboardControl(), "Dashboard", dashboard_menu);

            if (!string.IsNullOrWhiteSpace(imgPath) && File.Exists(imgPath))
            {
                guna2CirclePictureBox1.Image = Image.FromFile(imgPath);
            }
        }

        private void LoadUserControl(UserControl control, string title, IconButton? menuButton)
        {
            Content.SuspendLayout();

            foreach (Control child in Content.Controls.Cast<Control>().ToList())
            {
                child.Dispose();
            }

            Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.Margin = Padding.Empty;
            UiTheme.EnableResponsivePage(control);
            Content.Controls.Add(control);
            Content.ResumeLayout();

            lblTittle.Text = title;
            SetActiveMenu(menuButton);
        }

        private void ApplyShellDesign(string fullName, string role)
        {
            navigationButtons = new[]
            {
                dashboard_menu,
                booking_menu,
                room_menu,
                checkin_checkout_menu,
                customer_menu,
                payment_menu
            };

            Text = "Hotel Management System";
            StartPosition = FormStartPosition.CenterScreen;
            MinimumSize = new Size(1180, 720);
            Size = new Size(1360, 820);
            BackColor = Color.FromArgb(236, 243, 252);

            panel1.BackColor = Color.FromArgb(20, 34, 54);
            panel1.Width = 256;
            panel1.Padding = new Padding(0, 128, 0, 24);
            panel1.Resize += (_, _) => ApplySidebarShape();
            panel1.Paint -= Sidebar_Paint;
            panel1.Paint += Sidebar_Paint;

            pictureBox1.Visible = false;
            BuildSidebarBrand();

            if (logout_menu.Parent == tableLayoutPanel1)
            {
                tableLayoutPanel1.Controls.Remove(logout_menu);
                panel1.Controls.Add(logout_menu);
            }

            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Height = 348;
            tableLayoutPanel1.Padding = new Padding(0, 0, 0, 0);
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = 6;
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            }

            foreach (IconButton button in navigationButtons.Append(logout_menu))
            {
                StyleReferenceSidebarButton(button);
            }

            logout_menu.IconChar = IconChar.RightFromBracket;
            logout_menu.Text = "Logout";
            logout_menu.Dock = DockStyle.Bottom;
            logout_menu.Height = 54;
            logout_menu.Margin = new Padding(18, 0, 18, 8);
            logout_menu.FlatAppearance.MouseOverBackColor = Color.FromArgb(38, 58, 88);
            logout_menu.BackColor = Color.FromArgb(25, 40, 62);

            dashboard_menu.Text = "Dashboard";
            booking_menu.Text = "Bookings";
            room_menu.Text = "Rooms";
            checkin_checkout_menu.Text = "Check In / Out";
            customer_menu.Text = "Customers";
            payment_menu.Text = "Payments";

            panel2.Height = 78;
            panel2.BackColor = Color.White;
            contentPanel.BackColor = Color.White;
            contentPanel.Padding = new Padding(28, 0, 28, 0);
            Content.BackColor = UiTheme.PageBackground;
            Content.AutoScroll = false;
            Content.Padding = new Padding(26, 22, 26, 28);

            BuildHeaderControls();
            lblTittle.AutoSize = true;
            lblTittle.Visible = false;

            profile.Visible = false;
            BuildUserProfile(fullName, role);
            if (!headerResizeHooked)
            {
                contentPanel.Resize += (_, _) => LayoutHeaderControls();
                headerResizeHooked = true;
            }
            LayoutHeaderControls();
            ApplySidebarShape();
            PositionActiveIndicator();
        }

        private void BuildSidebarBrand()
        {
            if (sidebarBrandLabel != null)
            {
                return;
            }

            sidebarBrandPill = new Guna2Panel
            {
                BackColor = Color.Transparent,
                BorderColor = Color.FromArgb(62, 91, 130),
                BorderRadius = 20,
                BorderThickness = 1,
                FillColor = Color.FromArgb(28, 46, 73),
                Location = new Point(18, 18),
                Size = new Size(220, 76)
            };

            sidebarBrandLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 15.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 13),
                Text = "HotelUX"
            };

            sidebarBrandSubLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(180, 199, 226),
                Location = new Point(22, 45),
                Text = "Hotel management"
            };

            sidebarSectionLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(132, 154, 185),
                Location = new Point(28, 106),
                Size = new Size(180, 18),
                Text = "WORKSPACE"
            };

            activeMenuIndicator = new Panel
            {
                BackColor = Color.FromArgb(73, 149, 255),
                Size = new Size(4, 28),
                Visible = false
            };

            sidebarBrandPill.Controls.Add(sidebarBrandLabel);
            sidebarBrandPill.Controls.Add(sidebarBrandSubLabel);
            panel1.Controls.Add(sidebarBrandPill);
            panel1.Controls.Add(sidebarSectionLabel);
            panel1.Controls.Add(activeMenuIndicator);
            sidebarBrandPill.BringToFront();
            sidebarBrandLabel.BringToFront();
            sidebarBrandSubLabel?.BringToFront();
            sidebarSectionLabel.BringToFront();
        }

        private static void StyleReferenceSidebarButton(IconButton button)
        {
            button.BackColor = Color.FromArgb(20, 34, 54);
            button.Cursor = Cursors.Hand;
            button.Dock = DockStyle.Fill;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(35, 55, 84);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(31, 49, 77);
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button.ForeColor = Color.FromArgb(224, 234, 248);
            button.IconColor = Color.FromArgb(155, 178, 209);
            button.IconSize = 17;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(30, 0, 0, 0);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.Margin = new Padding(16, 3, 18, 3);
        }

        private void BuildHeaderControls()
        {
            if (addNewButton != null)
            {
                return;
            }

            addNewButton = new Guna2Button
            {
                Animated = true,
                BorderColor = Color.FromArgb(214, 226, 243),
                BorderRadius = 9,
                BorderThickness = 1,
                Cursor = Cursors.Hand,
                FillColor = Color.White,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = UiTheme.SidebarActive,
                Location = new Point(28, 20),
                Size = new Size(124, 40),
                Text = "+  Add New"
            };

            searchBox = new Guna2TextBox
            {
                BorderColor = Color.FromArgb(229, 237, 249),
                BorderThickness = 1,
                BorderRadius = 10,
                FillColor = Color.FromArgb(247, 250, 254),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = UiTheme.TextPrimary,
                Location = new Point(176, 20),
                PlaceholderText = "Search...",
                PlaceholderForeColor = Color.FromArgb(162, 174, 192),
                Size = new Size(320, 40)
            };

            notificationIcon = new IconPictureBox
            {
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(149, 168, 196),
                IconChar = IconChar.Bell,
                IconColor = Color.FromArgb(149, 168, 196),
                IconFont = IconFont.Auto,
                IconSize = 19,
                Size = new Size(28, 28)
            };

            headerLogoutIcon = new IconPictureBox
            {
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                ForeColor = Color.FromArgb(149, 168, 196),
                IconChar = IconChar.ArrowRightFromBracket,
                IconColor = Color.FromArgb(149, 168, 196),
                IconFont = IconFont.Auto,
                IconSize = 19,
                Size = new Size(28, 28)
            };
            headerLogoutIcon.Click += logout_menu_Click;

            headerDivider = new Panel
            {
                BackColor = Color.FromArgb(235, 240, 247),
                Size = new Size(1, 50)
            };

            contentPanel.Controls.Add(addNewButton);
            contentPanel.Controls.Add(searchBox);
            contentPanel.Controls.Add(notificationIcon);
            contentPanel.Controls.Add(headerLogoutIcon);
            contentPanel.Controls.Add(headerDivider);
            WindowChrome.AddWindowButtons(this, contentPanel, Application.Exit, top: 9, right: 12);
        }

        private void BuildUserProfile(string fullName, string role)
        {
            string displayName = string.IsNullOrWhiteSpace(fullName) ? "Hotel Admin" : fullName;
            string displayRole = string.IsNullOrWhiteSpace(role) ? "Administrator" : role;

            if (userNameLabel != null && userRoleLabel != null)
            {
                userNameLabel.Text = displayName;
                userRoleLabel.Text = displayRole;
                return;
            }

            userNameLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = UiTheme.TextPrimary,
                Text = displayName
            };

            userRoleLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = UiTheme.TextMuted,
                Text = displayRole
            };

            contentPanel.Controls.Add(userNameLabel);
            contentPanel.Controls.Add(userRoleLabel);
            guna2CirclePictureBox1.Size = new Size(48, 48);
            guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2CirclePictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void LayoutHeaderControls()
        {
            if (userNameLabel == null || userRoleLabel == null)
            {
                return;
            }

            const int rightPadding = 34 + WindowChrome.StripWidth;
            int logoutX = contentPanel.Width - rightPadding - 28;
            int bellX = logoutX - 48;
            int dividerX = bellX - 26;
            int avatarX = dividerX - 86;

            if (notificationIcon != null)
            {
                notificationIcon.Location = new Point(bellX, 25);
            }

            if (headerLogoutIcon != null)
            {
                headerLogoutIcon.Location = new Point(logoutX, 25);
            }

            if (headerDivider != null)
            {
                headerDivider.Location = new Point(dividerX, 13);
            }

            guna2CirclePictureBox1.Location = new Point(avatarX, 14);
            userNameLabel.Location = new Point(avatarX - userNameLabel.Width - 14, 18);
            userRoleLabel.Location = new Point(avatarX - userRoleLabel.Width - 14, 40);
        }

        private void SetActiveMenu(IconButton? menuButton)
        {
            activeMenuButton = menuButton;

            foreach (IconButton button in navigationButtons)
            {
                bool isActive = button == activeMenuButton;
                button.BackColor = isActive ? Color.FromArgb(35, 57, 88) : Color.FromArgb(20, 34, 54);
                button.ForeColor = isActive ? Color.White : Color.FromArgb(224, 234, 248);
                button.IconColor = isActive ? Color.FromArgb(125, 186, 255) : Color.FromArgb(155, 178, 209);
                button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }

            PositionActiveIndicator();
        }

        private void PositionActiveIndicator()
        {
            if (activeMenuButton == null || activeMenuIndicator == null || activeMenuButton.Parent != tableLayoutPanel1)
            {
                if (activeMenuIndicator != null)
                {
                    activeMenuIndicator.Visible = false;
                }
                return;
            }

            Point location = tableLayoutPanel1.PointToScreen(activeMenuButton.Location);
            location = panel1.PointToClient(location);
            activeMenuIndicator.Location = new Point(16, location.Y + Math.Max(8, (activeMenuButton.Height - activeMenuIndicator.Height) / 2));
            activeMenuIndicator.Visible = true;
            activeMenuIndicator.BringToFront();
        }

        private void Sidebar_Paint(object? sender, PaintEventArgs e)
        {
            using LinearGradientBrush brush = new(
                panel1.ClientRectangle,
                Color.FromArgb(22, 40, 66),
                Color.FromArgb(13, 24, 40),
                LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, panel1.ClientRectangle);
        }

        private void ApplySidebarShape()
        {
            if (panel1.Width <= 0 || panel1.Height <= 0)
            {
                return;
            }

            using GraphicsPath path = new();
            int radius = 22;
            Rectangle bounds = new(0, 0, panel1.Width, panel1.Height);
            path.AddLine(bounds.Left, bounds.Top, bounds.Right - radius, bounds.Top);
            path.AddArc(bounds.Right - (radius * 2), bounds.Top, radius * 2, radius * 2, 270, 90);
            path.AddLine(bounds.Right, bounds.Top + radius, bounds.Right, bounds.Bottom - radius);
            path.AddArc(bounds.Right - (radius * 2), bounds.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90);
            path.AddLine(bounds.Right - radius, bounds.Bottom, bounds.Left, bounds.Bottom);
            path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Top);
            path.CloseFigure();
            panel1.Region = new Region(path);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            LoadUserControl(new BookingControl(), "Booking Management", booking_menu);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Checkin_outControl(), "Check-In / Check-Out", checkin_checkout_menu);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardControl(), "Dashboard", dashboard_menu);
        }

        private void room_menu_Click(object sender, EventArgs e)
        {
            LoadUserControl(new RoomControl(), "Room Management", room_menu);
        }

        private void customer_menu_Click(object sender, EventArgs e)
        {
            LoadUserControl(new CustomerControl(), "Customer Management", customer_menu);
        }

        private void payment_menu_Click(object sender, EventArgs e)
        {
            LoadUserControl(new PaymentControl(), "Payment Management", payment_menu);
        }

        private void logout_menu_Click(object? sender, EventArgs e)
        {
            Login login = new();
            login.Show();
            Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            using GraphicsPath gp = new();
            gp.AddEllipse(0, 0, guna2CirclePictureBox1.Width - 1, guna2CirclePictureBox1.Height - 1);
            guna2CirclePictureBox1.Region = new Region(gp);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void profile_Paint(object sender, PaintEventArgs e)
        {
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Content_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
