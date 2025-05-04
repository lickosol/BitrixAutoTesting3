using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using ATframework3demo.PageObjects.Hobbies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATframework3demo.PageObjects
{
    public class CreationEventFramePage : CreateEventFrame
    {
        public CreationEventFramePage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Создание события, если окно добавлено в левое меню
        /// </summary>
        /// <returns></returns>
        public HobbyPage CreateEventFromLeftMenu()
        {
            var createEventFrame = new WebItem("//iframe[contains(@id, 'iframe')]", "переключаемся на фрейм создания события");
            createEventFrame.WaitElementDisplayed();
            createEventFrame.SwitchToFrame();

            //ввод названия
            var addName = new WebItem("//input[@id='name_text']", "добавление названия");
            addName.Click();
            addName.SendKeys("тестовое событие");

            //добавление описания
            var addDescription = new WebItem("//textarea[@id='description_text']", "ввод текста описания");
            addDescription.Click();
            addDescription.SendKeys("Всем привет!");

            //выбор максимального количества участников 
            var maxParticipants = new WebItem("//input[@id='participants_limit_text']", "ввод максимального количества участников");
            maxParticipants.Click();
            maxParticipants.SendKeys("3");

            //выбор даты начала
            var dateOfBegin = new WebItem("//input[@name='START_AT']", "выбор даты начала");
            var numberOfDate = new WebItem("//a[text()='15']", "выбор числа даты начала ");
            dateOfBegin.Click();
            dateOfBegin.WaitElementDisplayed();
            numberOfDate.Click();

            //выбор ачивки
            var openAchivesList = new WebItem("//div[@class='ui-ctl-element' and contains(text(), 'Не выдавать')]", "тык на выбор ачивки");
            openAchivesList.Click();

            var coiceAchive = new WebItem("//span[@class='menu-popup-item-text' and contains(text(), 'Успех')]", "выбор ачивки из списка");
            coiceAchive.Click();

            //сохранение события
            var saveEvent = new WebItem("//button[@title='[Ctrl+Enter]' and text()='Сохранить']", "тык сохранить");
            saveEvent.Click();

            //переход на родительский фрейм для закрытия окна создания события
            var newFrame = new WebItem("//iframe[contains(@id, 'iframe_c2arcz45g0')]", "новый iframe после создания события");
            newFrame.WaitElementDisplayed();

            BaseItem.DefaultDriver.SwitchTo().DefaultContent();

            //тык на закрыть окно
            var closeFrame = new WebItem("//div[@class='side-panel-label-icon-box' and @title='Закрыть']", "тык закрыть окно");
            closeFrame.Click();

            return new HobbyPage();
        }
    }
}
