using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestFramework.General;
namespace TestFramework.Pages
{
    abstract public class PageBase
    {
        public static IWebDriver driver { get => Drivers.dr; }// Ссылка на обьект драйвера в классе Driver
        public static string baseUrl { get => Drivers.baseUrlLocal; }// Ссылка на URL главной страницы maxi в классе Driver
        public static int Wtime { get => Drivers.Wt; }// Ссылка на переменную времени ожидания по умолчанию в классе Driver
        public string Url;

        protected static int timeLoadPage = Wtime * 3;

        /// <summary>
        /// Ищет на полностью загруженной странице веб элемент по сss селектору
        /// </summary>
        /// <param name="selector">css селектор</param>
        /// <param name="time">максимальное время ожидания</param>
        /// <returns></returns>
        public static IWebElement WaitElement(By selector, int time)
        {
            WaitPageFullLoaded();
            return GeneralFunctions.WaitElement(driver, selector, time, new Condition(GeneralFunctions.ExistDisplayedEnabled));
        }

        /// <summary>
        ///  Ищет на полностью загруженной странице веб элемент по сss селектору
        /// </summary>
        /// <param name="selector">css селектор</param>
        /// <param name="time">максимальное время ожидания</param>
        /// <param name="cnd">обьект делегата Condition (условие для веб элемента)</param>
        /// <returns></returns>
        public static IWebElement WaitElement(By selector, int time, Condition cnd)
        {
            WaitPageFullLoaded();
            return GeneralFunctions.WaitElement(driver, selector, time, cnd);
        }

        /// <summary>
        /// Ищет на странице веб элемент по сss селектору
        /// </summary>
        /// <param name="selector">css селектор</param>
        /// <param name="time">максимальное время ожидания</param>
        /// <returns></returns>
        public static IWebElement WaitElementNoFullLoad(By selector, int time)
        {
            return GeneralFunctions.WaitElement(driver, selector, time, new Condition(GeneralFunctions.ExistDisplayedEnabled));
        }

        /// <summary>
        /// Ищет на странице веб элемент по сss селектору
        /// </summary>
        /// <param name="selector">css селектор</param>
        /// <param name="time">максимальное время ожидания</param>
        /// <param name="cnd">обьект делегата Condition (условие для веб элемента)</param>
        /// <returns></returns>
        public static IWebElement WaitElementNoFullLoad(By selector, int time, Condition cnd)
        {
            return GeneralFunctions.WaitElement(driver, selector, time, cnd);
        }

        /// <summary>
        /// Переходит на страницу указаную в поле URL класса страницы
        /// </summary>
        public void Navigate()
        {
            driver.Navigate().GoToUrl(Drivers.baseUrlLocal + Url);
            WaitPageFullLoaded();
        }

        /// <summary>
        /// Использовано ожидание в полях классов страниц
        /// </summary>
        /// <param name="element"></param>
        public void Wait(IWebElement element)
        {
        }

        /// <summary>
        /// Ждет пока страница полностью загрузиться
        /// </summary>
        /// <param name="time">максимальное время ожидания</param>
        public static void WaitPageFullLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeLoadPage));

            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
            });
        }
    }
}
