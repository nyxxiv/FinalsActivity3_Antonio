using System.Data.OleDb;

namespace inventory;

public partial class RegisterForm : Form
{

    public RegisterForm()
    {
        InitializeComponent();
        Shown += (s, e) => txtFullName.Focus();
        Resize += (s, e) => ArrangeResponsive();
        ArrangeResponsive();
    }

    private void ArrangeResponsive()
    {
        if (pnlForm is null || pnlBrand is null) return;
        bool compact = ClientSize.Width < 760;
        pnlBrand.Visible = !compact;
        pnlBrand.Width = compact ? 0 : Math.Clamp((int)(ClientSize.Width * 0.32), 260, 360);
        int formWidth = pnlForm.ClientSize.Width;
        int contentWidth = Math.Min(460, Math.Max(260, formWidth - 48));
        int left = Math.Max(24, (formWidth - contentWidth) / 2);
        int top = Math.Max(24, (pnlForm.ClientSize.Height - 510) / 2);
        lblTitle.Location = new Point(left, top);
        lblSubtitle.Location = new Point(left + 4, top + 46);
        Control[] labels = { lblFullName, lblUsername, lblPassword, lblConfirm };
        Control[] inputs = { txtFullName, txtUsername, txtPassword, txtConfirm };
        for (int i = 0; i < labels.Length; i++)
        {
            int y = top + 100 + i * 76;
            labels[i].Location = new Point(left + 4, y);
            inputs[i].SetBounds(left, y + 25, contentWidth, 34);
        }
        btnRegister.SetBounds(left, top + 410, contentWidth, 44);
        linkSignIn.Location = new Point(left + Math.Max(0, (contentWidth - linkSignIn.Width) / 2), top + 470);
        if (!compact)
        {
            int brandLeft = Math.Max(24, (pnlBrand.Width - lblBrand.Width) / 2);
            lblBrand.Location = new Point(brandLeft, Math.Max(100, (ClientSize.Height - 250) / 2));
            lblProduct.Location = new Point(brandLeft + 3, lblBrand.Bottom + 8);
            lblTagline.Location = new Point(brandLeft + 3, lblProduct.Bottom + 45);
        }
    }

    private void linkSignIn_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) => Close();

    private void btnRegister_Click(object? sender, EventArgs e)
    {
        string fullName = txtFullName.Text.Trim();
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text;
        string confirmPassword = txtConfirm.Text;

        if (fullName == "" || username == "" || password == "" || confirmPassword == "")
        {
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (password.Length < 8)
        {
            MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            using OleDbConnection con = Database.GetConnection();
            con.Open();

            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = ?";
            using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, con))
            {
                checkCmd.Parameters.AddWithValue("@Username", username);
                int userCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string query = @"INSERT INTO Users (Username, PasswordHash, FullName, UserRole, IsActive) VALUES (?, ?, ?, ?, ?)";
            using (OleDbCommand cmd = new OleDbCommand(query, con))
            {
                string passwordHash = PasswordHelper.HashPassword(password);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@UserRole", "User");
                cmd.Parameters.AddWithValue("@IsActive", true);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("User registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to register user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred while registering the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
