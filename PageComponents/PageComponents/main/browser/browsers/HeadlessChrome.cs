using System.Diagnostics;
using OpenQA.Selenium.Chrome;

namespace PageComponents.browsers
{
    public static class HeadlessChrome
    {
        public static int Height { get; set; } = 962;
        public static int Width { get; set; } = 1768;
        public static int HeadlessHeight { get; set; } = 1020;
        public static int HeadlessWidth { get; set; } = 1980;

        public static ChromeDriver StartChrome(string path)
        {
            return new ChromeDriver(path, SetChromeDefaults());
        }

        private static ChromeOptions SetChromeDefaults()
        {
            var options = new ChromeOptions();

            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            if (!IsDebugging())
            {
                options.AddArgument("--headless");
                options.AddArgument($"--window-size={HeadlessWidth},{HeadlessHeight}");
            }
            else
            {
                options.AddArgument($"--window-size={Width},{Height}");
            }

            return options;
        }

        private static bool IsDebugging()
        {
            return Debugger.IsAttached;
        }
    }
}