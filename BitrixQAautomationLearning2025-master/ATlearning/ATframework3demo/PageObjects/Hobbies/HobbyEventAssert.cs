using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atFrameWork2.SeleniumFramework;


namespace ATframework3demo.Assertions.Hobbies
{
    public class HobbyEventAssert
    {
        public static bool VerifyAchiveNewsCreated()
        {
            WebItem lastFeedText = new WebItem("//div[contains(@class, 'feed-post-text-block')]", "проверка текста искомой новости");
            string postText = lastFeedText.GetAttribute("innerText").Trim();

            Console.WriteLine($"текст искомой новости: '{postText}'");

            if (postText.Contains("+REP: Участник события - тестовое событие"))
            {
                Console.WriteLine("новость о тестовом событии найдена");
                return true;
            }
            else
            {
                Console.WriteLine("ошибка получения данных новости о тестовом событии");
                return false;
            }
        }
    }
}


