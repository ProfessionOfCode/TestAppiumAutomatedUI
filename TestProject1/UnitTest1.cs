using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace TestProject1
{
    public class Tests
    {
        private WindowsDriver _session;
        [SetUp]
        public void Setup()
        {
            var capabilities = new AppiumOptions
            {
                PlatformName = "Windows",
                DeviceName = "WindowsPC",
                App = "e9adad23-327d-4ca5-b983-a7a570c0d6c5_zq1yw5zts9nct!App",
                AutomationName = "Windows"
            };

            //System.Environment.SetEnvironmentVariable("APPIUM_HOME", @"C:\Users\steph\.appium");

            // self-hosted Appium server setup
            var appiumLocalService = new AppiumServiceBuilder()
                .UsingAnyFreePort()
                .WithLogFile(new FileInfo(@"C:\Users\steph\.appium\appium.log"))
                .Build();

            _session = new WindowsDriver(appiumLocalService, capabilities);      //new Uri("http://192.168.221.1:4723")
        }

        static void RunInstallerQuietly(string installerPath, string arguments)
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = installerPath,
                        Arguments = arguments,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };

                process.Start();

                // Optional: Capture output and errors for debugging
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Log or handle output and errors
                if (!string.IsNullOrEmpty(output))
                    Debug.WriteLine($"Output: {output}");
                if (!string.IsNullOrEmpty(error))
                    Debug.WriteLine($"Error: {error}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
        }

        [TearDown]
        public void TearDown()
        {
            _session.Quit();
            _session.Dispose();
        }


        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}