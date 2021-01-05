using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.General;

namespace TestFramework.Pages
{
    public class PageProduct : PagePattern// страница товара
    {

        public string TextBoxCharacterType => GeneralFunctions.NoSpaces(WaitElement(By.XPath(
            "//tbody//tr[3]//td[contains(@class,'param')]"), Wtime).Text);

    }
}
