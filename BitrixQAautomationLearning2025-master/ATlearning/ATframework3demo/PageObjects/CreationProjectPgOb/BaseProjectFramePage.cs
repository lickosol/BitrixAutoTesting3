using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.CreationProjectPgOb
{
    public class BaseProjectFramePage
    {
        protected void SwitchToProjectFrame()
        {
            WebItem projectFrame = new WebItem("//iframe[@class='side-panel-iframe']", "переключаемся на фрейм проекта");
            projectFrame.WaitElementDisplayed();
            projectFrame.SwitchToFrame();
        }
    }
}
