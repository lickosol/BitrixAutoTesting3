using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATframework3demo.PageObjects.CreationProjectPgOb
{
    public class NewPostInProjectAssert
    {
        private readonly string _postTitle;

        public NewPostInProjectAssert(string postTitle = "ответьте да")
        {
            _postTitle = postTitle;
        }

        public void VerifyMessageCreate()
        {
            WebItem createdPost = new WebItem($"//div[contains(text(), '{_postTitle}')]", "проверяем наличие созданного поста");
            createdPost.WaitElementDisplayed();
            Console.WriteLine($"успешно: пост с заголовком '{_postTitle}' создан и отображается.");
        }
    }
}
