using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;


namespace LambdaTestDemo
{
    public class LambdaTestConfig
    {
        public static IWebDriver InitDriver()
        {
            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("username", "shivangiawasthi717");
            ltOptions.Add("accessKey", "LT_50SxLeLKo87nTy8isjqS9dIiDKxKmaVDnZuAtRM8TBTE6bs");
            ltOptions.Add("visual", true);
            ltOptions.Add("video", true);
            ltOptions.Add("console", true);
            ltOptions.Add("platformName", "Windows 10");
            ltOptions.Add("resolution", "1024x768");
            ltOptions.Add("network", true);
            ltOptions.Add("project", "Selenium c#");
           // ltOptions.Add("tunnel", true);
            ltOptions.Add("w3c", true);
            ltOptions.Add("plugin", "c#-nunit");

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalOption("LT:Options", ltOptions);

            return new RemoteWebDriver(new Uri("https://hub.lambdatest.com/wd/hub"), options);
        }
    }
}
