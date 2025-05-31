using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SwagLabs.Base;

public class DriverSetup
{
    private static readonly String? browser_name = ConfigurationManager.AppSettings["RunEnvironment"];
    public static DriverManager driverManager = new();

    public static IWebDriver LocalBrowserSetup(IWebDriver driver)
    {
        if (BrowserType.chrome.ToString().Equals(browser_name))
        {
            driverManager.SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
        }
        else if (BrowserType.Firefox.ToString().Equals(browser_name))
        {
            driverManager.SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
        }
        else if (BrowserType.IE.ToString().Equals(browser_name))
        {
            driverManager.SetUpDriver(new InternetExplorerConfig());
            driver = new InternetExplorerDriver();
        }
        else
        {
            Console.WriteLine("This browser can't be Selected, please check it out");
        }

        return driver;
    }
}