using NUnit.Framework;
using TestFramework.Pages;
using TestFramework.Tests;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;
using TestFramework.General;
using OpenQA.Selenium;
using NUnit.Framework.Internal;
using TestFramework.Pages.Authorythation;

namespace TestFramework
{
    [TestFixture(typeof(ChromeDriver))]
    //[TestFixture(typeof(string))]
    [Category("Авторизация")]
    class TestsAutoryzation<TBrowser> : TestBase<TBrowser> //Test Suite для проверки авторизации
    {
        [Test]
        [Category("Alina Pavliuk"), Description("Авторизирован пользователь через API")]
        public void ApiAuthorization()
        {
            GeneralFunctions.Authoryzation();//Авторизировались

            Assert.Multiple(() => 
            { 
            Assert.IsTrue(GeneralFunctions.ApiError(Apis.ResultAuthorization, "Проверели что результат запроса не содержит сообщений об ошибках"));
            Assert.IsTrue(GeneralFunctions.ApiResultCorrect(Apis.ResultAuthorization, "form-identification-form",
                "Проверели что результат запроса содержит форму из личного кабинета пользователя"));
            });
        }

    }
}

