using OpenQA.Selenium;
using ATframework3demo.PageObjects.DeadlinesTasks;
using atFrameWork2.SeleniumFramework;

namespace atFrameWork2.PageObjects
{
    public class TasksListPage
    {
        public TasksListPage(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public DeadlineTasksPage OpenDeadlinesTasks()
        {
            var btnDeadlines = new WebItem("//a[@id='tasks_view_mode_timeline']", "Сроки");
            btnDeadlines.Click();
            return new DeadlineTasksPage();
        }
    }
}