#nullable disable
namespace inventory;
partial class RegisterForm
{
 private System.ComponentModel.IContainer components = null;
 protected override void Dispose(bool disposing) { if(disposing && components != null) components.Dispose(); base.Dispose(disposing); }
 private void InitializeComponent()
 {
  pnlBrand=new Panel(); pnlForm=new Panel(); lblBrand=new Label(); lblProduct=new Label(); lblTagline=new Label(); lblTitle=new Label(); lblSubtitle=new Label(); lblFullName=new Label(); txtFullName=new TextBox(); lblUsername=new Label(); txtUsername=new TextBox(); lblPassword=new Label(); txtPassword=new TextBox(); lblConfirm=new Label(); txtConfirm=new TextBox(); btnRegister=new Button(); linkSignIn=new LinkLabel(); SuspendLayout();
  pnlBrand.BackColor=Color.FromArgb(25,49,79); pnlBrand.Dock=DockStyle.Left; pnlBrand.Width=360; pnlBrand.Name="pnlBrand";
  lblBrand.AutoSize=true; lblBrand.Font=new Font("Segoe UI",28F,FontStyle.Bold); lblBrand.ForeColor=Color.White; lblBrand.Location=new Point(45,190); lblBrand.Text="Inventory"; lblBrand.Name="lblBrand";
  lblProduct.AutoSize=true; lblProduct.Font=new Font("Segoe UI",14F); lblProduct.ForeColor=Color.FromArgb(190,211,232); lblProduct.Location=new Point(48,240); lblProduct.Text="Management System"; lblProduct.Name="lblProduct";
  lblTagline.AutoSize=true; lblTagline.Font=new Font("Segoe UI",10.5F); lblTagline.ForeColor=Color.White; lblTagline.Location=new Point(48,300); lblTagline.Text="Create your account to get started."; lblTagline.Name="lblTagline"; pnlBrand.Controls.AddRange(new Control[]{lblBrand,lblProduct,lblTagline});
  pnlForm.Dock=DockStyle.Fill; pnlForm.BackColor=Color.FromArgb(246,248,251); pnlForm.Name="pnlForm";
  lblTitle.AutoSize=true; lblTitle.Font=new Font("Segoe UI",23F,FontStyle.Bold); lblTitle.ForeColor=Color.FromArgb(31,41,55); lblTitle.Location=new Point(75,48); lblTitle.Text="Create your account"; lblTitle.Name="lblTitle";
  lblSubtitle.AutoSize=true; lblSubtitle.Font=new Font("Segoe UI",10F); lblSubtitle.ForeColor=Color.FromArgb(107,114,128); lblSubtitle.Location=new Point(79,94); lblSubtitle.Text="Fill in your details to get started."; lblSubtitle.Name="lblSubtitle";
  lblFullName.AutoSize=true; lblFullName.Font=new Font("Segoe UI",9.5F,FontStyle.Bold); lblFullName.Location=new Point(80,145); lblFullName.Text="Full name"; lblFullName.Name="lblFullName";
  txtFullName.Font=new Font("Segoe UI",10.5F); txtFullName.Location=new Point(80,170); txtFullName.Size=new Size(420,30); txtFullName.Name="txtFullName"; txtFullName.TabIndex=0;
  lblUsername.AutoSize=true; lblUsername.Font=new Font("Segoe UI",9.5F,FontStyle.Bold); lblUsername.Location=new Point(80,215); lblUsername.Text="Username"; lblUsername.Name="lblUsername";
  txtUsername.Font=new Font("Segoe UI",10.5F); txtUsername.Location=new Point(80,240); txtUsername.Size=new Size(420,30); txtUsername.Name="txtUsername"; txtUsername.TabIndex=1;
  lblPassword.AutoSize=true; lblPassword.Font=new Font("Segoe UI",9.5F,FontStyle.Bold); lblPassword.Location=new Point(80,285); lblPassword.Text="Password"; lblPassword.Name="lblPassword";
  txtPassword.Font=new Font("Segoe UI",10.5F); txtPassword.Location=new Point(80,310); txtPassword.Size=new Size(420,30); txtPassword.UseSystemPasswordChar=true; txtPassword.Name="txtPassword"; txtPassword.TabIndex=2;
  lblConfirm.AutoSize=true; lblConfirm.Font=new Font("Segoe UI",9.5F,FontStyle.Bold); lblConfirm.Location=new Point(80,355); lblConfirm.Text="Confirm password"; lblConfirm.Name="lblConfirm";
  txtConfirm.Font=new Font("Segoe UI",10.5F); txtConfirm.Location=new Point(80,380); txtConfirm.Size=new Size(420,30); txtConfirm.UseSystemPasswordChar=true; txtConfirm.Name="txtConfirm"; txtConfirm.TabIndex=3;
  btnRegister.BackColor=Color.FromArgb(37,99,235); btnRegister.FlatStyle=FlatStyle.Flat; btnRegister.FlatAppearance.BorderSize=0; btnRegister.ForeColor=Color.White; btnRegister.Font=new Font("Segoe UI",10.5F,FontStyle.Bold); btnRegister.Location=new Point(80,435); btnRegister.Size=new Size(420,43); btnRegister.Text="Create Account"; btnRegister.Name="btnRegister"; btnRegister.TabIndex=4; btnRegister.Click+=btnRegister_Click;
  linkSignIn.AutoSize=true; linkSignIn.Font=new Font("Segoe UI",10F); linkSignIn.Location=new Point(190,500); linkSignIn.Text="Already have an account? Sign in here."; linkSignIn.LinkArea=new LinkArea(25,13); linkSignIn.Name="linkSignIn"; linkSignIn.TabIndex=5; linkSignIn.LinkClicked+=linkSignIn_LinkClicked;
  pnlForm.Controls.AddRange(new Control[]{lblTitle,lblSubtitle,lblFullName,txtFullName,lblUsername,txtUsername,lblPassword,txtPassword,lblConfirm,txtConfirm,btnRegister,linkSignIn});
  AutoScaleDimensions=new SizeF(7F,15F); AutoScaleMode=AutoScaleMode.Font; BackColor=Color.FromArgb(246,248,251); ClientSize=new Size(1050,650); MinimumSize=new Size(560,560); StartPosition=FormStartPosition.CenterScreen; AcceptButton=btnRegister; Text="Register"; Controls.Add(pnlForm); Controls.Add(pnlBrand); Name="RegisterForm"; ResumeLayout(false);
 }
 private Panel pnlBrand,pnlForm; private Label lblBrand,lblProduct,lblTagline,lblTitle,lblSubtitle,lblFullName,lblUsername,lblPassword,lblConfirm; private TextBox txtFullName,txtUsername,txtPassword,txtConfirm; private Button btnRegister; private LinkLabel linkSignIn;
}
