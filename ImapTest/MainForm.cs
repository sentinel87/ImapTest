using MailKit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImapTest
{
    public partial class MainForm : Form
    {
        private readonly ILogger<MainForm> _logger;
        private readonly IConfiguration _config;
        private ImapService _imapService;
        public MainForm(ILogger<MainForm> logger, IConfiguration config, ImapService imapService)
        {
            InitializeComponent();
            _logger = logger;
            _config = config;
            _imapService = imapService;
            try
            {
                string mailBoxName = _config.GetSection("Imap").GetValue<string>("mailAddress");
                string mailBoxServer = _config.GetSection("Imap").GetValue<string>("mailServer");
                lblMailName.Text = $"Mail: {mailBoxName}";
                lblServerName.Text = $"Server: {mailBoxServer}";
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured during configuration set: {ex.Message}.");
            }
            if(!Directory.Exists("DownloadedAttachments"))
            {
                Directory.CreateDirectory("DownloadedAttachments");
            }
         }

        private async void btnGetMessages_Click(object sender, EventArgs e)
        {
            IList<IMessageSummary> inboxMessages = await _imapService.GetInboxMessages();
            lblMailCount.Text = $"Messages count: {inboxMessages.Count()}";
            lvMails.Items.Clear();
            foreach(IMessageSummary messageSummary in inboxMessages)
            {
                ListViewItem item = new ListViewItem(messageSummary.UniqueId.ToString());
                item.SubItems.Add(messageSummary.Envelope.Subject);
                item.SubItems.Add(messageSummary.Envelope.Sender[0].Name);
                item.SubItems.Add(messageSummary.Envelope.Date?.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(messageSummary.Index.ToString());
                lvMails.Items.Add(item);
            }
        }

        private async void btnGetFolders_Click(object sender, EventArgs e)
        {
            IList<IMailFolder> mailFolders = await _imapService.GetFolders();
            lvFolders.Items.Clear();
            foreach(IMailFolder mailFolder in mailFolders)
            {
                ListViewItem item = new ListViewItem(mailFolder.FullName);
                lvFolders.Items.Add(item);
            }
        }

        private async void btnNewFolder_Click(object sender, EventArgs e)
        {
            using(CreateFolderFrom form = new CreateFolderFrom())
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    bool created = await _imapService.CreateMailFolder(form.FolderName);
                    if (created)
                        MessageBox.Show("Subdirectory created.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            IList<IMailFolder> mailFolders = await _imapService.GetFolders();
            lvFolders.Items.Clear();
            foreach (IMailFolder mailFolder in mailFolders)
            {
                ListViewItem item = new ListViewItem(mailFolder.FullName);
                lvFolders.Items.Add(item);
            }
        }

        private async void btnMoveMessages_Click(object sender, EventArgs e)
        {
            if (lvFolders.SelectedItems.Count == 1)
            {
                bool moved = await _imapService.MoveMessageToFolder(lvFolders.SelectedItems[0].Text);
                if (moved)
                    MessageBox.Show("Messages moved.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Select subfolder to move message.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private async void btnDownloadAtt_Click(object sender, EventArgs e)
        {
            if (lvMails.SelectedItems.Count == 1)
            {
                try
                { 
                    int? idx = Convert.ToInt32(lvMails.SelectedItems[0].SubItems[4].Text);
                    if (idx.HasValue)
                    {
                        bool moved = await _imapService.ProcessMailAttachments(idx.Value);
                        if (moved)
                            MessageBox.Show("Attachments downloaded.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Error occured attachments download: {ex.Message}.");
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _imapService.OpenConnection();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _imapService.CloseConnection();
        }
    }
}
