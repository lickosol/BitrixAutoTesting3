using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.BusinessProcess
{
    //раздел бизнес-процессов
    public class BusinessProcessPage
    {
        public void FixationDocPage()
        {
            //переключаемся в фрейм перед вводом номера документа
            SwitchToBPFrame();

            //ввод номера документа
            WebItem inputDocNum = new WebItem("//input[@class='bizproc-type-control bizproc-type-control-string bizproc-type-control-required']", "ввод номера документа во фрейме БП");
            WebItem saveBPbtn = new WebItem("//button[@class='ui-btn ui-btn-md ui-btn-success ui-btn-round']", "сохранить фиксацию БП");

            inputDocNum.Click();
            inputDocNum.SendKeys("1");
            saveBPbtn.Click();
        }

        //переключение во фрейм запущенного процесса
        private void SwitchToBPFrame()
        {
            WebItem bpFrame = new WebItem("//iframe[contains(@id, 'iframe')]", "переключаемся на фрейм бизнес процесса");
            bpFrame.WaitElementDisplayed();
            bpFrame.SwitchToFrame();
        }
    }
}

