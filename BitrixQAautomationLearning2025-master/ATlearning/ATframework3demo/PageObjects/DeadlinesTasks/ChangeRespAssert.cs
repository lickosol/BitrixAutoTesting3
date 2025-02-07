using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.DeadlinesTasks
{
    internal class ChangeRespAssert
    {
        WebItem responsibleElement => new WebItem("//div[@class='ui-selector-item-box ui-selector-item-box-selected']", "Для ассерта");
        public void VerifyResponsibleChange()
        {
            string actualResponsible = GetResponsibleFromUI();

            if (!string.IsNullOrEmpty(actualResponsible))
            {
                Console.WriteLine($"Изменения сохранены: новый исполнитель - {actualResponsible}");
            }
            else
            {
                Console.WriteLine("Ошибка, изменения не сохранены");
            }
        }

        private string GetResponsibleFromUI()
        {
            try
            {

                return responsibleElement.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
