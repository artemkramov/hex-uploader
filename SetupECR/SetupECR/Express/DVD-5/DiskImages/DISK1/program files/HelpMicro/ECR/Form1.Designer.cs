namespace ECR
{
    partial class MainForm
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelPayment = new System.Windows.Forms.Panel();
            this.tableLayoutReports = new System.Windows.Forms.TableLayoutPanel();
            this.btnZReport = new ECR.CustomControls.CustomButton();
            this.btnXReport = new ECR.CustomControls.CustomButton();
            this.lblDivider = new ECR.CustomControls.CustomLabel();
            this.btnPaymentOut = new ECR.CustomControls.CustomButton();
            this.textboxSum = new ECR.CustomControls.CustomTextbox();
            this.btnPaymentIn = new ECR.CustomControls.CustomButton();
            this.lblSum = new ECR.CustomControls.CustomLabel();
            this.comboPaymentType = new ECR.CustomControls.CustomCombobox();
            this.lblPaymentType = new ECR.CustomControls.CustomLabel();
            this.btnConnect = new ECR.CustomControls.CustomButton();
            this.textboxPassword = new ECR.CustomControls.CustomTextbox();
            this.labelPassword = new ECR.CustomControls.CustomLabel();
            this.textboxUsername = new ECR.CustomControls.CustomTextbox();
            this.labelUsername = new ECR.CustomControls.CustomLabel();
            this.textboxIP = new ECR.CustomControls.CustomTextbox();
            this.labelIP = new ECR.CustomControls.CustomLabel();
            this.tableLayoutPanel.SuspendLayout();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panelPayment.SuspendLayout();
            this.tableLayoutReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.panelPayment, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panelLogin, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panelLogo, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(1007, 461);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // panelLogin
            // 
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.btnConnect);
            this.panelLogin.Controls.Add(this.textboxPassword);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.textboxUsername);
            this.panelLogin.Controls.Add(this.labelUsername);
            this.panelLogin.Controls.Add(this.textboxIP);
            this.panelLogin.Controls.Add(this.labelIP);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogin.Location = new System.Drawing.Point(3, 3);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(497, 169);
            this.panelLogin.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogo.Location = new System.Drawing.Point(506, 3);
            this.panelLogo.Name = "panelLogo";
            this.tableLayoutPanel.SetRowSpan(this.panelLogo, 2);
            this.panelLogo.Size = new System.Drawing.Size(498, 446);
            this.panelLogo.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // panelPayment
            // 
            this.panelPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPayment.Controls.Add(this.tableLayoutReports);
            this.panelPayment.Controls.Add(this.lblDivider);
            this.panelPayment.Controls.Add(this.btnPaymentOut);
            this.panelPayment.Controls.Add(this.textboxSum);
            this.panelPayment.Controls.Add(this.btnPaymentIn);
            this.panelPayment.Controls.Add(this.lblSum);
            this.panelPayment.Controls.Add(this.comboPaymentType);
            this.panelPayment.Controls.Add(this.lblPaymentType);
            this.panelPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPayment.Enabled = false;
            this.panelPayment.Location = new System.Drawing.Point(3, 179);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Size = new System.Drawing.Size(497, 270);
            this.panelPayment.TabIndex = 5;
            // 
            // tableLayoutReports
            // 
            this.tableLayoutReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutReports.ColumnCount = 2;
            this.tableLayoutReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutReports.Controls.Add(this.btnZReport, 1, 0);
            this.tableLayoutReports.Controls.Add(this.btnXReport, 0, 0);
            this.tableLayoutReports.Location = new System.Drawing.Point(8, 148);
            this.tableLayoutReports.Name = "tableLayoutReports";
            this.tableLayoutReports.RowCount = 1;
            this.tableLayoutReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutReports.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutReports.Size = new System.Drawing.Size(484, 117);
            this.tableLayoutReports.TabIndex = 7;
            // 
            // btnZReport
            // 
            this.btnZReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZReport.BackColor = System.Drawing.Color.White;
            this.btnZReport.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZReport.Location = new System.Drawing.Point(245, 3);
            this.btnZReport.Name = "btnZReport";
            this.btnZReport.Size = new System.Drawing.Size(236, 50);
            this.btnZReport.TabIndex = 1;
            this.btnZReport.Text = "Z-звіт";
            this.btnZReport.UseVisualStyleBackColor = false;
            this.btnZReport.Click += new System.EventHandler(this.btnZReport_Click);
            // 
            // btnXReport
            // 
            this.btnXReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXReport.BackColor = System.Drawing.Color.White;
            this.btnXReport.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnXReport.Location = new System.Drawing.Point(3, 3);
            this.btnXReport.Name = "btnXReport";
            this.btnXReport.Size = new System.Drawing.Size(236, 50);
            this.btnXReport.TabIndex = 0;
            this.btnXReport.Text = "X-звіт";
            this.btnXReport.UseVisualStyleBackColor = false;
            this.btnXReport.Click += new System.EventHandler(this.btnXReport_Click);
            // 
            // lblDivider
            // 
            this.lblDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDivider.BackColor = System.Drawing.Color.Transparent;
            this.lblDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDivider.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDivider.Location = new System.Drawing.Point(8, 132);
            this.lblDivider.Name = "lblDivider";
            this.lblDivider.Size = new System.Drawing.Size(484, 2);
            this.lblDivider.TabIndex = 6;
            // 
            // btnPaymentOut
            // 
            this.btnPaymentOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaymentOut.BackColor = System.Drawing.Color.White;
            this.btnPaymentOut.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPaymentOut.Location = new System.Drawing.Point(230, 66);
            this.btnPaymentOut.Name = "btnPaymentOut";
            this.btnPaymentOut.Size = new System.Drawing.Size(194, 50);
            this.btnPaymentOut.TabIndex = 5;
            this.btnPaymentOut.Text = "Винесення";
            this.btnPaymentOut.UseVisualStyleBackColor = false;
            this.btnPaymentOut.Click += new System.EventHandler(this.btnPaymentOut_Click);
            // 
            // textboxSum
            // 
            this.textboxSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxSum.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxSum.Location = new System.Drawing.Point(12, 35);
            this.textboxSum.Name = "textboxSum";
            this.textboxSum.Size = new System.Drawing.Size(202, 26);
            this.textboxSum.TabIndex = 1;
            this.textboxSum.Tag = "Required|Float";
            // 
            // btnPaymentIn
            // 
            this.btnPaymentIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaymentIn.BackColor = System.Drawing.Color.White;
            this.btnPaymentIn.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPaymentIn.Location = new System.Drawing.Point(11, 66);
            this.btnPaymentIn.Name = "btnPaymentIn";
            this.btnPaymentIn.Size = new System.Drawing.Size(203, 50);
            this.btnPaymentIn.TabIndex = 4;
            this.btnPaymentIn.Text = "Внесення";
            this.btnPaymentIn.UseVisualStyleBackColor = false;
            this.btnPaymentIn.Click += new System.EventHandler(this.btnPaymentIn_Click);
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.Transparent;
            this.lblSum.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSum.Location = new System.Drawing.Point(8, 10);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(41, 20);
            this.lblSum.TabIndex = 0;
            this.lblSum.Text = "Сума";
            // 
            // comboPaymentType
            // 
            this.comboPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPaymentType.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboPaymentType.FormattingEnabled = true;
            this.comboPaymentType.Location = new System.Drawing.Point(230, 32);
            this.comboPaymentType.Name = "comboPaymentType";
            this.comboPaymentType.Size = new System.Drawing.Size(259, 28);
            this.comboPaymentType.TabIndex = 3;
            this.comboPaymentType.Tag = "Required";
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentType.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPaymentType.Location = new System.Drawing.Point(226, 9);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(76, 20);
            this.lblPaymentType.TabIndex = 2;
            this.lblPaymentType.Text = "Тип оплати";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConnect.BackColor = System.Drawing.Color.White;
            this.btnConnect.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConnect.Location = new System.Drawing.Point(310, 28);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(182, 50);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "З\'єднання";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // textboxPassword
            // 
            this.textboxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxPassword.Location = new System.Drawing.Point(12, 134);
            this.textboxPassword.Name = "textboxPassword";
            this.textboxPassword.PasswordChar = '*';
            this.textboxPassword.Size = new System.Drawing.Size(292, 26);
            this.textboxPassword.TabIndex = 5;
            this.textboxPassword.Tag = "Required";
            this.textboxPassword.Text = "751426";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(12, 111);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(60, 20);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль:";
            // 
            // textboxUsername
            // 
            this.textboxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxUsername.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxUsername.Location = new System.Drawing.Point(12, 82);
            this.textboxUsername.Name = "textboxUsername";
            this.textboxUsername.Size = new System.Drawing.Size(292, 26);
            this.textboxUsername.TabIndex = 3;
            this.textboxUsername.Tag = "Required";
            this.textboxUsername.Text = "service";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUsername.Location = new System.Drawing.Point(9, 59);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(45, 20);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Логін:";
            // 
            // textboxIP
            // 
            this.textboxIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxIP.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxIP.Location = new System.Drawing.Point(12, 28);
            this.textboxIP.Name = "textboxIP";
            this.textboxIP.Size = new System.Drawing.Size(292, 26);
            this.textboxIP.TabIndex = 1;
            this.textboxIP.Tag = "Required";
            this.textboxIP.Text = "http://169.254.186.21/";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.BackColor = System.Drawing.Color.Transparent;
            this.labelIP.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIP.Location = new System.Drawing.Point(8, 5);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(74, 20);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "IP адреса:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 461);
            this.Controls.Add(this.tableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainForm";
            this.Text = "ECR";
            this.tableLayoutPanel.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panelPayment.ResumeLayout(false);
            this.panelPayment.PerformLayout();
            this.tableLayoutReports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelLogo;
        private CustomControls.CustomLabel labelIP;
        private CustomControls.CustomTextbox textboxIP;
        private CustomControls.CustomTextbox textboxUsername;
        private CustomControls.CustomLabel labelUsername;
        private CustomControls.CustomLabel labelPassword;
        private CustomControls.CustomTextbox textboxPassword;
        private CustomControls.CustomButton btnConnect;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panelPayment;
        private CustomControls.CustomButton btnPaymentOut;
        private CustomControls.CustomTextbox textboxSum;
        private CustomControls.CustomButton btnPaymentIn;
        private CustomControls.CustomLabel lblSum;
        private CustomControls.CustomCombobox comboPaymentType;
        private CustomControls.CustomLabel lblPaymentType;
        private CustomControls.CustomLabel lblDivider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutReports;
        private CustomControls.CustomButton btnXReport;
        private CustomControls.CustomButton btnZReport;
    }
}

