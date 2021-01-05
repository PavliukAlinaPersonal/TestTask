using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using TestFramework.General;
using TestFramework.Tests;

namespace TestFramework
{
    [TestFixture(typeof(ChromeDriver))]
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
                Assert.IsTrue(GeneralFunctions.ApiError(Apis.ResultAuthorization, "��������� ������� �� �������� ��������� �� �������"));
                Assert.IsTrue(GeneralFunctions.ApiResultCorrect(Apis.ResultAuthorization, "form-identification-form",
                    "��������� ������� �������� ����� �� ������� �������� ������������"));
            });
        }

    }
}

