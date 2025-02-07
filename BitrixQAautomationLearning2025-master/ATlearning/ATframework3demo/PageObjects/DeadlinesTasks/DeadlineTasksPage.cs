using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.DeadlinesTasks
{
    public class DeadlineTasksPage
    {

        WebItem ChangeRespBtn => new WebItem("//div[@class='tasks-kanban-item-responsible']/div[@class='tasks-kanban-item-author-avatar']", "Открытие списка ответственных");
        WebItem ResponsibleList => new WebItem("//div[@class='ui-selector-item-box']", "Список отвественных");
        public DeadlineTasksListChangeResponsible ChangeResponsible()
        {
            ChangeRespBtn.Click();
            ResponsibleList.Click();
            return new DeadlineTasksListChangeResponsible();
        }


    }
}
