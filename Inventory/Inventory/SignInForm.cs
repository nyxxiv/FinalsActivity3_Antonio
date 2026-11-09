using System.Data.OleDb;
namespace inventory;
public partial class SignInForm : Form
{
    public SignInForm()
    {
        InitializeComponent();
        Shown += (s, e) => txtUsername.Focus();
        Resize += (s, e) => ArrangeResponsive();
        ArrangeResponsive();
    }

    private void ArrangeResponsive()
    {
        if (pnlForm is null || pnlBrand is null) return;
        bool compact = ClientSize.Width < 760;
        pnlBrand.Visible = !compact;
        pnlBrand.Width = compact ? 0 : Math.Clamp((int)(ClientSize.Width * 0.34), 280, 420);
        int formWidth = pnlForm.ClientSize.Width;
        int contentWidth = Math.Min(440, Math.Max(260, formWidth - 48));
        int left = Math.Max(24, (formWidth - contentWidth) / 2);
        int top = Math.Max(40, (pnlForm.ClientSize.Height - 390) / 2);
        lblTitle.Location = new Point(left, top);
        lblSubtitle.Location = new Point(left + 4, top + 50);
        lblUsername.Location = new Point(left + 4, top + 112);
        txtUsername.SetBounds(left, top + 140, contentWidth, 36);
        lblPassword.Location = new Point(left + 4, top + 198);
        txtPassword.SetBounds(left, top + 226, contentWidth, 36);
        btnSignIn.SetBounds(left, top + 290, contentWidth, 46);
        linkRegister.Location = new Point(left + Math.Max(0, (contentWidth - linkRegister.Width) / 2), top + 355);
        if (!compact)
        {
            int brandLeft = Math.Max(24, (pnlBrand.Width - lblBrand.Width) / 2);
            lblBrand.Location = new Point(brandLeft, Math.Max(100, (ClientSize.Height - 300) / 2));
            lblProduct.Location = new Point(brandLeft + 3, lblBrand.Bottom + 8);
            lblTagline.Location = new Point(brandLeft + 3, lblProduct.Bottom + 45);
            lblFeatures.Location = new Point(brandLeft + 3, lblTagline.Bottom + 35);
        }
    }
    private void linkRegister_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) { using var register = new RegisterForm(); Hide(); register.ShowDialog(this); Show(); }
    private void btnSignIn_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim(), password = txtPassword.Text;
        if (username == "" || password == "") { MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        try {
            string fullName;
            using (OleDbConnection con = Database.GetConnection()) { con.Open(); using OleDbCommand cmd = new OleDbCommand("SELECT * FROM Users WHERE Username = ?", con); cmd.Parameters.AddWithValue("@Username", username); using OleDbDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) { MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                string storedHash = reader["PasswordHash"].ToString() ?? ""; fullName = reader["FullName"].ToString() ?? ""; bool isActive = Convert.ToBoolean(reader["IsActive"]);
                if (!PasswordHelper.VerifyPassword(password, storedHash)) { MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (!isActive) { MessageBox.Show("Your account is inactive. Please contact the administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            MessageBox.Show($"Welcome, {fullName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); txtPassword.Clear(); using var dashboard = new DashboardForm(fullName); Hide(); dashboard.ShowDialog(this); Show();
        } catch (Exception ex) { Show(); MessageBox.Show("An error occurred while signing in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
}
