using AquaTestFramework.CommonFramework.BitrixCPinteraction;
using atFrameWork2.BaseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.BusinessProcess
{
    //php скрипт создания процесса Исходящие документы
    public class BusinessProcessPHP
    {
        public static int BusinessProcessCreate()
        {
            var phpExecutor = new PHPcommandLineExecutor(
                TestCase.RunningTestCase.TestPortal.PortalUri,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.LoginAkaEmail,
                TestCase.RunningTestCase.TestPortal.PortalAdmin.Password);

            string bpCreationPhpCode = $"require($_SERVER[\"DOCUMENT_ROOT\"] . " +
                $"\"/bitrix/modules/main/include/prolog_before.php\");" +
                $"\r\nuse Bitrix\\Main\\Loader;\r\nuse Bitrix\\Iblock\\ElementTable;" +
                $"\r\nLoader::includeModule(\"iblock\");" +
                $"\r\nLoader::includeModule(\"bizproc\");" +
                $"\r\nLoader::includeModule(\"lists\");" +
                $"\r\n$iblockId = 12;" +
                $"\r\n$documentName = \"Исходящий документ \" . date(\"Y-m-d H:i:s\");" +
                $"\r\n$documentFields = [\r\n    \"IBLOCK_ID\" => $iblockId,\r\n " +
                $"   \"NAME\" => $documentName,\r\n    \"ACTIVE\" => \"Y\",\r\n  " +
                $"  \"DATE_ACTIVE_FROM\" => date(\"d.m.Y\"),\r\n];\r\n$element = new CIBlockElement;" +
                $"\r\n$documentId = $element->Add($documentFields);" +
                $"\r\necho \"BP_ID:\" . $documentId;"; 

            string result = phpExecutor.Execute(bpCreationPhpCode);
            int processId = int.Parse(result.Split(new[] { "BP_ID:" }, StringSplitOptions.None)[1].Trim());
            return processId;
        }

    }
}
