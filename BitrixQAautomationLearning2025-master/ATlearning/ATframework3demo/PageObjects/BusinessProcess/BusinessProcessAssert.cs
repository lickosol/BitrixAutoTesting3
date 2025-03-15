using atFrameWork2.SeleniumFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.Assertions
{
    //вывод в консоль проверки корректного завершения бизнес процесса
    public class BusinessProcessAssert
    {
        public static bool VerifyProcessCompleted()
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
                    //преобразование строки во время
                    DateTime newsTime = DateTime.ParseExact(newsTimeStr, "HH:mm", null);
                    Console.WriteLine($"преобразованное время новости: {newsTime:HH:mm}");

                    //проверка разницы во времени (не более 2 минут)
                    double difference = Math.Abs((now - newsTime).TotalMinutes);
                    Console.WriteLine($"разница во времени: {difference} минут");

                    if (difference <= 2)
                    {
                        Console.WriteLine("бизнес-процесс успешно завершился");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("ошибка в завершении процесса");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ошибка при разборе времени: {ex.Message}");
                    return false;
                }
            }

            return false;
        }

    }
}