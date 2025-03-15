using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Mobile_CRM_Deal
{
    public class MobileMorePanel
    {
        public MobileCrmPage MobileOpenCRM()
        {
            var btnCRM = new MobileItem("//android.widget.TextView[@resource-id='com.bitrix24.android:id/title' and @text='CRM']", "раздел CRM в разделе Еще");
            btnCRM.Click();
            return new MobileCrmPage(); 
        }
    }
}
