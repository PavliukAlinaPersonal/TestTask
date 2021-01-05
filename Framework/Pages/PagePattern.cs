using OpenQA.Selenium;

namespace TestFramework.Pages
{
    abstract public class PagePattern : PageBase//шаблонная страница, общая для всех страниц maxi
    {
        public IWebElement ButtonGroupPhone => WaitElement(By.XPath("//nav//a[contains(@src,'thumb-1') and @data-url]"), Wtime);
        public IWebElement PopupMenuActive => WaitElement(By.XPath("//li[contains(@class,'menu-ico-1 act')]"), Wtime);
        public IWebElement ButtonSubGroupSmartphone => WaitElement(By.XPath("//nav//a[contains(@href,'telefonlar/smartfonlar')]"), Wtime);

        public PagePattern() { Url = ""; }
    }
}
