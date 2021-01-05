using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.General;

namespace TestFramework.Pages
{
    abstract public class PagePattern : PageBase
    {
        public IWebElement ButtonGroupPhone => WaitElement(By.XPath("//nav//a[contains(@src,'thumb-1') and @data-url]"), Wtime);
        public IWebElement PopupMenuActive => WaitElement(By.XPath("//li[contains(@class,'menu-ico-1 act')]"), Wtime);
        public IWebElement ButtonSubGroupSmartphone => WaitElement(By.XPath("//nav//a[contains(@href,'telefonlar/smartfonlar')]"), Wtime);


        public PagePattern() { Url = ""; }


    }
}
