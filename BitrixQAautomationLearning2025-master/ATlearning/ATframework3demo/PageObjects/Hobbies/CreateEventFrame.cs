using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Hobbies
{
    public class CreateEventFrame
    {
        //переход на фрейм создания события
        protected CreateEventPage SwitchToCreationEventFrame()
        {
            var createEventFrame = new WebItem("//iframe[contains(@id, 'iframe')]", "переключаемся на фрейм создания события");
            createEventFrame.WaitElementDisplayed();
            createEventFrame.SwitchToFrame();

            return new CreateEventPage();
        }
    }
}
