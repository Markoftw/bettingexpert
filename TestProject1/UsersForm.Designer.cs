namespace TestProject1
{
    partial class UsersForm
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
            this.addUser = new System.Windows.Forms.Button();
            this.remUser = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.usersList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // addUser
            // 
            this.addUser.Location = new System.Drawing.Point(37, 32);
            this.addUser.Name = "addUser";
            this.addUser.Size = new System.Drawing.Size(75, 23);
            this.addUser.TabIndex = 0;
            this.addUser.Text = "Add";
            this.addUser.UseVisualStyleBackColor = true;
            this.addUser.Click += new System.EventHandler(this.addUser_Click);
            // 
            // remUser
            // 
            this.remUser.Location = new System.Drawing.Point(131, 32);
            this.remUser.Name = "remUser";
            this.remUser.Size = new System.Drawing.Size(75, 23);
            this.remUser.TabIndex = 1;
            this.remUser.Text = "Remove";
            this.remUser.UseVisualStyleBackColor = true;
            this.remUser.Click += new System.EventHandler(this.remUser_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(47, 361);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(150, 27);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // usersList
            // 
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(37, 73);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(169, 251);
            this.usersList.TabIndex = 4;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 400);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.remUser);
            this.Controls.Add(this.addUser);
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addUser;
        private System.Windows.Forms.Button remUser;
        private System.Windows.Forms.Button okButton;
        public System.Windows.Forms.ListBox usersList;
    }
}