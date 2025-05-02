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
    internal class Case_BitrixEnterprise_CreateEventFromLeftMenu : CaseCollectionBuilder
    {


        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Досуг: создание события через левое меню", homePage => CustomerAddInChat(homePage)));
            return caseCollection;
        }



        void CustomerAddInChat(PortalHomePage homePage)
        {
            var getAchives = homePage.
                LeftMenu
                .OpenHobbies()
            //начало создания события
                .OpenHobbyPage()
            //переход на фрейм события
                .OpenEventFrame()
            //добавление окна создания события в левое меню, если не добавлено
                .AddCreationFrameInLeftMenu();

            //создание события через пункт в левом меню Создать событие
            homePage.LeftMenu
                .OpenCreationEventFrame()
                .CreateEventFromLeftMenu();

            //завершение события
            var endEvent = new HobbyPage();
            endEvent.EndEvent();

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
