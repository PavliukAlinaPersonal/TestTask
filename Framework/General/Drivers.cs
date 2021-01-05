using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestFramework
{
    public class Drivers
    {
        public static IWebDriver dr;

        public static int Wt { get => 20; }// Переменная времени ожидания по умолчанию
        public static string baseUrl { get => "https://maxi.az/"; } //URL главной страницы maxi
        public static string baseUrlLocal { get => baseUrl + "/ru/"; }//URL главной страницы maxi с русской локализацией

        /// <summary>
        /// создает обьект драйвера
        /// </summary>
        /// <param name="browser">ch - создать Chrome driver; ch-hd - создать Chrome driver headless; fr - создать Firefox driver</param>
        public Drivers(string browser)
        {
            ChromeOptions optionsAll = new ChromeOptions();
            optionsAll.AddArgument("--start-maximized");
            optionsAll.AddArgument("--disable-notifications");
            optionsAll.AddArgument("–disable-infobars");
            optionsAll.AddArgument("--disable-popup-blocking");

            switch (browser)
            {
                case "ch":
                    dr = new ChromeDriver(optionsAll);
                    break;
                case "ch-hd":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--headless");
                    dr = new ChromeDriver(options);
                    break;
                case "fr":
                    dr = new FirefoxDriver();
                    break;
            }
        }
    }
}
