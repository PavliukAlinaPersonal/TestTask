using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TestFramework.General;
using TestFramework.Tests;

namespace TestFramework
{
    [TestFixture(typeof(ChromeDriver))]
    //[TestFixture(typeof(string))]
    [Category("Фильтры")]
    class TestsFilters<TBrowser> : TestBase<TBrowser> //Test Suite для проверки фильтров товаров
    {

        [Test]
        [Category("Alina Pavliuk"), Description("Товары отфильтрованы по производителю")]
        public void FilterProducts()
        {
            PMain.Navigate();//Перешли на главную страницу
            PMain.ButtonGroupPhone.Click();//Нажали на кнопку группы товаров
            PMain.Wait(PMain.PopupMenuActive);//Дождались открытия меню
            PMain.ButtonSubGroupSmartphone.Click(); //Нажали на кнопку подгруппы товаров в меню

            PMain.Wait(PProdGroup.FormFilters);//Дождались открытия странцы группы товаров

            PProdGroup.ButtonFilterCharacter.Click();//Выбрали фильтр по первому производителю в списке производителей
            string characterName = PProdGroup.TextFilterCharacter;//Запомнили название выбранного производителя
            PProdGroup.Wait(PProdGroup.ButtonFilterCharacterActive);//Дождались отфильтрованой страницы
            PProdGroup.ButtonProductName.Click();//Перешли на страницу товара-результата поиска

            Assert.AreEqual(PProd.TextBoxCharacterType, characterName,
                "Название производителя товара на странице товара равно названию выбранного производителя");
        }


        [Test]
        [Category("Alina Pavliuk"), Description("Товары отсортированы по убыванию цены")]
        public void SortPriceProductsDescending()
        {
            GeneralFunctions.Authoryzation();//Авторизировались

            PProdGroup.Navigate();//Перешли на страницу группы товаров
            PProdGroup.ButtonPriceSort.Click();//Выбрали сортировку по убыванию цены
            PProdGroup.Wait(PProdGroup.ButtonPriceSortActive);//Дождались отсортированой страницы

            Assert.IsTrue(PProdGroup.TextProductPriceFirst >= PProdGroup.TextProductPriceSecond,
                "Значение цены первого по счету в списке товаров товара больше или равно значению второго товара");
        }

        [Test]
        [Category("Alina Pavliuk"), Description("Товары выбраны по диапазону цены")]
        public void SortPriceProductsRoll()
        {
            PProdGroup.Navigate();//Перешли на страницу группы товаров
            double price = PProdGroup.TextProductPriceSecond;//Запомнили значение цены второго товара в списке товаров

            GeneralFunctions.CleanAndSendTextField(PProdGroup.TextBoxPriceRollFirst, price.ToString());//Введена цена второго товара на странице в поле ограничения минимальной цены
            PProdGroup.Wait(PProdGroup.ButtonRollFilterActive);//Дождались отсортированой страницы
            string text = PProdGroup.ButtonRollFilterActive.Text;//Запомнили значение текста на иконке активного фильтра

            GeneralFunctions.CleanAndSendTextField(PProdGroup.TextBoxPriceRollSecond, price.ToString());//Введена цена второго товара на странице в поле ограничения максимальной цены
            GeneralFunctions.WaitDifferentText(PProdGroup.ButtonRollFilterActiveSelctor, text, Wtime);//Дождались изменения текста на иконке активного фильтра
            
            Assert.IsTrue(PProdGroup.TextProductPriceFirst == price, 
                "Цена первого товара на странице равна введеной в поля ограничения цене");
        }


    }


}