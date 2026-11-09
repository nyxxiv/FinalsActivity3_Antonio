namespace inventory;

public partial class DashboardForm : Form
{
    private const int WideBreakpoint = 900;

    public DashboardForm()
    {
        InitializeComponent();
        Shown += (s, e) => { ArrangeDashboard(); LoadStats(); };
        Resize += (s, e) => ArrangeDashboard();
    }

    public DashboardForm(string fullName) : this()
    {
        lblWelcome.Text = $"Welcome, {fullName}!";
    }

    private void ArrangeDashboard()
    {
        if (pnlContent is null || pnlProducts is null) return;

        int width = Math.Max(280, pnlContent.ClientSize.Width - pnlContent.Padding.Horizontal);
        pnlContent.Padding = new Padding(width < 600 ? 16 : 28);
        if (pnlHeader.ClientSize.Width < 620)
        {
            lblWelcome.Location = new Point(28, 52);
            lblBrand.Location = new Point(28, 12);
            lblCaption.Visible = false;
            pnlHeader.Height = 100;
        }
        else
        {
            lblBrand.Location = new Point(28, 17);
            lblWelcome.Location = new Point(245, 19);
            lblCaption.Visible = true;
            pnlHeader.Height = 92;
        }
        btnLogout.Location = new Point(pnlHeader.ClientSize.Width - btnLogout.Width - 24, 25);
        int gap = width < 620 ? 10 : 16;
        int columns = width >= 1120 ? 4 : width >= 650 ? 2 : 1;
        int cardWidth = Math.Max(220, (width - gap * (columns - 1)) / columns);
        int cardHeight = 112;
        int top = 112;

        Control[] stats = { pnlProducts, pnlLowStock, pnlValue, pnlTransactions };
        for (int i = 0; i < stats.Length; i++)
        {
            int row = i / columns;
            int col = i % columns;
            stats[i].SetBounds(col * (cardWidth + gap), top + row * (cardHeight + gap),
                cardWidth, cardHeight);
        }

        int statRows = (stats.Length + columns - 1) / columns;
        int sectionTop = top + statRows * (cardHeight + gap) + 18;
        int sectionGap = gap;
        int sectionColumns = width >= 1050 ? 3 : width >= 650 ? 2 : 1;
        int sectionWidth = Math.Max(250, (width - sectionGap * (sectionColumns - 1)) / sectionColumns);
        Control[] sections = { pnlPanelProducts, pnlPanelTransactions, pnlPanelActivity };
        for (int i = 0; i < sections.Length; i++)
        {
            int row = i / sectionColumns;
            int col = i % sectionColumns;
            sections[i].SetBounds(col * (sectionWidth + sectionGap),
                sectionTop + row * 260, sectionWidth, 240);
            foreach (Control child in sections[i].Controls)
            {
                if (child is Label label && label.Name.Contains("Empty"))
                    label.SetBounds(15, 65, Math.Max(180, sectionWidth - 30), 145);
            }
        }

        lblOverview.Location = new Point(0, 18);
        lblOverviewSub.Location = new Point(3, 58);
        pnlContent.AutoScrollMinSize = new Size(0, sectionTop +
            ((sections.Length + sectionColumns - 1) / sectionColumns) * 260 + 20);
    }

    private void LoadStats()
    {
        try
        {
            lblProductsValue.Text = Database.ReadScalar("SELECT COUNT(*) FROM Products").ToString("N0");
            lblLowValue.Text = Database.ReadScalar("SELECT COUNT(*) FROM Products WHERE Quantity <= ReorderLevel").ToString("N0");
            lblValueValue.Text = Database.ReadScalar("SELECT SUM(Quantity * UnitPrice) FROM Products").ToString("C0");
            lblTransValue.Text = Database.ReadScalar("SELECT COUNT(*) FROM StockTransactions").ToString("N0");
        }
        catch
        {
            lblProductsValue.Text = lblLowValue.Text = lblValueValue.Text = lblTransValue.Text = "-";
        }
    }

    private void btnLogout_Click(object? sender, EventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            Close();
    }
}
