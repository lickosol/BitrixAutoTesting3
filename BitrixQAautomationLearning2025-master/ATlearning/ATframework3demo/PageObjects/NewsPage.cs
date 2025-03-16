using atFrameWork2.SeleniumFramework;
using ATframework3demo.Assertions;
using ATframework3demo.SeleniumFramework.DriverActions;
using OpenQA.Selenium;

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
            //Клик в Написать сообщение
            var btnPostCreate = new WebItem("//div[@id='microoPostFormLHE_blogPostForm_inner']", "Область в новостях 'Написать сообщение'");
            btnPostCreate.Click(Driver);
            return new NewsPostForm(Driver);
        }

        //удаление новости после проверки завершения бизнес процесса "Исходящие документы"
        public NewsPage DeleteNews() 
        {
            if (!BusinessProcessAssert.VerifyProcessCompleted())
            {
                Console.WriteLine("новость не будет удалена, так как бизнес-процесс не завершен успешно");
                return this;
            }

            Console.WriteLine("очистка новостей от тестовой проверки");
            var btnContextMenuNews = new WebItem("//div[@class='feed-post-right-top-menu']", "контекстное меню в новости через три точки");
            btnContextMenuNews.Click();
            var btnDeleteNews = new WebItem("//span[@ class='menu-popup-item-text'][contains(text(), 'Удалить из ленты новостей')]", "удалить новость");
            btnDeleteNews.Click();
            WebDriverActions.BrowserAlert(true);
            return new NewsPage();
        }
    }
}
