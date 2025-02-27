using OpenQA.Selenium;
using ATframework3demo.PageObjects.DeadlinesTasks;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.CreationProjectPgOb;

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
        public ProjectSection OpenProjectsSection(int projectId)
        {
            var btnProjects = new WebItem("//div[contains(@id, 'tasks_panel_menu')]//span[contains(@class, 'main-buttons-item-text-box') and contains(text(), 'Проекты')]",
                "Открытие раздела Проекты из верхнего меню");
            btnProjects.Click();
            return new ProjectSection(projectId);
        }
    }


}
