namespace ToastNotifications.Win7
{
    partial class Notification
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notification));
            this.lifeTimer = new System.Windows.Forms.Timer(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.appIcon = new System.Windows.Forms.PictureBox();
            this.closeButtonBox = new System.Windows.Forms.PictureBox();
            this.labelAppName = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lifeTimer
            // 
            this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.MaximumSize = new System.Drawing.Size(255, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(116, 21);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "title goes here";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // appIcon
            // 
            this.appIcon.Image = ((System.Drawing.Image)(resources.GetObject("appIcon.Image")));
            this.appIcon.InitialImage = null;
            this.appIcon.Location = new System.Drawing.Point(25, 27);
            this.appIcon.Name = "appIcon";
            this.appIcon.Size = new System.Drawing.Size(48, 48);
            this.appIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.appIcon.TabIndex = 1;
            this.appIcon.TabStop = false;
            // 
            // closeButtonBox
            // 
            this.closeButtonBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButtonBox.ErrorImage = null;
            this.closeButtonBox.Image = ((System.Drawing.Image)(resources.GetObject("closeButtonBox.Image")));
            this.closeButtonBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("closeButtonBox.InitialImage")));
            this.closeButtonBox.Location = new System.Drawing.Point(341, 12);
            this.closeButtonBox.Name = "closeButtonBox";
            this.closeButtonBox.Size = new System.Drawing.Size(16, 16);
            this.closeButtonBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeButtonBox.TabIndex = 2;
            this.closeButtonBox.TabStop = false;
            this.closeButtonBox.Click += new System.EventHandler(this.closeButtonBox_Click);
            this.closeButtonBox.MouseLeave += new System.EventHandler(this.closeButtonBox_MouseLeave);
            this.closeButtonBox.MouseHover += new System.EventHandler(this.closeButtonBox_MouseHover);
            // 
            // labelAppName
            // 
            this.labelAppName.AutoSize = true;
            this.labelAppName.BackColor = System.Drawing.Color.Transparent;
            this.labelAppName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.ForeColor = System.Drawing.Color.LightGray;
            this.labelAppName.Location = new System.Drawing.Point(83, 83);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(130, 17);
            this.labelAppName.TabIndex = 0;
            this.labelAppName.Text = "app name goes here";
            this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelAppName.Click += new System.EventHandler(this.labelRO_Click);
            // 
            // labelBody
            // 
            this.labelBody.AutoEllipsis = true;
            this.labelBody.AutoSize = true;
            this.labelBody.BackColor = System.Drawing.Color.Transparent;
            this.labelBody.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBody.ForeColor = System.Drawing.Color.White;
            this.labelBody.Location = new System.Drawing.Point(3, 21);
            this.labelBody.MaximumSize = new System.Drawing.Size(255, 0);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(115, 20);
            this.labelBody.TabIndex = 0;
            this.labelBody.Text = "body goes here";
            this.labelBody.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelBody.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelTitle);
            this.flowLayoutPanel1.Controls.Add(this.labelBody);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(79, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(256, 60);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // Notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(380, 115);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.closeButtonBox);
            this.Controls.Add(this.labelAppName);
            this.Controls.Add(this.appIcon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "EDGE Shop Flag Notification";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Notification_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Notification_FormClosed);
            this.Load += new System.EventHandler(this.Notification_Load);
            this.Shown += new System.EventHandler(this.Notification_Shown);
            this.Click += new System.EventHandler(this.Notification_Click);
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeButtonBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer lifeTimer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox appIcon;
        private System.Windows.Forms.PictureBox closeButtonBox;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}