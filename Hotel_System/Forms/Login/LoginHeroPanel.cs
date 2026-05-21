using System.Drawing.Drawing2D;

namespace Hotel_System
{
    internal class LoginHeroPanel : Panel
    {
        public LoginHeroPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using LinearGradientBrush background = new(
                ClientRectangle,
                Color.FromArgb(13, 84, 184),
                Color.FromArgb(38, 149, 239),
                LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(background, ClientRectangle);

            DrawSoftWave(e.Graphics, Color.FromArgb(75, Color.White), Width - 88, 22, 82);
            DrawSoftWave(e.Graphics, Color.FromArgb(115, Color.White), Width - 66, -6, 72);
            DrawSoftWave(e.Graphics, Color.FromArgb(235, Color.White), Width - 38, -20, 68);
        }

        private void DrawSoftWave(Graphics graphics, Color color, int x, int yOffset, int diameter)
        {
            using SolidBrush brush = new(color);

            for (int y = yOffset; y < Height + diameter; y += diameter - 10)
            {
                graphics.FillEllipse(brush, x, y, diameter, diameter);
            }

            graphics.FillRectangle(brush, x + diameter / 2, 0, Math.Max(0, Width - x), Height);
        }
    }
}
