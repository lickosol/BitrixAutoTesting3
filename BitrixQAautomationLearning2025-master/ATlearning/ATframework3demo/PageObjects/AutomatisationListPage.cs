using OpenQA.Selenium;
using ATframework3demo.PageObjects.DeadlinesTasks;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.CreationProjectPgOb;
using ATframework3demo.PageObjects.BusinessProcess;
using System.Diagnostics;

namespace atFrameWork2.PageObjects
{
    //страница раздела автоматизация
    public class AutomatisationListPage
    {
        public AutomatisationListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //запуск процесса "Исходящие документы"
        public ProcessesPage BPOutDocList()
        {
            var btnBPlistopen = new WebItem("//span[@class='main-buttons-item-text-box'][contains(text(), 'Бизнес-процессы')]", "открываем список процессов в верхнем меню"); 
            btnBPlistopen.Click();

            var popupBPinLenta = new WebItem("//a[@href='/bizproc/processes/']", "выбираем Процессы в ленте новостей");
            popupBPinLenta.Click();
            return new ProcessesPage();
        }

        //открытие первого в очереди (нашего нового) процесса
        public BusinessProcessPage OpenBP()
        {
            var btnBPopen = new WebItem("//a[@class='bp-user-processes__title-link ui-typography-text-lg']", "открываем первый в списке бизнесс процесс, который мы создали"); 
            btnBPopen.Click();
            return new BusinessProcessPage();
        }

    }

}