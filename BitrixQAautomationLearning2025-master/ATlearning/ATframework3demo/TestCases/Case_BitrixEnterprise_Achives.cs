using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.Assertions.Hobbies;
using ATframework3demo.PageObjects;
using ATframework3demo.PageObjects.DeadlinesTasks;
using ATframework3demo.PageObjects.Hobbies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.TestCases
{
    internal class Case_BitrixEnterprise_Achives : CaseCollectionBuilder
    {


        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Досуг: добавление ачивок в профиль", homePage => GetAchives(homePage)));
            return caseCollection;
        }



        void GetAchives(PortalHomePage homePage)
        {


            //открыть профиль и получить текущее количество ачивок "Успех"
            var profilePage = new ProfilePage();
            profilePage.OpenProfile();
            int initialThumbsUpCount = profilePage.GetThumbsUpAchiveCount();
            profilePage.CloseProfile();

            //переход в модуль досуг через левое меню
            var getAchives = homePage.
                LeftMenu
                .OpenHobbies()
            //начало создания события
                .OpenHobbyPage()
            //переход на фрейм события
                .OpenEventFrame()
            //заполнение полей в окне создания события
                .CreateEvent();

            var endEvent = new HobbyPage();
            endEvent.EndEvent();

            //переход в Ленту через левое меню
            homePage.LeftMenu
                .OpenNews();

            //проверка, появилась ли новость о новом событии
            bool isNewsCreated = HobbyEventAssert.VerifyAchiveNewsCreated();
            if (!isNewsCreated)
                throw new Exception("ошибка: новость не появилась");

            //открытие профиля, обновление количества ачивок
            profilePage.OpenProfile();
            int updatedThumbsUpCount = profilePage.GetThumbsUpAchiveCount();
            profilePage.CloseProfile();

            //проверка: количество ачивок должно увеличиться на 1
            if (updatedThumbsUpCount == initialThumbsUpCount + 1)
            {
                Console.WriteLine($"ачивка 'Успех' добавилась корректно. Было: {initialThumbsUpCount}, стало: {updatedThumbsUpCount}");
            }
            else
            {
                throw new Exception($"ошибка: Количество ачивок 'Успех' некорректное. Было: {initialThumbsUpCount}, стало: {updatedThumbsUpCount}");
            }

            //очистка ленты от новости о тестовом событии
            var newsPage = new NewsPage();
            newsPage.DeleteAchiveNews();

        }

    }


}
