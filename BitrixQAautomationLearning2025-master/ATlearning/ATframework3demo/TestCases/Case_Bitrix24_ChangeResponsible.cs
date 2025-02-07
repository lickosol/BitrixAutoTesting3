using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.DeadlinesTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.TestCases
{
    internal class Case_Bitrix24_ChangeResponsible : CaseCollectionBuilder
    {


        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Изменение ответственного за задачу", homePage => ChangeResponsible(homePage)));
            return caseCollection;
        }


       
        void ChangeResponsible(PortalHomePage homePage)
        {
            //создать нового сотрудника
            var newResponsible = TestCase.RunningTestCase.CreatePortalTestUser(false);
            //создать задачу через пхп код (сюда вставить вызов модуля)
            TaskCreator.CreateTask();
            //перейти в задачи
            var ChangeResp = homePage
                .LeftMenu
                .OpenTasks()
            //выбрать пункт сроки
                .OpenDeadlinesTasks()
            //меняем исполнителя выбором из списка из быстрого доступа
                .ChangeResponsible();
            //рефрешнуть страницу
            WebDriverActions.Refresh();
            //проверить сохранились ли изменения
            var assertExecutor = new ChangeRespAssert();
            assertExecutor.VerifyResponsibleChange();
        }

    }


}
