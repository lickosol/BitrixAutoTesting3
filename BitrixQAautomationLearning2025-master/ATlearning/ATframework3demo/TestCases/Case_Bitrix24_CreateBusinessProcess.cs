using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.Assertions;
using ATframework3demo.PageObjects.BusinessProcess;
using ATframework3demo.PageObjects.CreationProjectPgOb;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.TestCases
{
    internal class Case_Bitrix24_CreateBusinessProcess : CaseCollectionBuilder
    {

        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание бизнес процесса и проверка его выполнения", homePage => CreateBusinessProcess(homePage)));
            return caseCollection;
        }

        void CreateBusinessProcess(PortalHomePage homePage)
        {
            // создание процесса с помощью php api 
            int processId = BusinessProcessPHP.BusinessProcessCreate();

            // рефрешнуть страницу
            WebDriverActions.Refresh();



            // перейти в левое меню
            var StartBusinessProcess = homePage
            // перейти в левое меню
                .LeftMenu

            // открыть автоматизацию
                .OpenAutomatisation()

            // в выпадающем меню выбрать процесс Исходящие документы
                .BPOutDocList()

            // выбираем нужный нам вид процесса 
                .ProcessesList()

            // по id выбираем созданный процесс в текущем тесте
                .OutDocList(processId)

            // запускаем процесс
                .StartedProcess();

            // вернуться на автоматизацию
            var FixationAndCheckBP = homePage
                .LeftMenu

            // открыть автоматизацию
                .OpenAutomatisation()

            // нажать на БП
                .OpenBP();

            // ввести номер документа
            var bpPage = new BusinessProcessPage();
            bpPage.FixationDocPage();

            // рефрешнуть страницу
            WebDriverActions.Refresh();

            var GoToLenta = homePage
                .LeftMenu
                .OpenNews();
            // проверить статус
            BusinessProcessAssert.VerifyProcessCompleted();


        }


    }
}
