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
    //пэйдж страницы досуг
    public class HobbyPage
    {
        public HobbyPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //создание нового события
        public HobbyPage OpenHobbyPage()
        {
            //пейдж модуля досуг
            var btnCreateEvent = new WebItem("//span[@class='ui-btn-text' and text()='Создать']", "тык на кнопку создать");
            btnCreateEvent.Click();

            return new HobbyPage();
        }

        //пейдж создания события
        public CreateEventPage OpenEventFrame()
        {
            var createEventFrame = new WebItem("//iframe[contains(@id, 'iframe')]", "переключаемся на фрейм создания события");
            createEventFrame.WaitElementDisplayed();
            createEventFrame.SwitchToFrame();

            return new CreateEventPage();
        }

        //завершение события
        public HobbyPage EndEvent()
        {
            var menuEvent = new WebItem("//a[@class='main-grid-row-action-button' and contains(@data-actions, 'Завершить')]", "кнопка меню три полоски");
            var endEvent = new WebItem("//span[@class='menu-popup-item-text' and text()='Завершить']", "тык завершить");
            var popupAccept = new WebItem("//button[@class='ui-btn ui-btn-sm ui-btn-primary']", "кнопка ОК в попапе 'вы уверены'");
            menuEvent.Click();
            endEvent.Click();
            popupAccept.Click();

            return new HobbyPage();
        }

        //удаление события
        public HobbyPage DeleteEvent()
        {
            var menuEvent = new WebItem("//a[@class='main-grid-row-action-button' and contains(@data-actions, 'Удалить')]", "кнопка меню три полоски");
            var endEvent = new WebItem("//span[@class='menu-popup-item-text' and text()='Завершить']", "тык удалить");
            var popupAccept = new WebItem("//button[@class='ui-btn ui-btn-sm ui-btn-primary']", "кнопка ОК в попапе 'вы уверены'");
            menuEvent.Click();
            endEvent.Click();
            popupAccept.Click();

            return new HobbyPage();
        }
    }
}
