using atFrameWork2.SeleniumFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.Assertions
{
    public class BusinessProcessAssert
    {
        public static void VerifyProcessCompleted()
        {

            WebItem lastFeedTime = new WebItem("//div[@class='feed-time']", "время последней новости");
            string feedTimeText = lastFeedTime.GetAttribute("innerText").Trim();

            Console.WriteLine($"время последней новости: '{feedTimeText}' (длина: {feedTimeText.Length})");

            if (feedTimeText.StartsWith("Сегодня"))
            {
                DateTime now = DateTime.Now;
                string newsTimeStr = feedTimeText.Replace("Сегодня, ", "").Trim();

                Console.WriteLine($"Извлеченное время новости (как строка): '{newsTimeStr}' (длина: {newsTimeStr.Length})");
                Console.WriteLine($"текущее время: {now:HH:mm}");

                try
                {
                    // Преобразуем строку во время
                    DateTime newsTime = DateTime.ParseExact(newsTimeStr, "HH:mm", null);
                    Console.WriteLine($"преобразованное время новости: {newsTime:HH:mm}");

                    // Проверяем разницу во времени (не более 1 минуты)
                    double difference = Math.Abs((now - newsTime).TotalMinutes);
                    Console.WriteLine($"разница во времени: {difference} минут");

                    if (difference <= 2)
                    {
                        Console.WriteLine("бизнес-процесс успешно завершился");
                    }
                    else
                    {
                        Console.WriteLine("ошибка в завершении процесса");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ошибка при разборе времени: {ex.Message}");
                }
            }
        }
    }
}