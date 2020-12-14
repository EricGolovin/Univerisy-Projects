
namespace CourseWork_Atelie
{
    partial class UserRegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.surnameGroupBox = new System.Windows.Forms.GroupBox();
            this.parentNameGroupBox = new System.Windows.Forms.GroupBox();
            this.emailGroupBox = new System.Windows.Forms.GroupBox();
            this.phoneNumberGroupBox = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.parentNameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.nameGroupBox.SuspendLayout();
            this.surnameGroupBox.SuspendLayout();
            this.parentNameGroupBox.SuspendLayout();
            this.emailGroupBox.SuspendLayout();
            this.phoneNumberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.nameGroupBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.surnameGroupBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.parentNameGroupBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.emailGroupBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.phoneNumberGroupBox, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1178, 744);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.AutoSize = true;
            this.nameGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameGroupBox.Location = new System.Drawing.Point(128, 210);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(394, 59);
            this.nameGroupBox.TabIndex = 0;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // surnameGroupBox
            // 
            this.surnameGroupBox.AutoSize = true;
            this.surnameGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.surnameGroupBox.Controls.Add(this.surnameTextBox);
            this.surnameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surnameGroupBox.Location = new System.Drawing.Point(128, 305);
            this.surnameGroupBox.Name = "surnameGroupBox";
            this.surnameGroupBox.Size = new System.Drawing.Size(394, 59);
            this.surnameGroupBox.TabIndex = 1;
            this.surnameGroupBox.TabStop = false;
            this.surnameGroupBox.Text = "Surname";
            // 
            // parentNameGroupBox
            // 
            this.parentNameGroupBox.AutoSize = true;
            this.parentNameGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.parentNameGroupBox.Controls.Add(this.parentNameTextBox);
            this.parentNameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentNameGroupBox.Location = new System.Drawing.Point(128, 400);
            this.parentNameGroupBox.Name = "parentNameGroupBox";
            this.parentNameGroupBox.Size = new System.Drawing.Size(394, 59);
            this.parentNameGroupBox.TabIndex = 2;
            this.parentNameGroupBox.TabStop = false;
            this.parentNameGroupBox.Text = "Parent Name";
            // 
            // emailGroupBox
            // 
            this.emailGroupBox.AutoSize = true;
            this.emailGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.emailGroupBox.Controls.Add(this.emailTextBox);
            this.emailGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailGroupBox.Location = new System.Drawing.Point(654, 210);
            this.emailGroupBox.Name = "emailGroupBox";
            this.emailGroupBox.Size = new System.Drawing.Size(394, 59);
            this.emailGroupBox.TabIndex = 3;
            this.emailGroupBox.TabStop = false;
            this.emailGroupBox.Text = "Email";
            // 
            // phoneNumberGroupBox
            // 
            this.phoneNumberGroupBox.AutoSize = true;
            this.phoneNumberGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.phoneNumberGroupBox.Controls.Add(this.phoneNumberTextBox);
            this.phoneNumberGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phoneNumberGroupBox.Location = new System.Drawing.Point(654, 305);
            this.phoneNumberGroupBox.Name = "phoneNumberGroupBox";
            this.phoneNumberGroupBox.Size = new System.Drawing.Size(394, 59);
            this.phoneNumberGroupBox.TabIndex = 4;
            this.phoneNumberGroupBox.TabStop = false;
            this.phoneNumberGroupBox.Text = "Phone Number";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTextBox.Location = new System.Drawing.Point(3, 22);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(388, 26);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.surnameTextBox.Location = new System.Drawing.Point(3, 22);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(388, 26);
            this.surnameTextBox.TabIndex = 0;
            this.surnameTextBox.TextChanged += new System.EventHandler(this.surnameTextBox_TextChanged);
            // 
            // parentNameTextBox
            // 
            this.parentNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentNameTextBox.Location = new System.Drawing.Point(3, 22);
            this.parentNameTextBox.Name = "parentNameTextBox";
            this.parentNameTextBox.Size = new System.Drawing.Size(388, 26);
            this.parentNameTextBox.TabIndex = 0;
            this.parentNameTextBox.TextChanged += new System.EventHandler(this.parentNameTextBox_TextChanged);
            // 
            // emailTextBox
            // 
            this.emailTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailTextBox.Location = new System.Drawing.Point(3, 22);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(388, 26);
            this.emailTextBox.TabIndex = 0;
            this.emailTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phoneNumberTextBox.Location = new System.Drawing.Point(3, 22);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(388, 26);
            this.phoneNumberTextBox.TabIndex = 0;
            this.phoneNumberTextBox.TextChanged += new System.EventHandler(this.phoneNumberTextBox_TextChanged);
            // 
            // UserRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserRegistrationForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.surnameGroupBox.ResumeLayout(false);
            this.surnameGroupBox.PerformLayout();
            this.parentNameGroupBox.ResumeLayout(false);
            this.parentNameGroupBox.PerformLayout();
            this.emailGroupBox.ResumeLayout(false);
            this.emailGroupBox.PerformLayout();
            this.phoneNumberGroupBox.ResumeLayout(false);
            this.phoneNumberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.GroupBox surnameGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.GroupBox parentNameGroupBox;
        private System.Windows.Forms.TextBox parentNameTextBox;
        private System.Windows.Forms.GroupBox emailGroupBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.GroupBox phoneNumberGroupBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
    }
}