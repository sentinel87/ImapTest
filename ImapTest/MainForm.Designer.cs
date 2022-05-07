
namespace ImapTest
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetMessages = new System.Windows.Forms.Button();
            this.lblMailName = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblMailCount = new System.Windows.Forms.Label();
            this.lvMails = new System.Windows.Forms.ListView();
            this.chMailId = new System.Windows.Forms.ColumnHeader();
            this.chTitle = new System.Windows.Forms.ColumnHeader();
            this.chFrom = new System.Windows.Forms.ColumnHeader();
            this.chDate = new System.Windows.Forms.ColumnHeader();
            this.btnGetFolders = new System.Windows.Forms.Button();
            this.lvFolders = new System.Windows.Forms.ListView();
            this.chFolders = new System.Windows.Forms.ColumnHeader();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.btnMoveMessages = new System.Windows.Forms.Button();
            this.btnDownloadAtt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetMessages
            // 
            this.btnGetMessages.Location = new System.Drawing.Point(13, 12);
            this.btnGetMessages.Name = "btnGetMessages";
            this.btnGetMessages.Size = new System.Drawing.Size(179, 23);
            this.btnGetMessages.TabIndex = 0;
            this.btnGetMessages.Text = "Retrieve emails";
            this.btnGetMessages.UseVisualStyleBackColor = true;
            this.btnGetMessages.Click += new System.EventHandler(this.btnGetMessages_Click);
            // 
            // lblMailName
            // 
            this.lblMailName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMailName.AutoSize = true;
            this.lblMailName.Location = new System.Drawing.Point(13, 389);
            this.lblMailName.Name = "lblMailName";
            this.lblMailName.Size = new System.Drawing.Size(45, 15);
            this.lblMailName.TabIndex = 1;
            this.lblMailName.Text = "Mail: ...";
            // 
            // lblServerName
            // 
            this.lblServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(13, 418);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(54, 15);
            this.lblServerName.TabIndex = 2;
            this.lblServerName.Text = "Server: ...";
            // 
            // lblMailCount
            // 
            this.lblMailCount.AutoSize = true;
            this.lblMailCount.Location = new System.Drawing.Point(227, 16);
            this.lblMailCount.Name = "lblMailCount";
            this.lblMailCount.Size = new System.Drawing.Size(110, 15);
            this.lblMailCount.TabIndex = 3;
            this.lblMailCount.Text = "Ilość wiadomości: 0";
            // 
            // lvMails
            // 
            this.lvMails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMailId,
            this.chTitle,
            this.chFrom,
            this.chDate});
            this.lvMails.HideSelection = false;
            this.lvMails.Location = new System.Drawing.Point(227, 35);
            this.lvMails.Name = "lvMails";
            this.lvMails.Size = new System.Drawing.Size(690, 215);
            this.lvMails.TabIndex = 4;
            this.lvMails.UseCompatibleStateImageBehavior = false;
            this.lvMails.View = System.Windows.Forms.View.Details;
            // 
            // chMailId
            // 
            this.chMailId.Text = "Id";
            // 
            // chTitle
            // 
            this.chTitle.Text = "Subject";
            this.chTitle.Width = 300;
            // 
            // chFrom
            // 
            this.chFrom.Text = "From";
            this.chFrom.Width = 200;
            // 
            // chDate
            // 
            this.chDate.Text = "Mail date";
            this.chDate.Width = 110;
            // 
            // btnGetFolders
            // 
            this.btnGetFolders.Location = new System.Drawing.Point(13, 256);
            this.btnGetFolders.Name = "btnGetFolders";
            this.btnGetFolders.Size = new System.Drawing.Size(179, 23);
            this.btnGetFolders.TabIndex = 5;
            this.btnGetFolders.Text = "Retrieve subdirectories";
            this.btnGetFolders.UseVisualStyleBackColor = true;
            this.btnGetFolders.Click += new System.EventHandler(this.btnGetFolders_Click);
            // 
            // lvFolders
            // 
            this.lvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFolders});
            this.lvFolders.HideSelection = false;
            this.lvFolders.Location = new System.Drawing.Point(227, 256);
            this.lvFolders.Name = "lvFolders";
            this.lvFolders.Size = new System.Drawing.Size(325, 116);
            this.lvFolders.TabIndex = 6;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            this.lvFolders.View = System.Windows.Forms.View.Details;
            // 
            // chFolders
            // 
            this.chFolders.Text = "Subdirectories";
            this.chFolders.Width = 300;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Location = new System.Drawing.Point(13, 285);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(179, 23);
            this.btnNewFolder.TabIndex = 7;
            this.btnNewFolder.Text = "New subdirectory...";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // btnMoveMessages
            // 
            this.btnMoveMessages.Location = new System.Drawing.Point(13, 41);
            this.btnMoveMessages.Name = "btnMoveMessages";
            this.btnMoveMessages.Size = new System.Drawing.Size(179, 23);
            this.btnMoveMessages.TabIndex = 8;
            this.btnMoveMessages.Text = "Move messages to subfolder";
            this.btnMoveMessages.UseVisualStyleBackColor = true;
            this.btnMoveMessages.Click += new System.EventHandler(this.btnMoveMessages_Click);
            // 
            // btnDownloadAtt
            // 
            this.btnDownloadAtt.Location = new System.Drawing.Point(13, 70);
            this.btnDownloadAtt.Name = "btnDownloadAtt";
            this.btnDownloadAtt.Size = new System.Drawing.Size(179, 23);
            this.btnDownloadAtt.TabIndex = 9;
            this.btnDownloadAtt.Text = "Download attachments";
            this.btnDownloadAtt.UseVisualStyleBackColor = true;
            this.btnDownloadAtt.Click += new System.EventHandler(this.btnDownloadAtt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 442);
            this.Controls.Add(this.btnDownloadAtt);
            this.Controls.Add(this.btnMoveMessages);
            this.Controls.Add(this.btnNewFolder);
            this.Controls.Add(this.lvFolders);
            this.Controls.Add(this.btnGetFolders);
            this.Controls.Add(this.lvMails);
            this.Controls.Add(this.lblMailCount);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblMailName);
            this.Controls.Add(this.btnGetMessages);
            this.Name = "MainForm";
            this.Text = "Imap Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetMessages;
        private System.Windows.Forms.Label lblMailName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblMailCount;
        private System.Windows.Forms.ListView lvMails;
        private System.Windows.Forms.ColumnHeader chMailId;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chFrom;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.Button btnGetFolders;
        private System.Windows.Forms.ListView lvFolders;
        private System.Windows.Forms.ColumnHeader chFolders;
        private System.Windows.Forms.Button btnNewFolder;
        private System.Windows.Forms.Button btnMoveMessages;
        private System.Windows.Forms.Button btnDownloadAtt;
    }
}

