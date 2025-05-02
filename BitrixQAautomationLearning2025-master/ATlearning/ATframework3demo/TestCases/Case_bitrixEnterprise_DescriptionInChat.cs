using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.Assertions.Hobbies;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.DeadlinesTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.TestCases
{
    internal class Case_BitrixEnterprise_DescriptionInChat : CaseCollectionBuilder
    {


        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Досуг: проверка описания + его отображение в чате", homePage => DescriptionInChat(homePage)));
            return caseCollection;
        }

        void DescriptionInChat(PortalHomePage homePage)
        {
            var getAchives = homePage.
                 LeftMenu
                .OpenHobbies()
             //начало создания события
                .OpenHobbyPage()
            //переход на фрейм события
                .OpenEventFrame()
            //заполнение полей в окне создания события
                .CreateEvent();

            
            try
            {
                //ожидаемый текст в первом сообщении, который совпадает с текстом в описании
                string expectedDescription = "Всем привет!";

                //открытие мессенджера и чата события
                var chatPage = homePage.LeftMenu
                    .OpenChats()
                    .OpenTestChat();

                //получение текста сообщения
                string chatMessage = chatPage.GetFirstMessageText();
                Console.WriteLine($"полученное сообщение: {chatMessage}");

                //проверка совпадения текста сообщения и текста описания события
                if (chatMessage != expectedDescription)
                    throw new Exception($"ошибка: описание события не совпадает с сообщением в чате. Ожидалось: '{expectedDescription}', получено: '{chatMessage}'");
                else
                    Console.WriteLine("сообщение в чате совпадает с описанием события");

                //выход из мессенджера
                chatPage.CloseMessenger();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка при чтении текста чата: {ex.Message}");

                throw;
            }

            //возвращение в Досуг, чтобы завершить событие
            homePage.LeftMenu
                .OpenHobbies()
                .EndEvent();

            //переход в Ленту через левое меню
            homePage.LeftMenu
                .OpenNews();

            //проверка, появилась ли новость о новом событии
            bool isNewsCreated = HobbyEventAssert.VerifyAchiveNewsCreated();
            if (!isNewsCreated)
                throw new Exception("ошибка: новость не появилась");

            //очистка календаря от тестового события
            homePage.LeftMenu
                .OpenCalendar()
                .DeleteEventFromCalendar();

            WebDriverActions.Refresh();

            //очистка ленты от новости о тестовом событии
            homePage.LeftMenu
                .OpenNews()
                .DeleteAchiveNews();
        }
    }
}
