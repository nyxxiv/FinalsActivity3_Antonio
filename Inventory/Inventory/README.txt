INVENTORY MANAGEMENT SYSTEM
============================

RESPONSIVE UPDATE
-----------------
The dashboard, sign-in, and registration forms now rearrange their layouts
when the window is resized. The dashboard changes the number of statistic
cards and content columns according to the available width. The authentication
forms hide the decorative brand panel on narrow windows and center the form
fields in the available space.

EDITING THE DESIGN IN VISUAL STUDIO
-----------------------------------
The screens use ordinary Windows Forms controls. You can edit them in the
Visual Studio Windows Forms Designer:

1. Open inventory.csproj in Visual Studio.
2. In Solution Explorer, open DashboardForm.cs, SignInForm.cs, or
   RegisterForm.cs and choose View Designer.
3. Select a control in the designer or Document Outline.
4. Change its properties in the Properties window (Text, BackColor, ForeColor,
   Font, Size, Padding, Name, etc.).
5. Save and build the project.

The designer files (*Form.Designer.cs) contain the visual control setup.
Avoid editing those files manually unless you are comfortable with WinForms.
The responsive positioning logic is in DashboardForm.cs, SignInForm.cs, and
RegisterForm.cs. If you rename controls in the designer, update the matching
references in those code-behind files too.

THEME COLORS
------------
Shared theme colors are defined in Theme.cs. Change the values there to
customize the shared palette. Some existing form controls use direct Color
values in their Designer files; those can be changed individually in the
Properties window or in the designer setup code.

DATABASE
--------
Database.cs contains the database connection configuration. Keep your
database file configured as it was in the original project. If the Access
database cannot be found on another computer, update the path in Database.cs.

NOTES
-----
- The original login, registration, password hashing, and database logic
  has been preserved.
- Standard controls are used so individual elements remain editable.
- The project targets .NET 10 for Windows and requires Windows Forms support.
