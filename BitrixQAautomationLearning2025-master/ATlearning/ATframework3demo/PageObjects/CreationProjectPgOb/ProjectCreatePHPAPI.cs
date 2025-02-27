using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.CreationProjectPgOb
{
    internal class ProjectCreatePHPAPI
    {
        public static int ProjectCreate()
        {
            var phpExecutor = new PHPcommandLineExecutor(
                TestCase.RunningTestCase.TestPortal.PortalUri,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.LoginAkaEmail,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.Password);

            string projectCreationPhpCode = $"require($_SERVER[\"DOCUMENT_ROOT\"].\"/bitrix/modules/main/include/prolog_before.php\");" +
                $"\r\n\r\nglobal $USER;\r\n$userID = $USER->GetID();" +
                $"\r\n\r\nif (CModule::IncludeModule(\"socialnetwork\")) " +
                $"{{\r\n    $arFields = [\r\n" +
                $"\"NAME\" => \"Личный проект \" . date(\"Y-m-d H:i:s\"),\r\n" +
                $"\"DESCRIPTION\" => \"Описание личного проекта\",\r\n" +
                $"\"VISIBLE\" => \"Y\",\r\n" +
                $"\"OPENED\" => \"Y\",\r\n" +
                $" \"PROJECT\" => \"Y\",\r\n" +
                $" \"OWNER_ID\" => $userID,\r\n" +
                $" \"SUBJECT_ID\" => 1,\r\n" +
                $"\"INITIATE_PERMS\" => \"A\",\r\n" +
                $"\"CLOSED\" => \"N\",\r\n" +
                $"\"SPAM_PERMS\" => \"N\",\r\n" +
                $" \"SITE_ID\" => \"s1\", \r\n    ];\r\n\r\n   " +
                $" $groupID = CSocNetGroup::CreateGroup($userID, $arFields);" +
                $"\r\necho \"PROJECT_ID:\" . $groupID;\r\n\r\n\r\n}} \r\n\r\n";

            string result = phpExecutor.Execute(projectCreationPhpCode);
            int projectId = int.Parse(result.Split(new[] { "PROJECT_ID:" }, StringSplitOptions.None)[1].Trim());
            return projectId;
        }
    }
}
