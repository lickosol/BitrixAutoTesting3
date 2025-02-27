using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.CreationProjectPgOb;
using ATframework3demo.PageObjects.DeadlinesTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.TestCases
{
    internal class Case_Bitrix24_CreateProject : CaseCollectionBuilder
    {

        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание проекта + пост в ленту проекта", homePage => CreateProject(homePage)));
            return caseCollection;
        }
        void CreateProject(PortalHomePage homePage)
        {

            // создать проект через PHP API и получить его ID
            int projectId = ProjectCreatePHPAPI.ProjectCreate();

            // рефрешнуть страницу
            WebDriverActions.Refresh();

            // перейти в левое меню
            var OpenTaskAndProjects = homePage
                .LeftMenu

            // нажать задачи и проекты
                .OpenTasks()

            // в этом разделе нажать Проекты в верхнем меню
                .OpenProjectsSection(projectId);

            // перейти на фрейм только что созданного проекта
            var projectSection = new ProjectSection(projectId);
            projectSection.OpenProject();

            // открыть раздел Лента в проекте
            var projectOpenLenta = new ProjectOpenLenta();
            projectOpenLenta.OpenLenta();

            // создать опрос для поста 
            var projectVoteInLenta = new ProjectVoteInLenta();
            projectVoteInLenta.CreateAndSendVote();

            // рефрешнуть
            WebDriverActions.Refresh();

            // сделать ассерт создания поста
            var assertExecutor = new NewPostInProjectAssert("ответьте да"); 
            assertExecutor.VerifyMessageCreate();
        }
    }
}
