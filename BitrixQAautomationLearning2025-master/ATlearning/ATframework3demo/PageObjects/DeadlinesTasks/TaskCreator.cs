using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;

namespace ATframework3demo.PageObjects.DeadlinesTasks
{
    public class TaskCreator
    {
        public static void CreateTask()
        {
            var phpExecutor = new PHPcommandLineExecutor(
                TestCase.RunningTestCase.TestPortal.PortalUri,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.LoginAkaEmail,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.Password);

            string taskCreationPhpCode =
                $"\r\nCModule::IncludeModule(\"tasks\");\r\n$title = \"тест задача 1\";" +
                $" \r\n$arFields = [\r\n    \"TITLE\" => $title, \r\n    \"RESPONSIBLE_ID\" => 1, " +
                $"\r\n    \"CREATED_BY\" => 1, \r\n    \"DEADLINE\" => ConvertTimeStamp(time() + 3600 * 4, \"FULL\")," +
                $" \r\n];\r\n$obTask = new CTasks;\r\n$taskId = $obTask->Add($arFields);";

            phpExecutor.Execute(taskCreationPhpCode);
        }
    }
}

