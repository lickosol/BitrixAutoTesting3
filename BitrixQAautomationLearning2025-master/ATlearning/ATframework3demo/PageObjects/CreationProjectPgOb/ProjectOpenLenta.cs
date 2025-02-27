using atFrameWork2.SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATframework3demo.PageObjects.CreationProjectPgOb
{
    public class ProjectOpenLenta : BaseProjectFramePage
    {
        public void OpenLenta()
        {
 
            WebItem btnLentaInProject = new WebItem("//span[contains(@class, 'main-buttons-item-text-box') and contains(text(), 'Лента')]", 
                "нажимаем на кнопку лента в верхнем меню проекта");
            btnLentaInProject.Click();
        }
    }
}