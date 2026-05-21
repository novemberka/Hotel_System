using System.Drawing.Drawing2D;

namespace Hotel_System
{
    internal class DashboardDonutControl : Control
    {
        private int percent;

        public DashboardDonutControl()
        {
            DoubleBuffered = true;
            Size = new Size(118, 118);
        }

        public int Percent
        {
            get => percent;
            set
            {
                percent = Math.Max(0, Math.Min(100, value));
                Invalidate();
            }
        }

        public Color AccentColor { get; set; } = Color.FromArgb(100, 150, 224);
        public Color TrackColor { get; set; } = Color.FromArgb(229, 238, 250);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new(12, 12, Width - 24, Height - 24);
            using Pen trackPen = new(TrackColor, 15) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            using Pen accentPen = new(AccentColor, 15) { StartCap = LineCap.Round, EndCap = LineCap.Round };

            e.Graphics.DrawArc(trackPen, bounds, -90, 360);
            e.Graphics.DrawArc(accentPen, bounds, -90, Percent * 3.6F);

            TextRenderer.DrawText(
                e.Graphics,
                $"{Percent}%",
                new Font("Segoe UI", 13F, FontStyle.Bold),
                ClientRectangle,
                Color.FromArgb(70, 78, 97),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
