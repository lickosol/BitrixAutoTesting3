using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.BusinessProcess
{
    public class OutDocPage
    {
        // пейдж внутрянки процесса
        public OutDocPage StartedProcess()
        {
            // обязательное поле Дата
            var btnDate = new WebItem($"//input[@class='ui-ctl-element' and @name='PROPERTY_53[n0][VALUE]']", "Ввод даты");
            btnDate.Click();
            btnDate.SendKeys("08.04.2025");

            var bpChapter = new WebItem($"//td[@id='tab_tab_bp'][contains(text(), 'Бизнес-процессы')]", "Открываем вкладку Бизнес-процессы");
            bpChapter.Click();

            // запуск процесса на вкладке бизнес процессы
            var btnStartedBP = new WebItem($"//span[@class='ui-btn ui-btn-dropdown ui-btn-primary']", "Нажимаем Запустить процесс");
            btnStartedBP.Click();

            var popupBtnOutDoc = new WebItem($"//span[@class='menu-popup-item-text'][contains(text(), 'Исходящие документы')]", "В контекстном меню выбираем Исходящие документы");
            popupBtnOutDoc.Click();

            var btnApproveBP = new WebItem($"//input[@title='Сохранить и остаться в форме']", "Применяем изменения");
            btnApproveBP.Click();

            return new OutDocPage();
        }
    }
}
