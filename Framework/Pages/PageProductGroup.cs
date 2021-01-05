using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestFramework.General;

namespace TestFramework.Pages
{
    public class PageProductGroup :PagePattern
    {
        public PageProductGroup() { Url = "telefonlar-ve-plansetler/telefonlar/smartfonlar/"; }

        public IWebElement FormFilters => WaitElement(By.XPath(
            "//div[contains(@id,'custom_filter_properties')]"), Wtime);
       

        public IWebElement ButtonFilterCharacter => WaitElement(By.XPath(
            "(//div[@id and @data-code]//div)[3]"), Wtime);
        public string TextFilterCharacter => GeneralFunctions.NoSpaces((((WaitElement(By.XPath(
            "((//div[contains(@class,'comments_container')])[3]//label//a[@onclick])[1]"), Wtime)).Text).Split("(")[0]));
        public IWebElement ButtonFilterCharacterActive => WaitElement(By.XPath(
            "//div[contains(@id,'custom_filter_active')]//div[contains(@class,'one-act-filt')]//a"), Wtime);
       
        
        public IWebElement ButtonProductName => WaitElement(By.XPath(
            "//div[contains(@id,'bx')]//div[contains(@class,'one-cat-item-tit')]//a[contains(@href,'telefonlar')]"), Wtime);


        public IWebElement ButtonPriceSort => WaitElement(By.XPath("//a[contains(@data-jsl,'CATALOG_PRICE')]"), Wtime);
        public IWebElement ButtonPriceSortActive => WaitElement(By.XPath("" +
            "//a[contains(@data-jsl,'CATALOG_PRICE') and contains(@class,'act')]"), Wtime);


        public const string StringProductPrice = "(//div[contains(@class,'cont')]//div[contains(@id,'bx')]//div[contains(@class,'price')]//span[contains(@class,'nowrap')])[{0}]";
        
        public double TextProductPriceFirst => double.Parse(GeneralFunctions.LeftNumbers(WaitElement(By.XPath(
           string.Format(StringProductPrice, 1)), Wtime).Text));
        public double TextProductPriceSecond => double.Parse(GeneralFunctions.LeftNumbers(WaitElement(By.XPath(
           string.Format(StringProductPrice, 2)), Wtime).Text));


        public IWebElement TextBoxPriceRollFirst => WaitElementNoFullLoad(By.XPath("//input[@id='filter_price_from']"), Wtime);
        public IWebElement TextBoxPriceRollSecond => WaitElementNoFullLoad(By.XPath("//input[@id='filter_price_to']"), Wtime);
        public IWebElement ButtonRollFilterActive => WaitElement(By.XPath("//div[contains(@class,'one-act-filt')]//a"), Wtime);
        
        
        public By ButtonRollFilterActiveSelctor => By.XPath("//div[contains(@class,'one-act-filt')]//a");

    }
}
