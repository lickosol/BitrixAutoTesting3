using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Mobile_CRM_Deal
{
    public class MobileCrmPage
    {
        //переход в редактор создания сделки
        public MobileCRMdealPage MobileOpenCreationDeals()
        {
            var btnAddinCRM = new MobileItem("//android.widget.ImageButton[@resource-id='com.bitrix24.android:id/component_fab']", "кнопка + в CRM");
            btnAddinCRM.Click();

            var btnDeal = new MobileItem("//android.widget.TextView[@content-desc='CRM_ENTITY_TAB_DEAL_CONTEXT_MENU_2_title']", "выбираем добавить сделку");
            btnDeal.Click();

            return new MobileCRMdealPage(); 
        }

        //проверка создания сделки
        public MobileCrmPage MobileAssertDeal()
        {
            var createdDeal = new MobileItem("//android.widget.TextView[@text='тест сделка']", "проверка наличия созданной сделки");

            if (createdDeal.WaitElementDisplayed(5))
            {
                Console.WriteLine("сделка 'тест сделка' успешно создана и отображается в списке CRM");
            }
            else
            {
                Console.WriteLine("ошибка: сделка не создана");
                throw new Exception("сделка не найдена");
            }

            return new MobileCrmPage();
        }


        //удаление сделки
        public MobileCrmPage MobileDealDelete()
        {
            var contextMenuInDeal = new MobileItem("//android.widget.ImageButton[@content-desc='KANBAN_STAGE_CONTEXT_MENU_BTN']", "три точки контекстное меню в сделке");
            contextMenuInDeal.Click();

            var btnDeleteDeal = new MobileItem("(//android.widget.TextView[@content-desc='KANBAN_STAGE_CONTEXT_MENU_delete_title'])",
                "выбираем удалить");
            btnDeleteDeal.Click();

            var acceptDeleteDeal = new MobileItem("//android.widget.Button[@resource-id='android:id/button2']", "подтверждаем удаление");
            btnDeleteDeal.Click();

            return new MobileCrmPage();
        }
    }
}
