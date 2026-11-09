using System.Drawing.Drawing2D;

namespace inventory;

public static class Theme
{
    public static readonly Color Background = Color.FromArgb(243, 245, 250);
    public static readonly Color Surface = Color.White;
    public static readonly Color InputFill = Color.FromArgb(248, 250, 252);
    public static readonly Color Border = Color.FromArgb(226, 232, 240);
    public static readonly Color Text = Color.FromArgb(15, 23, 42);
    public static readonly Color Muted = Color.FromArgb(100, 116, 139);
    public static readonly Color Primary = Color.FromArgb(67, 56, 202);
    public static readonly Color PrimaryHover = Color.FromArgb(55, 48, 163);
    public static readonly Color PrimaryPressed = Color.FromArgb(49, 46, 129);
    public static readonly Color BrandStart = Color.FromArgb(15, 23, 74);
    public static readonly Color BrandEnd = Color.FromArgb(55, 48, 163);
    public static readonly Color BrandText = Color.FromArgb(199, 210, 254);
    public static readonly Color Success = Color.FromArgb(22, 163, 74);
    public static readonly Color Warning = Color.FromArgb(217, 119, 6);
    public static readonly Color Info = Color.FromArgb(2, 132, 199);

    public const string Sans = "Segoe UI";
    public const string SansSemibold = "Segoe UI Semibold";

    public static Font Create(float size, FontStyle style = FontStyle.Regular) => new Font(Sans, size, style);

    public static Font CreateSemibold(float size) => new Font(SansSemibold, size, FontStyle.Regular);

    public static float Dpi(Control control) => control.DeviceDpi / 96f;

    public static float ScaleFor(Control control)
    {
        float raw = control.ClientSize.Width / (1280f * Dpi(control));
        return MathF.Round(Math.Clamp(raw, 0.9f, 1.35f) * 20f) / 20f;
    }

    public static GraphicsPath RoundedRect(RectangleF bounds, float radius)
    {
        var path = new GraphicsPath();
        float diameter = Math.Min(radius * 2f, Math.Min(bounds.Width, bounds.Height));
        if (diameter < 1f)
        {
            path.AddRectangle(bounds);
            return path;
        }
        path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();
        return path;
    }
}
