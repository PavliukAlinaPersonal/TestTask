using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using TestFramework.General;
using TestFramework.Tests;

namespace TestFramework
{
    [TestFixture(typeof(ChromeDriver))]
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
                Assert.IsTrue(GeneralFunctions.ApiError(Apis.ResultAuthorization, "Результат запроса не содержит сообщений об ошибках"));
                Assert.IsTrue(GeneralFunctions.ApiResultCorrect(Apis.ResultAuthorization, "form-identification-form",
                    "Результат запроса содержит форму из личного кабинета пользователя"));
            });
        }

    }
}

