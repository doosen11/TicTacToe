namespace TTTClient
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
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLogoutExit = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.TTT_button_0 = new System.Windows.Forms.Button();
            this.TTT_button_1 = new System.Windows.Forms.Button();
            this.TTT_button_2 = new System.Windows.Forms.Button();
            this.TTT_button_3 = new System.Windows.Forms.Button();
            this.TTT_button_4 = new System.Windows.Forms.Button();
            this.TTT_button_5 = new System.Windows.Forms.Button();
            this.TTT_button_6 = new System.Windows.Forms.Button();
            this.TTT_button_7 = new System.Windows.Forms.Button();
            this.TTT_button_8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(586, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(300, 309);
            this.textBox1.TabIndex = 0;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(18, 67);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(169, 199);
            this.lstUsers.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Current User";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(622, 368);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(243, 20);
            this.txtSend.TabIndex = 13;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(553, 357);
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
            this.btnConnect.Text = "Login";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 37);
            this.button1.TabIndex = 19;
            this.button1.Text = "Request Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 484);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 37);
            this.button2.TabIndex = 20;
            this.button2.Text = "Exit Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(87, 12);
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Size = new System.Drawing.Size(100, 20);
            this.userName.TabIndex = 21;
            // 
            // TTT_button_0
            // 
            this.TTT_button_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_0.Location = new System.Drawing.Point(275, 81);
            this.TTT_button_0.Name = "TTT_button_0";
            this.TTT_button_0.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_0.TabIndex = 22;
            this.TTT_button_0.UseVisualStyleBackColor = true;
            this.TTT_button_0.Click += new System.EventHandler(this.TTT_button_0_Click);
            // 
            // TTT_button_1
            // 
            this.TTT_button_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_1.Location = new System.Drawing.Point(358, 81);
            this.TTT_button_1.Name = "TTT_button_1";
            this.TTT_button_1.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_1.TabIndex = 23;
            this.TTT_button_1.UseVisualStyleBackColor = true;
            this.TTT_button_1.Click += new System.EventHandler(this.TTT_button_1_Click);
            // 
            // TTT_button_2
            // 
            this.TTT_button_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_2.Location = new System.Drawing.Point(441, 81);
            this.TTT_button_2.Name = "TTT_button_2";
            this.TTT_button_2.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_2.TabIndex = 24;
            this.TTT_button_2.UseVisualStyleBackColor = true;
            this.TTT_button_2.Click += new System.EventHandler(this.TTT_button_2_Click);
            // 
            // TTT_button_3
            // 
            this.TTT_button_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_3.Location = new System.Drawing.Point(275, 164);
            this.TTT_button_3.Name = "TTT_button_3";
            this.TTT_button_3.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_3.TabIndex = 25;
            this.TTT_button_3.UseVisualStyleBackColor = true;
            this.TTT_button_3.Click += new System.EventHandler(this.TTT_button_3_Click);
            // 
            // TTT_button_4
            // 
            this.TTT_button_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_4.Location = new System.Drawing.Point(358, 164);
            this.TTT_button_4.Name = "TTT_button_4";
            this.TTT_button_4.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_4.TabIndex = 26;
            this.TTT_button_4.UseVisualStyleBackColor = true;
            this.TTT_button_4.Click += new System.EventHandler(this.TTT_button_4_Click);
            // 
            // TTT_button_5
            // 
            this.TTT_button_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_5.Location = new System.Drawing.Point(441, 164);
            this.TTT_button_5.Name = "TTT_button_5";
            this.TTT_button_5.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_5.TabIndex = 27;
            this.TTT_button_5.UseVisualStyleBackColor = true;
            this.TTT_button_5.Click += new System.EventHandler(this.TTT_button_5_Click);
            // 
            // TTT_button_6
            // 
            this.TTT_button_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_6.Location = new System.Drawing.Point(275, 247);
            this.TTT_button_6.Name = "TTT_button_6";
            this.TTT_button_6.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_6.TabIndex = 28;
            this.TTT_button_6.UseVisualStyleBackColor = true;
            this.TTT_button_6.Click += new System.EventHandler(this.TTT_button_6_Click);
            // 
            // TTT_button_7
            // 
            this.TTT_button_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_7.Location = new System.Drawing.Point(358, 247);
            this.TTT_button_7.Name = "TTT_button_7";
            this.TTT_button_7.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_7.TabIndex = 29;
            this.TTT_button_7.UseVisualStyleBackColor = true;
            this.TTT_button_7.Click += new System.EventHandler(this.TTT_button_7_Click);
            // 
            // TTT_button_8
            // 
            this.TTT_button_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TTT_button_8.Location = new System.Drawing.Point(441, 247);
            this.TTT_button_8.Name = "TTT_button_8";
            this.TTT_button_8.Size = new System.Drawing.Size(77, 77);
            this.TTT_button_8.TabIndex = 30;
            this.TTT_button_8.UseVisualStyleBackColor = true;
            this.TTT_button_8.Click += new System.EventHandler(this.TTT_button_8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 543);
            this.Controls.Add(this.TTT_button_8);
            this.Controls.Add(this.TTT_button_7);
            this.Controls.Add(this.TTT_button_6);
            this.Controls.Add(this.TTT_button_5);
            this.Controls.Add(this.TTT_button_4);
            this.Controls.Add(this.TTT_button_3);
            this.Controls.Add(this.TTT_button_2);
            this.Controls.Add(this.TTT_button_1);
            this.Controls.Add(this.TTT_button_0);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.btnLogoutExit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Tic Tac Toe Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLogoutExit;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button TTT_button_0;
        private System.Windows.Forms.Button TTT_button_1;
        private System.Windows.Forms.Button TTT_button_2;
        private System.Windows.Forms.Button TTT_button_3;
        private System.Windows.Forms.Button TTT_button_4;
        private System.Windows.Forms.Button TTT_button_5;
        private System.Windows.Forms.Button TTT_button_6;
        private System.Windows.Forms.Button TTT_button_7;
        private System.Windows.Forms.Button TTT_button_8;
    }
}

