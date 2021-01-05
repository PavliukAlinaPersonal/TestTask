using OpenQA.Selenium;
using TestFramework.General;

namespace TestFramework.Pages
{
    public class PageProduct : PagePattern// страница товара
    {
        public string TextBoxCharacterType => GeneralFunctions.NoSpaces(WaitElement(By.XPath(
            "//tbody//tr[3]//td[contains(@class,'param')]"), Wtime).Text);
    }
}
