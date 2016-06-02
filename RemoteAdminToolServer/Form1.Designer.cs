namespace RemoteAdminToolServer
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
            try {
                Server.Disconnect(false);
            }
            catch { }
            try
            {
                Server.Shutdown(System.Net.Sockets.SocketShutdown.Receive);
            }
            catch { }
            try
            {
                Server.Shutdown(System.Net.Sockets.SocketShutdown.Send);
            }
            catch { }
            try
            {
                Server.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            }
            catch { }
            Server.Dispose();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.console = new System.Windows.Forms.Label();
            this.sendCommand = new System.Windows.Forms.TextBox();
            this.sendCommandButton = new System.Windows.Forms.Button();
            this.showIP = new System.Windows.Forms.Label();
            this.dltLog = new System.Windows.Forms.Button();
            this.sendFile = new System.Windows.Forms.Button();
            this.openFiles = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tempTextBox = new System.Windows.Forms.TextBox();
            this.listOfActiveConnectionDataGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SesionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listOfActiveConnectionDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connected IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Send";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Receve";
            // 
            // console
            // 
            this.console.AutoSize = true;
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.ForeColor = System.Drawing.Color.Yellow;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(0, 17);
            this.console.TabIndex = 3;
            this.console.SizeChanged += new System.EventHandler(this.console_SizeChanged);
            // 
            // sendCommand
            // 
            this.sendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendCommand.Location = new System.Drawing.Point(98, 49);
            this.sendCommand.Name = "sendCommand";
            this.sendCommand.Size = new System.Drawing.Size(444, 22);
            this.sendCommand.TabIndex = 5;
            // 
            // sendCommandButton
            // 
            this.sendCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendCommandButton.Location = new System.Drawing.Point(577, 49);
            this.sendCommandButton.Name = "sendCommandButton";
            this.sendCommandButton.Size = new System.Drawing.Size(75, 32);
            this.sendCommandButton.TabIndex = 6;
            this.sendCommandButton.Text = "Send";
            this.sendCommandButton.UseVisualStyleBackColor = true;
            this.sendCommandButton.Click += new System.EventHandler(this.sendCommandButton_Click);
            // 
            // showIP
            // 
            this.showIP.AutoSize = true;
            this.showIP.Location = new System.Drawing.Point(111, 13);
            this.showIP.Name = "showIP";
            this.showIP.Size = new System.Drawing.Size(101, 17);
            this.showIP.TabIndex = 7;
            this.showIP.Text = "No Connection";
            // 
            // dltLog
            // 
            this.dltLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dltLog.Location = new System.Drawing.Point(691, 91);
            this.dltLog.Name = "dltLog";
            this.dltLog.Size = new System.Drawing.Size(75, 32);
            this.dltLog.TabIndex = 8;
            this.dltLog.Text = "Dlt Log";
            this.dltLog.UseVisualStyleBackColor = true;
            this.dltLog.Click += new System.EventHandler(this.dltLog_Click);
            // 
            // sendFile
            // 
            this.sendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendFile.Location = new System.Drawing.Point(691, 129);
            this.sendFile.Name = "sendFile";
            this.sendFile.Size = new System.Drawing.Size(75, 32);
            this.sendFile.TabIndex = 9;
            this.sendFile.Text = "Send File";
            this.sendFile.UseVisualStyleBackColor = true;
            this.sendFile.Click += new System.EventHandler(this.sendFile_Click);
            // 
            // openFiles
            // 
            this.openFiles.FileName = "openFileDialog1";
            this.openFiles.Multiselect = true;
            this.openFiles.SupportMultiDottedExtensions = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tempTextBox);
            this.panel1.Controls.Add(this.console);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.panel1.Location = new System.Drawing.Point(15, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 221);
            this.panel1.TabIndex = 10;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // tempTextBox
            // 
            this.tempTextBox.Location = new System.Drawing.Point(148, 83);
            this.tempTextBox.Name = "tempTextBox";
            this.tempTextBox.Size = new System.Drawing.Size(0, 22);
            this.tempTextBox.TabIndex = 4;
            // 
            // listOfActiveConnectionDataGrid
            // 
            this.listOfActiveConnectionDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfActiveConnectionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listOfActiveConnectionDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Device,
            this.SesionID,
            this.IP});
            this.listOfActiveConnectionDataGrid.Location = new System.Drawing.Point(15, 101);
            this.listOfActiveConnectionDataGrid.Name = "listOfActiveConnectionDataGrid";
            this.listOfActiveConnectionDataGrid.RowTemplate.Height = 24;
            this.listOfActiveConnectionDataGrid.Size = new System.Drawing.Size(527, 109);
            this.listOfActiveConnectionDataGrid.TabIndex = 11;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Device
            // 
            this.Device.HeaderText = "Device Name";
            this.Device.Name = "Device";
            // 
            // SesionID
            // 
            this.SesionID.HeaderText = "SesionID";
            this.SesionID.Name = "SesionID";
            this.SesionID.ReadOnly = true;
            // 
            // IP
            // 
            this.IP.HeaderText = "IP address";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1003, 443);
            this.Controls.Add(this.listOfActiveConnectionDataGrid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sendFile);
            this.Controls.Add(this.dltLog);
            this.Controls.Add(this.showIP);
            this.Controls.Add(this.sendCommandButton);
            this.Controls.Add(this.sendCommand);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listOfActiveConnectionDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label console;
        private System.Windows.Forms.TextBox sendCommand;
        private System.Windows.Forms.Button sendCommandButton;
        private System.Windows.Forms.Label showIP;
        private System.Windows.Forms.Button dltLog;
        private System.Windows.Forms.Button sendFile;
        private System.Windows.Forms.OpenFileDialog openFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tempTextBox;
        private System.Windows.Forms.DataGridView listOfActiveConnectionDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Device;
        private System.Windows.Forms.DataGridViewTextBoxColumn SesionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
    }
}

