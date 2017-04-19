﻿using NLog.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Dynamic;

namespace NLog.Targets.Splunk.Tests
{
    [TestClass]
    public class SplunkHttpEventCollectorTests
    {
        private ILogger _logger = null;

        [TestInitialize()]
        public void Initialize()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();

            // Step 2. Create target and add it to the configuration 
            var splunkHttpEventCollector = new SplunkHttpEventCollector();
            config.AddTarget("splunkTarget", splunkHttpEventCollector);

            // Step 3. Set target properties 
            splunkHttpEventCollector.ServerUrl = new Uri("https://localhost:8088");
            splunkHttpEventCollector.Token = "1A29471E-3F18-4412-B032-80DD5712B691";
            splunkHttpEventCollector.RetriesOnError = 0;
            splunkHttpEventCollector.IgnoreSslErrors = true;
            splunkHttpEventCollector.Layout = "${message}";

            // Step 4. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Trace, splunkHttpEventCollector);
            config.LoggingRules.Add(rule1);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
            LogManager.ReconfigExistingLoggers();

            // Step 6. Create logger
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        private object CreateTestPropertyObjects()
        {
            dynamic obj = new ExpandoObject();
            obj.Name = "SplunkHttpEventCollector";
            obj.Type = "Nlog.Targets.SplunkHttpEventCollector";
            obj.IsOpenSource = true;

            return obj;
        }

        [TestMethod]
        public void SendFatalWithException()
        {
            _logger.Fatal(new Exception(), "This is a Fatal log message with an Exception");
            
        }

        [TestMethod]
        public void SendFatalWithoutException()
        {
            _logger.Fatal("This is a Fatal log message without an Exception");
        }

        [TestMethod]
        public void SendFatalWithCustomProperties()
        {
            LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Fatal, this.GetType().Name, "This is a Fatal log message with custom properties");
            logEventInfo.Properties.Add("Custom Object", CreateTestPropertyObjects());
            _logger.Fatal(logEventInfo);
        }

        [TestMethod]
        public void SendErrorWithException()
        {
            _logger.Error(new Exception(), "This is a Error log message with an Exception");
        }

        [TestMethod]
        public void SendErrorWithoutException()
        {
            _logger.Error("This is a Error log message without an Exception");
        }

        [TestMethod]
        public void SendErrorWithCustomProperties()
        {
            LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Error, this.GetType().Name, "This is a Error log message with custom properties");
            logEventInfo.Properties.Add("Custom Object", CreateTestPropertyObjects());
            _logger.Error(logEventInfo);
        }

        [TestMethod]
        public void SendWarnWithException()
        {
            _logger.Warn(new Exception(), "This is a Warn log message with an Exception");
        }

        [TestMethod]
        public void SendWarnWithoutException()
        {
            _logger.Warn("This is a Warn log message without an Exception");
        }

        [TestMethod]
        public void SendWarnWithCustomProperties()
        {
            LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Warn, this.GetType().Name, "This is a Warn log message with custom properties");
            logEventInfo.Properties.Add("Custom Object", CreateTestPropertyObjects());
            _logger.Warn(logEventInfo);
        }

        [TestMethod]
        public void SendInfoWithException()
        {
            _logger.Info(new Exception(), "This is a Info log message with an Exception");
        }

        [TestMethod]
        public void SendInfoWithoutException()
        {
            _logger.Info("This is a Info log message without an Exception");
        }

        [TestMethod]
        public void SendInfoWithCustomProperties()
        {
            LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Info, this.GetType().Name, "This is an Info log message with custom properties");
            logEventInfo.Properties.Add("Custom Object", CreateTestPropertyObjects());
            _logger.Info(logEventInfo);
        }

        [TestMethod]
        public void SendDebugWithException()
        {
            _logger.Debug(new Exception(), "This is a Debug log message with an Exception");
        }

        [TestMethod]
        public void SendDebugWithoutException()
        {
            _logger.Debug("This is a Debug log message without an Exception");
        }

        [TestMethod]
        public void SendDebugWithCustomProperties()
        {
            LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Debug, this.GetType().Name, "This is a Debug log message with custom properties");
            logEventInfo.Properties.Add("Custom Object", CreateTestPropertyObjects());
            _logger.Debug(logEventInfo);
        }

        [TestMethod]
        public void SendTraceWithException()
        {
            _logger.Trace(new Exception(), "This is a Trace log message with an Exception");
        }

        [TestMethod]
        public void SendTraceWithoutException()
        {
            _logger.Trace("This is a Trace log message without an Exception");
        }

        [TestMethod]
        public void SendTraceWithCustomProperties()
        {
            LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Trace, this.GetType().Name, "This is a Trace log message with custom properties");
            logEventInfo.Properties.Add("Custom Object", CreateTestPropertyObjects());
            _logger.Trace(logEventInfo);
        }



    }
}
