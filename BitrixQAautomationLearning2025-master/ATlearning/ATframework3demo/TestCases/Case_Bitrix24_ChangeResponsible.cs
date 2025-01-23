using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.TestCases
{
    internal class Case_Bitrix24_ChangeResponsible : CaseCollectionBuilder
    {
        //чтобы в ассерте красным не горели, уберу, когда ассерт будет реализован
        private object oldResponsible;
        private object expectedResponsible;

        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Изменение ответственного за задачу", homePage => ChangeResponsible(homePage)));
            return caseCollection;
        }

        void ChangeResponsible(PortalHomePage homePage)
        {
            //перейти в задачи
            var ChangeResp = homePage
                .LeftMenu
                .OpenTasks()
            //выбрать пункт сроки
                .OpenDeadlinesTasks()
            //создать задачу
                .CreateNewTask()
            //заполнить название задачи 
                .SetTaskName()
            //сохранить
                .SaveTask()
            //меняем исполнителя выбором из списка из быстрого доступа
                .ChangeResponsible();
            //рефрешнуть страницу
            WebDriverActions.Refresh();
            //проверить сохранились ли изменения
            ChangeResp.AssertChanges(oldResponsible, expectedResponsible);    
        }

    }


}
