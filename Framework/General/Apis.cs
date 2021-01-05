using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using TestFramework.Pages.Authorythation;
using System.IO;
using System.Text;

namespace TestFramework.General
{
    public delegate void Api();
    class Apis
    {
        public static IWebDriver driver { get => Drivers.dr; } // Ссылка на обьект драйвера в классе Driver

        public static string ResultAuthorization; //результат выполнения API запроса Авторизации


        /// <summary>
        /// Выполняет API запрос на авторизацию
        /// </summary>
        /// <returns></returns>
        public static async Task Authoryze()
        {

            driver.Navigate().GoToUrl(Drivers.baseUrlLocal);
            using var cl = new HttpClient();

            var res = await cl.GetAsync(Drivers.baseUrlLocal);
            var contents = await res.Content.ReadAsStringAsync();

            string resultString = Regex.Match(contents, @"name=""csrf-token"" content=""(.+?)""").Value;
            string res1 = Regex.Match(resultString, @"content=""(.+?)""").Value;
            string res2 = Regex.Match(res1, @"""(.+?)""").Value;
            string res3 = Regex.Match(res2, @"(\w+)").Value;


            driver.Navigate().GoToUrl(Drivers.baseUrlLocal);
            var cook = driver.Manage().Cookies.AllCookies;


            using var client = new HttpClient(GetCockie());


            var values = new Dictionary<string, string>
            {
                { "backurl", "/ajax.php" },
                { "AJAX", "Y" },
                { "data", "auth"},
                { "template", "" },
                { "sessid", res3 },
                { "lang", "ru"},
                { "AUTH_FORM", "Y" },
                { "TYPE", "AUTH" },
                { "USER_LOGIN", Users.UserAli.Email},
                { "USER_PASSWORD", Users.UserAli.Password},
                { "USER_REMEMBER", "N" },
                { "undefined", "Отмена"},
                { "redirect", "/"}
            };

            var content = new FormUrlEncodedContent(values);
            var result = await client.PostAsync(@Drivers.baseUrl + "ajax.php", content);


            ResultAuthorization = await result.Content.ReadAsStringAsync();
            driver.Navigate().Refresh();
        }


        /// <summary>
        /// Возвращает куки страницы в драйвере
        /// </summary>
        /// <returns>куки контейнер</returns>
        public static HttpClientHandler GetCockie()
        {
            var cook = driver.Manage().Cookies.AllCookies;
            CookieContainer cookies = new CookieContainer();

            foreach (var c in cook)
            {
                cookies.Add(new System.Net.Cookie(c.Name, c.Value, c.Path, c.Domain));
            }

            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;

            return handler;

        }

    }
    
}
