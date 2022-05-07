using MailKit;
using MailKit.Net.Imap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using MimeKit;

namespace ImapTest
{
    public class ImapService
    {
        ImapClient _client;
        private readonly ILogger<ImapService> _logger;
        private readonly IConfiguration _config;
        private List<IMessageSummary> _mailList;
        public ImapService(ILogger<ImapService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _mailList = new List<IMessageSummary>();
            _client = new ImapClient();
        }

        public void OpenConnection()
        {
            if(!_client.IsConnected)
            {
                try
                {
                    var credentials = new NetworkCredential(_config.GetSection("Imap").GetValue<string>("mailAddress"), _config.GetSection("Imap").GetValue<string>("mailPass"));
                    var uri = new Uri($"imaps://{_config.GetSection("Imap").GetValue<string>("mailServer")}");

                    _client.Connect(uri);
                    _client.AuthenticationMechanisms.Remove("XOAUTH2");
                    _client.Authenticate(credentials);
                    _logger.LogInformation("Connection opened with mail server.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured during connection attempt: {ex.Message}");
                }
            }
        }

        public void CloseConnection()
        {
            if(_client.IsConnected)
            {
                _client.Disconnect(true);
            }
        }

        public async Task<IList<IMessageSummary>> GetInboxMessages()
        {
            IList<IMessageSummary> messageSummaries = new List<IMessageSummary>();
            try
            {
                await _client.Inbox.OpenAsync(FolderAccess.ReadOnly);

                if (_client.Inbox.Count > 0)
                {
                    messageSummaries = await _client.Inbox.FetchAsync(0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId);
                }
                await _client.Inbox.CloseAsync();
                _mailList = messageSummaries.ToList();
            }
            catch (Exception ex)
            {
                messageSummaries.Clear();
                _logger.LogError($"Error occured during messages fetch: {ex.Message}");
            }

            return messageSummaries;
        }

        public async Task<bool> ProcessMailAttachments(int index)
        {
            IMessageSummary messageSummary = _mailList.FirstOrDefault(m => m.Index == index);
            if (messageSummary == null)
                return false;
            bool result = false;
            try
            {
                await _client.Inbox.OpenAsync(FolderAccess.ReadOnly);
                foreach (BodyPartBasic att in messageSummary.BodyParts)
                {
                    if (!String.IsNullOrEmpty(att.FileName) && att.FileName.Contains(".xlsx"))
                    {
                        var mime = (MimePart)await _client.Inbox.GetBodyPartAsync(messageSummary.UniqueId, att);
                        using (var stream = File.Create($"DownloadedAttachments/{att.FileName}"))
                        {
                            mime.Content.DecodeTo(stream);
                        }
                    }
                }
                await _client.Inbox.CloseAsync();
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during attechemnts download: {ex.Message}");
            }
            return result;
        }

        public async Task<IList<IMailFolder>> GetFolders()
        {
            IList<IMailFolder> folderList = new List<IMailFolder>();
            try
            {
                folderList = await _client.GetFoldersAsync(_client.PersonalNamespaces[0]);
            }
            catch(Exception ex)
            {
                folderList.Clear();
                _logger.LogError($"Error occured during get folder process: {ex.Message}.");
            }
            return folderList;
        }

        public async Task<bool>CreateMailFolder(string name)
        {
            bool result = false;
            try
            {
                IList<IMailFolder> allFolders = await _client.GetFoldersAsync(_client.PersonalNamespaces[0]);
                if (allFolders.Any(x => x.FullName == name))
                {
                    _logger.LogInformation($"Subdirectory '{name}' already exists.");
                    result = false;
                }
                else
                {
                    var topLevel = _client.GetFolder(_client.PersonalNamespaces[0]);
                    var newFolder = await topLevel.CreateAsync(name, true);
                    if (newFolder is IMailFolder)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during directory creation: {ex.Message}.");
                result = false;
            }

            return result;
        }

        public async Task<bool>MoveMessageToFolder(string folderName)
        {
            bool result = false;
            try
            {
                var topLevel = _client.GetFolder(_client.PersonalNamespaces[0]);
                var destinationFolder = topLevel.GetSubfolder(folderName);
                if (destinationFolder is IMailFolder)
                {
                    IList<IMessageSummary> inboxMails = await GetInboxMessages();
                    await _client.Inbox.OpenAsync(FolderAccess.ReadWrite);
                    foreach (IMessageSummary messageSummary in inboxMails)
                    {
                        await _client.Inbox.MoveToAsync(messageSummary.UniqueId, destinationFolder);
                    }
                    await _client.Inbox.CloseAsync();
                }
                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured during messages move: {ex.Message}.");
                result = false;
            }

            return result;
        }
    }
}
