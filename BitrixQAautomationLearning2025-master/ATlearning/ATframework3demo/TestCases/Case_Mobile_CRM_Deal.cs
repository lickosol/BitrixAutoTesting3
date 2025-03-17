using atFrameWork2.BaseFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.TestCases
{
    public class Case_Mobile_CRM_Deal : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(
                new TestCase("Создание сделки CRM", mobileHomePage => CreateTask(mobileHomePage)));
            return caseCollection;
        }

        void CreateTask(MobileHomePage homePage)
        {
            //создание сделки
            var createCRMdeal = homePage.TabsPanel
                //переход в раздел "Еще"
                .MorePanel()
                //переход в раздел "CRM"
                .MobileOpenCRM()
                //создаем сделку
                .MobileOpenCreationDeals()
                //заполняем поля в сделке
                .MobileCreateDeal();

            //проверка и удаление сделки
            var chekAndClearTest = homePage.TabsPanel
                .MorePanel()
                .MobileOpenCRM()
                //проверка создания сделки
                .MobileAssertDeal()
                //удаление сделки
                .MobileDealDelete();
        }
    }
}