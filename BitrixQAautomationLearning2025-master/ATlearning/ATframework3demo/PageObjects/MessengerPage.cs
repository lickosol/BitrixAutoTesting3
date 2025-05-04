using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects
{
    public class MessengerPage
    {
        public MessengerPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        /// <summary>
        /// Открытие чата события
        /// </summary>
        /// <returns></returns>
        public MessengerPage OpenTestChat()
        {
            var openEvetnsChat = new WebItem("//span[@class='bx-im-chat-title__text' and text()='Досуг :: тестовое событие']", "открыть чат события");
            openEvetnsChat.Click();
            return this;
        }


        /// <summary>
        /// Получение текста первого сообщения в чате
        /// </summary>
        /// <returns></returns>
        public string GetFirstMessageText()
        {
            var firstMessage = new WebItem("//div[contains(@class,'bx-im-message-default-content__text')]", "первое сообщение в чате");
            firstMessage.WaitElementDisplayed();
            return firstMessage.InnerText();
        }


        /// <summary>
        /// Закрытие мессенджера
        /// </summary>
        /// <returns></returns>
        public HobbyPage CloseMessenger()
        {
            var btnClose = new WebItem("//div[@class='bx-im-navigation__close']", "кнопка закрытия мессенджера");
            btnClose.Click();
            return new HobbyPage();
        }
    }

}
