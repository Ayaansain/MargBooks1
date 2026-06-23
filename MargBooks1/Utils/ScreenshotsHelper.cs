using OpenQA.Selenium;
using System;
using System.IO;

namespace MargBooks1.Utils
{
    public static class ScreenshotHelper
    {
        public static string Capture(IWebDriver driver, string name)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot ss = ts.GetScreenshot();

            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"{name}_{DateTime.Now.Ticks}.png");

            ss.SaveAsFile(path);
            return path;
        }
    }
}