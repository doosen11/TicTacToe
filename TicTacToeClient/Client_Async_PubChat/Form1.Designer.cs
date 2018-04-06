namespace Client_Async_PubChat
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMe = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLogoutExit = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(405, 394);
            this.textBox1.TabIndex = 0;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(12, 32);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(140, 173);
            this.lstUsers.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "I am: ";
            // 
            // lblMe
            // 
            this.lblMe.AutoSize = true;
            this.lblMe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMe.Location = new System.Drawing.Point(55, 260);
            this.lblMe.Name = "lblMe";
            this.lblMe.Size = new System.Drawing.Size(17, 20);
            this.lblMe.TabIndex = 12;
            this.lblMe.Text = "  ";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(187, 439);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(343, 20);
            this.txtSend.TabIndex = 13;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(537, 437);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(63, 31);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(9, 445);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(132, 37);
            this.btnConnect.TabIndex = 15;
            this.btnConnect.Text = "Connect Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnLogoutExit
            // 
            this.btnLogoutExit.Location = new System.Drawing.Point(9, 488);
            this.btnLogoutExit.Name = "btnLogoutExit";
            this.btnLogoutExit.Size = new System.Drawing.Size(132, 33);
            this.btnLogoutExit.TabIndex = 16;
            this.btnLogoutExit.Text = "Logout and Exit";
            this.btnLogoutExit.UseVisualStyleBackColor = true;
            this.btnLogoutExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(12, 419);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(129, 20);
            this.txtServerIP.TabIndex = 17;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Server IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 543);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.btnLogoutExit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.lblMe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Async Socket: Public Chat Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMe;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLogoutExit;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label1;
    }
}

