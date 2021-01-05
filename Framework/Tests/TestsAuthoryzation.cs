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
    [Category("�����������")]
    class TestsAutoryzation<TBrowser> : TestBase<TBrowser> //Test Suite ��� �������� �����������
    {
        [Test]
        [Category("Alina Pavliuk"), Description("������������� ������������ ����� API")]
        public void ApiAuthorization()
        {
            GeneralFunctions.Authoryzation();//����������������

            Assert.Multiple(() => 
            { 
            Assert.IsTrue(GeneralFunctions.ApiError(Apis.ResultAuthorization, "��������� ��� ��������� ������� �� �������� ��������� �� �������"));
            Assert.IsTrue(GeneralFunctions.ApiResultCorrect(Apis.ResultAuthorization, "form-identification-form",
                "��������� ��� ��������� ������� �������� ����� �� ������� �������� ������������"));
            });
        }

    }
}

