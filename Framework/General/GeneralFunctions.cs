using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TestFramework.Pages;
using TestFramework.Pages.Authorythation;

namespace TestFramework.General
{
    public delegate IWebElement Condition(IWebElement element);
    public delegate bool Check();


    class GeneralFunctions
    {
        public static IWebDriver driver { get => Drivers.dr; }// Ссылка на обьект драйвера в классе Driver
        public static int Wtime { get => Drivers.Wt; }// Ссылка на переменную времени ожидания по умолчанию в классе Driver



        /// <summary>
        /// Ищет на странице веб элемент по сss селектору
        /// </summary>
        /// <param name="driver">обьект драйвера</param>
        /// <param name="selector">css селектор веб элемента</param>
        /// <param name="timeSeconds">максимальное время ожидания</param>
        /// <param name="cnd">обьект делегата Condition</param>
        /// <returns>веб элемент</returns>
        public static IWebElement WaitElement(IWebDriver driver, By selector, int timeSeconds, Condition cnd)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
            return wait.Until((x) =>
            {
                IWebElement element = driver.FindElement(selector);
                
                return cnd(element);
            });
        }


        /// <summary>
        /// Проверяет что веб элемент существует, отображен на сайте и кликабельный
        /// </summary>
        /// <param name="element">веб элемент</param>
        /// <returns>при успехе - веб эемент, при провале - null</returns>
        public static IWebElement ExistDisplayedEnabled(IWebElement element) 
        { 
            return (element != null && element.Displayed && element.Enabled) ? element : null; 
        }


        /// <summary>
        /// Проверяет что веб элемент существует и отображен на сайте
        /// </summary>
        /// <param name="element">веб элемент</param>
        /// <returns>при успехе - веб эемент, при провале - null</returns>
        public static IWebElement ExistDisplayed(IWebElement element)
        {
            return (element != null && element.Displayed) ? element : null;
        }

        /// <summary>
        /// Проверяет что веб элемент существует
        /// </summary>
        /// <param name="element">веб элемент</param>
        /// <returns>при успехе - веб эемент, при провале - null</returns>
        public static IWebElement Exist(IWebElement element)
        {
            return (element != null) ? element : null;
        }

        /// <summary>
        /// Удаляет в строке буквы и пробелы
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>строка без букв и пробелов</returns>
        public static string LeftNumbers(string str)
        {
            string num = Regex.Replace(str, @"[a-zA-Z\s]+", "");
            return num;
        }

        /// <summary>
        /// Удаляет в строке пробелы
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>строка без пробелов</returns>
        public static string NoSpaces(string str)
        {
            string nspace = Regex.Replace(str, @"[\s]+", "");
            return nspace;
        }


        /// <summary>
        /// Очищает текстовое поле и вписывает в него строку
        /// </summary>
        /// <param name="field">веб элемент текстового поля</param>
        /// <param name="text">строка</param>
        public static void CleanAndSendTextField(IWebElement field, string text)
        {
            Actions actions = new Actions(driver);
            actions.Click(field).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Delete).SendKeys(text).SendKeys(Keys.Enter).Build().Perform();

        }

        /// <summary>
        /// Ждет пока текст в веб элементе будет отличаться от заданой строки, по истечению времени выбрасывает ошибку
        /// </summary>
        /// <param name="selector">css селектор веб элемента</param>
        /// <param name="text">строка</param>
        /// <param name="time">максимальное время ожидания</param>
        public static void WaitDifferentText(By selector, string text, int time)
        {
            bool check = true;

            for (int i = 0; i < Wtime * 2; i++)
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(selector));
                IWebElement element = driver.FindElement(selector);
                string elementText = element.Text;
                if (elementText != text) { check = false; break; }
                Thread.Sleep(500);
            }
            if (check) { throw new ArgumentException("text is same"); }
        }

        /// <summary>
        /// Авторизируеться через API запрос
        /// </summary>
        /// <param name="comm">строка-комментарий</param>
        public static void Authoryzation()
        {
            try
            {
                Apis.Authoryze().Wait();

            }
            catch (AggregateException ae)
            {
                Console.WriteLine($"EXCEPTION: {ae.Message}");
            }
        }


        /// <summary>
        /// Проверяет что результат запроса не содержит сообщений об ошибках
        /// </summary>
        /// <param name="result">результат запроса</param>
        /// <param name="comm">строка-комментарий</param>
        /// <returns></returns>
        public static bool ApiError(string result, string comm)
        {
            MatchCollection Status = Regex.Matches(result, @"ERROR");
            return Status.Count == 0;
        }


        /// <summary>
        /// Проверяет что результат запроса содержит строку
        /// </summary>
        /// <param name="result">результат запроса</param>
        /// <param name="textSuccess">строка</param>
        /// <param name="comm">строка-комментарий</param>
        /// <returns></returns>
        public static bool ApiResultCorrect(string result, string textSuccess, string comm)
        {
            MatchCollection Status = Regex.Matches(result, textSuccess);
            return Status.Count > 0;
        }

       
    }
}
