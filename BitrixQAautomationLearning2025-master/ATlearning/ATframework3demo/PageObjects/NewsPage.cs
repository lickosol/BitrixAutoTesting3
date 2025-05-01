using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.Assertions;
using ATframework3demo.Assertions.Hobbies;
using ATframework3demo.SeleniumFramework.DriverActions;
using OpenQA.Selenium;
using System;

namespace ATframework3demo.PageObjects
{
    public class NewsPage
    {
        public NewsPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public NewsPostForm AddPost()
        {
            var btnPostCreate = new WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "область в новостях 'Написать сообщение'");
            btnPostCreate.Click(Driver);
            return new NewsPostForm(Driver);
        }

        //удаление новости после завершения бизнес-процесса
        public NewsPage DeleteNews()
        {
            if (!BusinessProcessAssert.VerifyProcessCompleted())
            {
                Console.WriteLine("новость не будет удалена, так как бизнес-процесс не завершен успешно");
                return this;
            }

            Console.WriteLine("очистка новостей от тестовой проверки бизнес-процесса");

            DeleteLastNews();
            return new NewsPage();
        }

        //удаление новости об ачивке + проверка удаления
        public NewsPage DeleteAchiveNews()
        {
            if (!HobbyEventAssert.VerifyAchiveNewsCreated())
            {
                Console.WriteLine("новость об ачивке не найдена, удаление не требуется");
                return this;
            }

            Console.WriteLine("очистка новостей от тестовой ачивки");

            DeleteLastNews();

            //проверка, что новость об ачивке исчезла
            var lastFeedText = new WebItem("//div[contains(@class, 'feed-post-text-block')]", "текст последней новости");
            string postText = lastFeedText.GetAttribute("innerText").Trim();

            var lastFeedTime = new WebItem("//div[@class='feed-time']", "Время последней новости");
            string feedTimeText = lastFeedTime.GetAttribute("innerText").Trim();

            Console.WriteLine($"текст последней новости после удаления: {postText}");
            Console.WriteLine($"время последней новости после удаления: {feedTimeText}");

            DateTime now = DateTime.Now;

            if (postText.Contains("+REP: Участник события - проверка ачивки") && feedTimeText.StartsWith("Сегодня"))
            {
                try
                {
                    string newsTimeStr = feedTimeText.Replace("Сегодня, ", "").Trim();
                    DateTime newsTime = DateTime.ParseExact(newsTimeStr, "HH:mm", null);
                    double difference = Math.Abs((now - newsTime).TotalMinutes);

                    if (difference <= 2)
                    {
                        throw new Exception("ошибка: новость об ачивке осталась после удаления");
                    }
                    else
                    {
                        Console.WriteLine("предыдущая новость");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ошибка при проверке времени удаления: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("новость об ачивке успешно удалена");
            }

            return new NewsPage();
        }

        private void DeleteLastNews()
        {
            var btnContextMenuNews = new WebItem("//div[@class='feed-post-right-top-menu']", "контекстное меню новости через три точки");
            btnContextMenuNews.Click();

            var btnDeleteNews = new WebItem("//span[contains(@class, 'menu-popup-item')]/span[contains(@class, 'menu-popup-item-text') and text()='Удалить']", "удалить новость");
            btnDeleteNews.Click();

            WebDriverActions.BrowserAlert(true);

            Waiters.StaticWait_s(6);
        }
    }
}
