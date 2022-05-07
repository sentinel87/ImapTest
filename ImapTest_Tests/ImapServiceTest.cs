using ImapTest;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ImapTest_Tests
{
    public class ImapServiceTest
    {
        ImapService _imapService;
        Mock<ILogger<ImapService>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder();
            buildConfig(builder);
            var configRoot = builder.Build();
            _loggerMock = new Mock<ILogger<ImapService>>();
            _imapService = new ImapService(_loggerMock.Object, configRoot);
        }

        void buildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "production"}.json", optional: true)
                .AddEnvironmentVariables();
        }

        [Test]
        public async Task GetInboxMessages()
        {
            _imapService.OpenConnection();
            IList<MailKit.IMessageSummary>summaries =  await _imapService.GetInboxMessages();
            _loggerMock.Verify(
                m => m.Log(LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Error occured during messages fetch:")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Never
            );
            _imapService.CloseConnection();
        }

        [Test]
        public async Task GetFolders()
        {
            _imapService.OpenConnection();
            IList<MailKit.IMailFolder> folderNames = await _imapService.GetFolders();
            _loggerMock.Verify(
                m => m.Log(LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Error occured during get folder process:")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Never
            );
            _imapService.CloseConnection();
        }
    }
}
