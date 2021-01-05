using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestFramework.Pages;

namespace TestFramework.Tests
{
    /// <summary>
    /// Базовый класс для всех Test Suite классов
    /// </summary>
    /// <typeparam name="TBrowser">Тип браузера в котором запустятся тесты: Chrome, Firefox, string (запуск headless Chrome)</typeparam>
    public class TestBase<TBrowser> //Базовый класс для всех Test Suite классов
    {
        public IWebDriver driver { get => Drivers.dr; }// Ссылка на обьект драйвера в классе Driver
        public string baseUrl { get => Drivers.baseUrlLocal; }// Ссылка на URL главной страницы maxi в классе Driver
        public int Wtime { get => Drivers.Wt; }// Ссылка на переменную времени ожидания по умолчанию в классе Driver

        public PageMain PMain = new PageMain(); // обьект главной страницы
        public PageProductGroup PProdGroup = new PageProductGroup();// обьект страницы группы товаров
        public PageProduct PProd = new PageProduct();// обьект страницы товара

        /// <summary>
        /// Создает обьект браузера, выполняеться перед каждым Test Suite-ом
        /// </summary>
        [SetUp]
        public void CreateDriver()
        {
            if (typeof(TBrowser) == typeof(ChromeDriver)) { new Drivers("ch"); }

            if (typeof(TBrowser) == typeof(FirefoxDriver)) { new Drivers("fr"); }

            if (typeof(TBrowser) == typeof(string)) { new Drivers("ch-hd"); }
        }

        /// <summary>
        /// Финализация обьекта браузера, выполняеться после каждого Test Suite-а
        /// </summary>
        [TearDown]
        public void TeardownTest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
