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
    public class CalendarPage
    {
        public CalendarPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Удаление события из календаря
        /// </summary>
        /// <returns></returns>
        public CalendarPage DeleteEventFromCalendar()
        {
            var choiceTestEvent = new WebItem("//span[contains(text(), 'Досуг') and contains(text(), 'тестовое событие')]", "выбор тестового события");
            var btnDeleteEvent = new WebItem("//button[.//span[@class='ui-btn-text' and text()='Удалить']]", "тык на кнопку удалить");

            choiceTestEvent.Click();
            btnDeleteEvent.Click();

            return new CalendarPage(Driver);
        }
    }
}
