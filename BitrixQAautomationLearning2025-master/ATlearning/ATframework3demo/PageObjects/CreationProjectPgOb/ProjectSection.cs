using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.CreationProjectPgOb
{
    public class ProjectSection : BaseProjectFramePage
    {
        private readonly int _projectId;

        public ProjectSection(int projectId)
        {
            _projectId = projectId;
        }

        public void OpenProject()
        {
            WebItem btnOpenProject = new WebItem($"//a[contains(@href,'/workgroups/group/{_projectId}/tasks/')]", "Открытие проекта");
            btnOpenProject.Click();

            SwitchToProjectFrame();
        }
    }
}
