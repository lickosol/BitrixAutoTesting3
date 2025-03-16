using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.BusinessProcess
{
    public class ProcessesPage
    {
        public ProcessesPage ProcessesList()
        {
            var outgoingDocProcess = new WebItem("//a[@href='/bizproc/processes/12/view/0/?list_section_id='][contains(text(), 'Исходящие документы')]",
                "выбираем процесс Исходящие документы");
            outgoingDocProcess.Click();
            return new ProcessesPage();
        }

        public OutDocPage OutDocList(int processId)
        {
            // выбор только что созданного процесса в пейдже со списком процессов Исходящих документов
            var createdProcess = new WebItem($"//tr[@data-id='{processId}']//a[contains(@href, '/bizproc/processes/12/element/0/')]", "выбираем созданный бизнес-процесс");
            createdProcess.Click();
            return new OutDocPage();
        }
    }
}
