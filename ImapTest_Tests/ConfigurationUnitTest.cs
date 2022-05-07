using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace ImapTest_Tests
{
    public class ConfigurationUnitTest
    {
        private IConfigurationRoot _configRoot;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder();
            buildConfig(builder);
            _configRoot = builder.Build();
        }

        void buildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "production"}.json", optional: true)
                .AddEnvironmentVariables();
        }

        [Test]
        public void GetImapConfig()
        {
            string mailAddress = "";
            string mailPass = "";
            string mailServer = "";
            IConfiguration imapConfig = _configRoot.GetSection("Imap");
            if (imapConfig != null)
            {
                mailAddress = imapConfig.GetValue<string>("mailAddress");
                mailPass = imapConfig.GetValue<string>("mailAddress");
                mailServer = imapConfig.GetValue<string>("mailServer");
            }
            Assert.IsTrue(imapConfig != null);
            Assert.IsTrue(!String.IsNullOrEmpty(mailAddress));
            Assert.IsTrue(!String.IsNullOrEmpty(mailPass));
            Assert.IsTrue(!String.IsNullOrEmpty(mailServer));
        }
    }
}