namespace TicTacToeServer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lst_users = new System.Windows.Forms.ListBox();
            this.lst_connections = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lst_users
            // 
            this.lst_users.FormattingEnabled = true;
            this.lst_users.Location = new System.Drawing.Point(427, 188);
            this.lst_users.Name = "lst_users";
            this.lst_users.Size = new System.Drawing.Size(164, 147);
            this.lst_users.TabIndex = 0;
            // 
            // lst_connections
            // 
            this.lst_connections.FormattingEnabled = true;
            this.lst_connections.Location = new System.Drawing.Point(427, 12);
            this.lst_connections.Name = "lst_connections";
            this.lst_connections.Size = new System.Drawing.Size(164, 147);
            this.lst_connections.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(394, 388);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 435);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lst_connections);
            this.Controls.Add(this.lst_users);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_users;
        private System.Windows.Forms.ListBox lst_connections;
        private System.Windows.Forms.TextBox textBox1;
    }
}

