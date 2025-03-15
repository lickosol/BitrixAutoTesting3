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

        public MobileCRMdealPage MobileOpenDeals()
        {
            var btnAddinCRM = new MobileItem("//android.widget.ImageButton[@resource-id='com.bitrix24.android:id/component_fab']", "кнопка + в CRM");
            btnAddinCRM.Click();

            var btnDeal = new MobileItem("//android.widget.TextView[@content-desc='CRM_ENTITY_TAB_DEAL_CONTEXT_MENU_2_title']", "выбираем добавить сделку");
            btnDeal.Click();

            return new MobileCRMdealPage(); 
        }
    }
}
