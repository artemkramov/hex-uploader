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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelInformation = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelUpload = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelHexUpload = new System.Windows.Forms.Panel();
            this.panelHexInfo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelUploadControls = new System.Windows.Forms.Panel();
            this.panelUploadProgress = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblInfoVersion = new ECR.CustomControls.CustomLabel();
            this.lblInfoVersionValue = new ECR.CustomControls.CustomLabel();
            this.lblInfoDescription = new ECR.CustomControls.CustomLabel();
            this.lblInfoDescriptionValue = new ECR.CustomControls.CustomLabel();
            this.lblInfoFirmwareGUID = new ECR.CustomControls.CustomLabel();
            this.lblInfoFirmwareGUIDValue = new ECR.CustomControls.CustomLabel();
            this.lblInfoHardwareGUID = new ECR.CustomControls.CustomLabel();
            this.lblInfoUploadLengthValue = new ECR.CustomControls.CustomLabel();
            this.lblInfoHardwareGUIDValue = new ECR.CustomControls.CustomLabel();
            this.lblInfoUploadLength = new ECR.CustomControls.CustomLabel();
            this.btnConnect = new ECR.CustomControls.CustomButton();
            this.textboxPassword = new ECR.CustomControls.CustomTextbox();
            this.labelPassword = new ECR.CustomControls.CustomLabel();
            this.textboxUsername = new ECR.CustomControls.CustomTextbox();
            this.labelUsername = new ECR.CustomControls.CustomLabel();
            this.textboxIP = new ECR.CustomControls.CustomTextbox();
            this.labelIP = new ECR.CustomControls.CustomLabel();
            this.labelFileName = new ECR.CustomControls.CustomLabel();
            this.btnLoadFile = new ECR.CustomControls.CustomButton();
            this.labelFirmwareGUIDValue = new ECR.CustomControls.CustomLabel();
            this.labelFirmwareGUID = new ECR.CustomControls.CustomLabel();
            this.labelDescriptionValue = new ECR.CustomControls.CustomLabel();
            this.labelDescription = new ECR.CustomControls.CustomLabel();
            this.labelVersionValue = new ECR.CustomControls.CustomLabel();
            this.labelVersion = new ECR.CustomControls.CustomLabel();
            this.btnFlash = new ECR.CustomControls.CustomButton();
            this.btnUploadHex = new ECR.CustomControls.CustomButton();
            this.tableLayoutPanel.SuspendLayout();
            this.panelInformation.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelUpload.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelHexUpload.SuspendLayout();
            this.panelHexInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panelUploadControls.SuspendLayout();
            this.panelUploadProgress.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.panelInformation, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panelLogin, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panelUpload, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(1007, 341);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // panelInformation
            // 
            this.panelInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInformation.Controls.Add(this.tableLayoutPanel3);
            this.panelInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInformation.Enabled = false;
            this.panelInformation.Location = new System.Drawing.Point(3, 178);
            this.panelInformation.Name = "panelInformation";
            this.panelInformation.Size = new System.Drawing.Size(497, 160);
            this.panelInformation.TabIndex = 5;
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
            // panelUpload
            // 
            this.panelUpload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUpload.Controls.Add(this.tableLayoutPanel1);
            this.panelUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUpload.Enabled = false;
            this.panelUpload.Location = new System.Drawing.Point(506, 3);
            this.panelUpload.Name = "panelUpload";
            this.tableLayoutPanel.SetRowSpan(this.panelUpload, 2);
            this.panelUpload.Size = new System.Drawing.Size(498, 335);
            this.panelUpload.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelHexUpload, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelHexInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelUploadControls, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelUploadProgress, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 306);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelHexUpload
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelHexUpload, 2);
            this.panelHexUpload.Controls.Add(this.labelFileName);
            this.panelHexUpload.Controls.Add(this.btnLoadFile);
            this.panelHexUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHexUpload.Location = new System.Drawing.Point(3, 3);
            this.panelHexUpload.Name = "panelHexUpload";
            this.panelHexUpload.Size = new System.Drawing.Size(484, 54);
            this.panelHexUpload.TabIndex = 0;
            // 
            // panelHexInfo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelHexInfo, 2);
            this.panelHexInfo.Controls.Add(this.tableLayoutPanel2);
            this.panelHexInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHexInfo.Location = new System.Drawing.Point(3, 63);
            this.panelHexInfo.Name = "panelHexInfo";
            this.panelHexInfo.Size = new System.Drawing.Size(484, 100);
            this.panelHexInfo.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.13223F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.86777F));
            this.tableLayoutPanel2.Controls.Add(this.labelFirmwareGUIDValue, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelFirmwareGUID, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelDescriptionValue, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelDescription, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelVersionValue, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelVersion, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(484, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // panelUploadControls
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelUploadControls, 2);
            this.panelUploadControls.Controls.Add(this.btnFlash);
            this.panelUploadControls.Controls.Add(this.btnUploadHex);
            this.panelUploadControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUploadControls.Location = new System.Drawing.Point(3, 169);
            this.panelUploadControls.Name = "panelUploadControls";
            this.panelUploadControls.Size = new System.Drawing.Size(484, 74);
            this.panelUploadControls.TabIndex = 9;
            this.panelUploadControls.Visible = false;
            // 
            // panelUploadProgress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelUploadProgress, 2);
            this.panelUploadProgress.Controls.Add(this.progressBar1);
            this.panelUploadProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUploadProgress.Location = new System.Drawing.Point(3, 249);
            this.panelUploadProgress.Name = "panelUploadProgress";
            this.panelUploadProgress.Size = new System.Drawing.Size(484, 54);
            this.panelUploadProgress.TabIndex = 10;
            this.panelUploadProgress.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBar1.Location = new System.Drawing.Point(3, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(374, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.34343F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.65656F));
            this.tableLayoutPanel3.Controls.Add(this.lblInfoVersion, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoVersionValue, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoDescription, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoDescriptionValue, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoFirmwareGUID, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoFirmwareGUIDValue, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoHardwareGUID, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoUploadLengthValue, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoHardwareGUIDValue, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblInfoUploadLength, 0, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, -1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(495, 153);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblInfoVersion
            // 
            this.lblInfoVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoVersion.AutoSize = true;
            this.lblInfoVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoVersion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoVersion.Location = new System.Drawing.Point(3, 5);
            this.lblInfoVersion.Name = "lblInfoVersion";
            this.lblInfoVersion.Size = new System.Drawing.Size(55, 20);
            this.lblInfoVersion.TabIndex = 8;
            this.lblInfoVersion.Text = "Версія:";
            // 
            // lblInfoVersionValue
            // 
            this.lblInfoVersionValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoVersionValue.AutoSize = true;
            this.lblInfoVersionValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoVersionValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoVersionValue.Location = new System.Drawing.Point(172, 5);
            this.lblInfoVersionValue.Name = "lblInfoVersionValue";
            this.lblInfoVersionValue.Size = new System.Drawing.Size(13, 20);
            this.lblInfoVersionValue.TabIndex = 9;
            this.lblInfoVersionValue.Text = "-";
            // 
            // lblInfoDescription
            // 
            this.lblInfoDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoDescription.AutoSize = true;
            this.lblInfoDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoDescription.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoDescription.Location = new System.Drawing.Point(3, 35);
            this.lblInfoDescription.Name = "lblInfoDescription";
            this.lblInfoDescription.Size = new System.Drawing.Size(44, 20);
            this.lblInfoDescription.TabIndex = 10;
            this.lblInfoDescription.Text = "Опис:";
            // 
            // lblInfoDescriptionValue
            // 
            this.lblInfoDescriptionValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoDescriptionValue.AutoSize = true;
            this.lblInfoDescriptionValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoDescriptionValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoDescriptionValue.Location = new System.Drawing.Point(172, 35);
            this.lblInfoDescriptionValue.Name = "lblInfoDescriptionValue";
            this.lblInfoDescriptionValue.Size = new System.Drawing.Size(13, 20);
            this.lblInfoDescriptionValue.TabIndex = 11;
            this.lblInfoDescriptionValue.Text = "-";
            // 
            // lblInfoFirmwareGUID
            // 
            this.lblInfoFirmwareGUID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoFirmwareGUID.AutoSize = true;
            this.lblInfoFirmwareGUID.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoFirmwareGUID.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoFirmwareGUID.Location = new System.Drawing.Point(3, 65);
            this.lblInfoFirmwareGUID.Name = "lblInfoFirmwareGUID";
            this.lblInfoFirmwareGUID.Size = new System.Drawing.Size(102, 20);
            this.lblInfoFirmwareGUID.TabIndex = 12;
            this.lblInfoFirmwareGUID.Text = "Firmware GUID:";
            // 
            // lblInfoFirmwareGUIDValue
            // 
            this.lblInfoFirmwareGUIDValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoFirmwareGUIDValue.AutoSize = true;
            this.lblInfoFirmwareGUIDValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoFirmwareGUIDValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoFirmwareGUIDValue.Location = new System.Drawing.Point(172, 65);
            this.lblInfoFirmwareGUIDValue.Name = "lblInfoFirmwareGUIDValue";
            this.lblInfoFirmwareGUIDValue.Size = new System.Drawing.Size(13, 20);
            this.lblInfoFirmwareGUIDValue.TabIndex = 13;
            this.lblInfoFirmwareGUIDValue.Text = "-";
            // 
            // lblInfoHardwareGUID
            // 
            this.lblInfoHardwareGUID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoHardwareGUID.AutoSize = true;
            this.lblInfoHardwareGUID.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoHardwareGUID.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoHardwareGUID.Location = new System.Drawing.Point(3, 95);
            this.lblInfoHardwareGUID.Name = "lblInfoHardwareGUID";
            this.lblInfoHardwareGUID.Size = new System.Drawing.Size(104, 20);
            this.lblInfoHardwareGUID.TabIndex = 14;
            this.lblInfoHardwareGUID.Text = "Hardware GUID:";
            // 
            // lblInfoUploadLengthValue
            // 
            this.lblInfoUploadLengthValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoUploadLengthValue.AutoSize = true;
            this.lblInfoUploadLengthValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoUploadLengthValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoUploadLengthValue.Location = new System.Drawing.Point(172, 126);
            this.lblInfoUploadLengthValue.Name = "lblInfoUploadLengthValue";
            this.lblInfoUploadLengthValue.Size = new System.Drawing.Size(13, 20);
            this.lblInfoUploadLengthValue.TabIndex = 17;
            this.lblInfoUploadLengthValue.Text = "-";
            // 
            // lblInfoHardwareGUIDValue
            // 
            this.lblInfoHardwareGUIDValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoHardwareGUIDValue.AutoSize = true;
            this.lblInfoHardwareGUIDValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoHardwareGUIDValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoHardwareGUIDValue.Location = new System.Drawing.Point(172, 95);
            this.lblInfoHardwareGUIDValue.Name = "lblInfoHardwareGUIDValue";
            this.lblInfoHardwareGUIDValue.Size = new System.Drawing.Size(13, 20);
            this.lblInfoHardwareGUIDValue.TabIndex = 15;
            this.lblInfoHardwareGUIDValue.Text = "-";
            // 
            // lblInfoUploadLength
            // 
            this.lblInfoUploadLength.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoUploadLength.AutoSize = true;
            this.lblInfoUploadLength.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoUploadLength.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfoUploadLength.Location = new System.Drawing.Point(3, 126);
            this.lblInfoUploadLength.Name = "lblInfoUploadLength";
            this.lblInfoUploadLength.Size = new System.Drawing.Size(56, 20);
            this.lblInfoUploadLength.TabIndex = 16;
            this.lblInfoUploadLength.Text = "Розмір:";
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
            this.textboxPassword.Text = "555555";
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
            this.textboxUsername.Text = "admin";
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
            this.textboxIP.Text = "http://192.168.0.130";
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
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.BackColor = System.Drawing.Color.Transparent;
            this.labelFileName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFileName.Location = new System.Drawing.Point(191, 17);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(0, 20);
            this.labelFileName.TabIndex = 7;
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoadFile.BackColor = System.Drawing.Color.White;
            this.btnLoadFile.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadFile.Location = new System.Drawing.Point(3, 2);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(182, 50);
            this.btnLoadFile.TabIndex = 7;
            this.btnLoadFile.Text = "Вибрати файл...";
            this.btnLoadFile.UseVisualStyleBackColor = false;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // labelFirmwareGUIDValue
            // 
            this.labelFirmwareGUIDValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFirmwareGUIDValue.AutoSize = true;
            this.labelFirmwareGUIDValue.BackColor = System.Drawing.Color.Transparent;
            this.labelFirmwareGUIDValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirmwareGUIDValue.Location = new System.Drawing.Point(143, 73);
            this.labelFirmwareGUIDValue.Name = "labelFirmwareGUIDValue";
            this.labelFirmwareGUIDValue.Size = new System.Drawing.Size(0, 20);
            this.labelFirmwareGUIDValue.TabIndex = 12;
            // 
            // labelFirmwareGUID
            // 
            this.labelFirmwareGUID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFirmwareGUID.AutoSize = true;
            this.labelFirmwareGUID.BackColor = System.Drawing.Color.Transparent;
            this.labelFirmwareGUID.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirmwareGUID.Location = new System.Drawing.Point(3, 73);
            this.labelFirmwareGUID.Name = "labelFirmwareGUID";
            this.labelFirmwareGUID.Size = new System.Drawing.Size(102, 20);
            this.labelFirmwareGUID.TabIndex = 11;
            this.labelFirmwareGUID.Text = "Firmware GUID:";
            // 
            // labelDescriptionValue
            // 
            this.labelDescriptionValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDescriptionValue.AutoSize = true;
            this.labelDescriptionValue.BackColor = System.Drawing.Color.Transparent;
            this.labelDescriptionValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescriptionValue.Location = new System.Drawing.Point(143, 39);
            this.labelDescriptionValue.Name = "labelDescriptionValue";
            this.labelDescriptionValue.Size = new System.Drawing.Size(0, 20);
            this.labelDescriptionValue.TabIndex = 10;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDescription.AutoSize = true;
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.Location = new System.Drawing.Point(3, 39);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(44, 20);
            this.labelDescription.TabIndex = 9;
            this.labelDescription.Text = "Опис:";
            // 
            // labelVersionValue
            // 
            this.labelVersionValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelVersionValue.AutoSize = true;
            this.labelVersionValue.BackColor = System.Drawing.Color.Transparent;
            this.labelVersionValue.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVersionValue.Location = new System.Drawing.Point(143, 6);
            this.labelVersionValue.Name = "labelVersionValue";
            this.labelVersionValue.Size = new System.Drawing.Size(0, 20);
            this.labelVersionValue.TabIndex = 8;
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelVersion.AutoSize = true;
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVersion.Location = new System.Drawing.Point(3, 6);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(55, 20);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Версія:";
            // 
            // btnFlash
            // 
            this.btnFlash.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFlash.BackColor = System.Drawing.Color.White;
            this.btnFlash.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFlash.Location = new System.Drawing.Point(195, 12);
            this.btnFlash.Name = "btnFlash";
            this.btnFlash.Size = new System.Drawing.Size(182, 50);
            this.btnFlash.TabIndex = 9;
            this.btnFlash.Text = "Прошити";
            this.btnFlash.UseVisualStyleBackColor = false;
            this.btnFlash.Click += new System.EventHandler(this.btnFlash_Click);
            // 
            // btnUploadHex
            // 
            this.btnUploadHex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUploadHex.BackColor = System.Drawing.Color.White;
            this.btnUploadHex.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUploadHex.Location = new System.Drawing.Point(3, 12);
            this.btnUploadHex.Name = "btnUploadHex";
            this.btnUploadHex.Size = new System.Drawing.Size(182, 50);
            this.btnUploadHex.TabIndex = 8;
            this.btnUploadHex.Text = "Завантажити";
            this.btnUploadHex.UseVisualStyleBackColor = false;
            this.btnUploadHex.Click += new System.EventHandler(this.btnUploadHex_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 341);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(930, 380);
            this.Name = "MainForm";
            this.Text = "HEX uploader";
            this.tableLayoutPanel.ResumeLayout(false);
            this.panelInformation.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelUpload.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelHexUpload.ResumeLayout(false);
            this.panelHexUpload.PerformLayout();
            this.panelHexInfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panelUploadControls.ResumeLayout(false);
            this.panelUploadProgress.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelUpload;
        private CustomControls.CustomLabel labelIP;
        private CustomControls.CustomTextbox textboxIP;
        private CustomControls.CustomTextbox textboxUsername;
        private CustomControls.CustomLabel labelUsername;
        private CustomControls.CustomLabel labelPassword;
        private CustomControls.CustomTextbox textboxPassword;
        private CustomControls.CustomButton btnConnect;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panelInformation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomControls.CustomButton btnLoadFile;
        private System.Windows.Forms.Panel panelHexUpload;
        private CustomControls.CustomLabel labelFileName;
        private System.Windows.Forms.Panel panelHexInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CustomControls.CustomLabel labelVersion;
        private CustomControls.CustomLabel labelVersionValue;
        private CustomControls.CustomLabel labelDescription;
        private CustomControls.CustomLabel labelDescriptionValue;
        private CustomControls.CustomLabel labelFirmwareGUIDValue;
        private CustomControls.CustomLabel labelFirmwareGUID;
        private CustomControls.CustomButton btnUploadHex;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panelUploadControls;
        private System.Windows.Forms.Panel panelUploadProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private CustomControls.CustomButton btnFlash;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private CustomControls.CustomLabel lblInfoVersion;
        private CustomControls.CustomLabel lblInfoVersionValue;
        private CustomControls.CustomLabel lblInfoDescription;
        private CustomControls.CustomLabel lblInfoDescriptionValue;
        private CustomControls.CustomLabel lblInfoFirmwareGUID;
        private CustomControls.CustomLabel lblInfoFirmwareGUIDValue;
        private CustomControls.CustomLabel lblInfoHardwareGUID;
        private CustomControls.CustomLabel lblInfoUploadLengthValue;
        private CustomControls.CustomLabel lblInfoHardwareGUIDValue;
        private CustomControls.CustomLabel lblInfoUploadLength;
    }
}

