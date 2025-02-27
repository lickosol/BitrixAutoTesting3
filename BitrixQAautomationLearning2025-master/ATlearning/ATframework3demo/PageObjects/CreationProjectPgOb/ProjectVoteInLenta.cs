using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.CreationProjectPgOb
{
    public class ProjectVoteInLenta : BaseProjectFramePage
    {
        public void CreateAndSendVote()
        {

            WebItem btnToVoteInProject = new WebItem("//span[@id='feed-add-post-form-tab-vote']", "нажатие на кнопку добавления опроса");
            btnToVoteInProject.WaitElementDisplayed();
            btnToVoteInProject.Click();

            WebItem btnAddVoteInProject = new WebItem("//input[@class='vote-block-title']", "добавление названия опроса");
            btnAddVoteInProject.Click();
            btnAddVoteInProject.SendKeys("ответьте да");

            WebItem btnAddAnswerInVote = new WebItem("//input[@class='vote-block-inp' and @placeholder='Ответ  1']", "добавление первого ответа Да");
            btnAddAnswerInVote.Click();
            btnAddAnswerInVote.SendKeys("да");

            WebItem btnSendVoteInProject = new WebItem("//span[@id='blog-submit-button-save']", "кнопка Отправить");
            btnSendVoteInProject.Click();
        }
    }
}
