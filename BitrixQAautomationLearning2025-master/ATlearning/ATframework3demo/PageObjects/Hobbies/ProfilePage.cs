using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Hobbies
{
    public class ProfilePage
    {
        public ProfilePage OpenProfile()
        {
            var btnProfile = new WebItem("//span[@id='user-name' and @class='user-name']", "тык на профиль");
            btnProfile.Click();

            var openProfile = new WebItem("//span[@class='ui-qr-popupcomponentmaker__btn --large --border' and text()='Профиль']", "кнопка 'Профиль' в меню");
            openProfile.Click();

            var profileFrame = new WebItem("//iframe[contains(@id, 'iframe') and contains(@src, '/company/personal/user/')]", "фрейм профиля");
            profileFrame.WaitElementDisplayed(10);
            profileFrame.SwitchToFrame();

            return this;
        }

        //получить текущее количество ачивок "Успех" (находясь внутри iframe профиля)
        public int GetThumbsUpAchiveCount()
        {
            var thumbsUpCounter = new WebItem(
                "//div[contains(@class, 'intranet-user-profile-thanks-item-thumbsup') and contains(@class, 'intranet-user-profile-thanks-item-active')]/div",
                "счетчик ачивки 'Успех'");

            string counterText = WaitForInnerText(thumbsUpCounter, timeoutSeconds: 5);

            Console.WriteLine($"начальное количество ачивок 'Успех': {counterText}");

            if (int.TryParse(counterText, out int result))
            {
                return result;
            }
            else
            {
                throw new Exception("не удалось преобразовать текст счетчика ачивки в число");
            }
        }

        //закрыть окно профиля и вернуться в дефолтный фрейм
        public void CloseProfile()
        {
            //вернуться в дефолтный фрейм
            BaseItem.DefaultDriver.SwitchTo().DefaultContent();

            var closeButton = new WebItem("//div[@class='side-panel-label-icon-box' and @title='Закрыть']", "кнопка закрытия окна профиля");
            closeButton.Click();
        }

        //вспомогательный метод: ожидание появления текста
        private string WaitForInnerText(WebItem element, int timeoutSeconds = 5)
        {
            string text = "";
            DateTime start = DateTime.Now;

            while ((DateTime.Now - start).TotalSeconds < timeoutSeconds)
            {
                text = element.InnerText().Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    break;
                }
                Thread.Sleep(500);
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new Exception($"не удалось получить текст из элемента '{element.Description}' за {timeoutSeconds} секунд");
            }

            return text;
        }
    }
}
