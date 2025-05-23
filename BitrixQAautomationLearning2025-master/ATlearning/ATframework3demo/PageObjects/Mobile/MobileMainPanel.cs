using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Mobile_CRM_Deal;

namespace ATframework3demo.PageObjects.Mobile
{
    /// <summary>
    /// Главная панель приложения
    /// </summary>
    public class MobileMainPanel
    {
        public MobileTasksListPage SelectTasks()
        {
            var tasksTab = new MobileItem("//android.widget.TextView[@resource-id=\"com.bitrix24.android:id/bb_bottom_bar_title\" and @text=\"Tasks\"]",
                "Таб 'Задачи'");
            tasksTab.Click();

            return new MobileTasksListPage();
        }

        //синее уведомление при входе
        public MobileMainPanel ClosePush()
        {
            var clickOnScrin = new MobileItem("//androidx.recyclerview.widget.RecyclerView[@resource-id='com.bitrix24.android:id/list']", "клик убрать уведу");
            clickOnScrin.Click();
            return new MobileMainPanel(); 
        }

        //переход в раздел Еще
        public MobileMorePanel MorePanel()
        {
            var btnMore = new MobileItem("//android.widget.TextView[@text='Ещё']",
                "раздел Еще в нижней панели"); 
            btnMore.Click();

            return new MobileMorePanel();
        }
    }
}