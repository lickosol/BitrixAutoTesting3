using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Hobbies
{
    public class CreateEventPage : CreateEventFrame
    {
        /// <summary>
        /// Метод создания события в iframe "Создать событие"
        /// </summary>
        /// <returns></returns>
        public HobbyPage CreateEvent()
        {
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

        /// <summary>
        /// Метод добавления iframe Создать событие в левое меню нажатием на кнопку Избранное
        /// </summary>
        /// <returns></returns>
        public HobbyPage AddCreationFrameInLeftMenu()
        {
            //элемент-звезда
            var starButton = new WebItem("//span[@id='uiToolbarStar']", "кнопка звезды (добавить в левое меню)");

            //получение значения title
            string starTitle = starButton.GetAttribute("title");

            //проверка значения title
            if (starTitle == "добавить текущую страницу в левое меню")
            {
                Console.WriteLine("нажимаем на звезду — добавляем в левое меню");
                starButton.Click();
            }
            else
            {
                Console.WriteLine("страница уже добавлена в левое меню => переходим к закрытию окна создания события");
            }


            //переход в родительский фрейм
            var newFrame = new WebItem("//iframe[contains(@id, 'iframe_c2arcz45g0')]", "iframe после создания события");
            newFrame.WaitElementDisplayed();

            BaseItem.DefaultDriver.SwitchTo().DefaultContent();

            //тык на закрыть окно
            var closeFrame = new WebItem("//div[@class='side-panel-label-icon-box' and @title='Закрыть']", "кнопка 'Закрыть' окно");
            closeFrame.Click();

            return new HobbyPage(); 
        }
    }
}
