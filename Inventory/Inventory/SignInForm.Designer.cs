#nullable disable
namespace inventory;
partial class SignInForm
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        pnlBrand = new Panel(); pnlForm = new Panel(); lblBrand = new Label(); lblProduct = new Label(); lblTagline = new Label(); lblFeatures = new Label(); lblTitle = new Label(); lblSubtitle = new Label(); lblUsername = new Label(); txtUsername = new TextBox(); lblPassword = new Label(); txtPassword = new TextBox(); btnSignIn = new Button(); linkRegister = new LinkLabel();
        SuspendLayout();
        pnlBrand.BackColor = Color.FromArgb(25, 49, 79); pnlBrand.Dock = DockStyle.Left; pnlBrand.Width = 420; pnlBrand.Name = "pnlBrand"; pnlBrand.Padding = new Padding(55); 
        lblBrand.AutoSize = true; lblBrand.Font = new Font("Segoe UI", 30F, FontStyle.Bold); lblBrand.ForeColor = Color.White; lblBrand.Location = new Point(55, 155); lblBrand.Text = "Inventory"; lblBrand.Name = "lblBrand";
        lblProduct.AutoSize = true; lblProduct.Font = new Font("Segoe UI", 15F); lblProduct.ForeColor = Color.FromArgb(190, 211, 232); lblProduct.Location = new Point(58, 208); lblProduct.Text = "Management System"; lblProduct.Name = "lblProduct";
        lblTagline.AutoSize = true; lblTagline.Font = new Font("Segoe UI", 11F); lblTagline.ForeColor = Color.FromArgb(205, 218, 232); lblTagline.Location = new Point(58, 280); lblTagline.Text = "Track products, stock and activity in one place."; lblTagline.Name = "lblTagline";
        lblFeatures.AutoSize = true; lblFeatures.Font = new Font("Segoe UI", 10F); lblFeatures.ForeColor = Color.White; lblFeatures.Location = new Point(58, 345); lblFeatures.Text = "• Track products and stock levels\r\n• Spot low stock at a glance\r\n• Keep a complete activity history"; lblFeatures.Name = "lblFeatures"; pnlBrand.Controls.AddRange(new Control[] { lblBrand, lblProduct, lblTagline, lblFeatures });
        pnlForm.Dock = DockStyle.Fill; pnlForm.BackColor = Color.FromArgb(246, 248, 251); pnlForm.Name = "pnlForm";
        lblTitle.AutoSize = true; lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold); lblTitle.ForeColor = Color.FromArgb(31, 41, 55); lblTitle.Location = new Point(95, 130); lblTitle.Text = "Welcome back"; lblTitle.Name = "lblTitle";
        lblSubtitle.AutoSize = true; lblSubtitle.Font = new Font("Segoe UI", 10.5F); lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128); lblSubtitle.Location = new Point(99, 180); lblSubtitle.Text = "Sign in to your account to continue."; lblSubtitle.Name = "lblSubtitle";
        lblUsername.AutoSize = true; lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold); lblUsername.Location = new Point(100, 245); lblUsername.Text = "Username"; lblUsername.Name = "lblUsername";
        txtUsername.Font = new Font("Segoe UI", 11F); txtUsername.Location = new Point(100, 273); txtUsername.Size = new Size(380, 32); txtUsername.Name = "txtUsername"; txtUsername.TabIndex = 0;
        lblPassword.AutoSize = true; lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold); lblPassword.Location = new Point(100, 330); lblPassword.Text = "Password"; lblPassword.Name = "lblPassword";
        txtPassword.Font = new Font("Segoe UI", 11F); txtPassword.Location = new Point(100, 358); txtPassword.Size = new Size(380, 32); txtPassword.UseSystemPasswordChar = true; txtPassword.Name = "txtPassword"; txtPassword.TabIndex = 1;
        btnSignIn.BackColor = Color.FromArgb(37, 99, 235); btnSignIn.FlatStyle = FlatStyle.Flat; btnSignIn.FlatAppearance.BorderSize = 0; btnSignIn.ForeColor = Color.White; btnSignIn.Font = new Font("Segoe UI", 11F, FontStyle.Bold); btnSignIn.Location = new Point(100, 425); btnSignIn.Size = new Size(380, 45); btnSignIn.Text = "Sign In"; btnSignIn.Name = "btnSignIn"; btnSignIn.TabIndex = 2; btnSignIn.Click += btnSignIn_Click;
        linkRegister.AutoSize = true; linkRegister.Font = new Font("Segoe UI", 10F); linkRegister.Location = new Point(177, 495); linkRegister.Text = "Don't have an account? Register here."; linkRegister.LinkArea = new LinkArea(23, 14); linkRegister.Name = "linkRegister"; linkRegister.TabIndex = 3; linkRegister.LinkClicked += linkRegister_LinkClicked;
        pnlForm.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, lblUsername, txtUsername, lblPassword, txtPassword, btnSignIn, linkRegister });
        AutoScaleDimensions = new SizeF(7F, 15F); AutoScaleMode = AutoScaleMode.Font; BackColor = Color.FromArgb(246, 248, 251); ClientSize = new Size(1100, 700); MinimumSize = new Size(560, 500); StartPosition = FormStartPosition.CenterScreen; Text = "Inventory Management System"; AcceptButton = btnSignIn; Controls.Add(pnlForm); Controls.Add(pnlBrand); Name = "SignInForm"; ResumeLayout(false);
    }
    private Panel pnlBrand, pnlForm; private Label lblBrand, lblProduct, lblTagline, lblFeatures, lblTitle, lblSubtitle, lblUsername, lblPassword; private TextBox txtUsername, txtPassword; private Button btnSignIn; private LinkLabel linkRegister;
}
