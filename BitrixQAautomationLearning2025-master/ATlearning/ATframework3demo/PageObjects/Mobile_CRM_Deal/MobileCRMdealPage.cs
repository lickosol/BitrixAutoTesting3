using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATframework3demo.PageObjects.Mobile_CRM_Deal
{
    public class MobileCRMdealPage
    {
        public MobileCRMdealPage MobileCreateDeal() 
        {
            //название сделки
            var btnInputDealName = new MobileItem("//android.view.ViewGroup[@content-desc='deal_0_details_editor_TITLE_CONTENT']", "кнопка перехода для ввода названия сделки");
            btnInputDealName.Click();

            var inputDealName = new MobileItem("//android.widget.EditText[@text='Сделка #']", "ввод названия сделки");
            inputDealName.Click();
            inputDealName.SendKeys("тест сделка");

            var btnSaveDealName = new MobileItem("//android.widget.TextView[@text='Сохранить']", "кнопка сохранить название сделки");
            btnSaveDealName.Click();

            //сумма сделки
            var editDealSum = new MobileItem("//android.widget.EditText[@text='0']", "ввод суммы сделки");
            editDealSum.Click();
            editDealSum.SendKeys("10000");

            //добавление контакта
            var btnAddContact = new MobileItem("//android.widget.TextView[@text='Добавить контакт']", "кнопка добавления контакта");
            btnAddContact.Click();

            var chooseContact = new MobileItem("(//android.widget.ImageView[@content-desc='check_off'])[1]", "выбираем первый контакт");
            chooseContact.Click();

            var btnSaveContact = new MobileItem("//android.widget.TextView[@text='Выбрать']", "нажимаем кнопку Выбрать после выбора контакта");
            btnSaveContact.Click();

            //добавление информации об источнике
            var btnAboutSource = new MobileItem("//android.view.ViewGroup[@content-desc='deal_0_details_editor_SOURCE_DESCRIPTION_TITLE']",
                "нажимаем на Об источнике для добавления информации об источнике");
            btnAboutSource.Click();

            var fillAboutSource = new MobileItem("//android.widget.EditText[@text='Заполнить']", "заполняем поле об источнике текстом");
            fillAboutSource.Click();
            fillAboutSource.SendKeys("нет источника");

            var btnSaveAboutSource = new MobileItem("//android.widget.TextView[@text='Сохранить']", "сохраняем текст об источнике");
            btnSaveAboutSource.Click();

            //прокрутка вниз и добавление наблюдателя
            var scrollToWatchers = BaseItem.DefaultDriver.FindElement(MobileBy.AndroidUIAutomator(
                "new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Наблюдатели\"))"));
            scrollToWatchers.Click();

            //добавление наблюдателя
            //var addObserver = new MobileItem("//android.widget.TextView[@content-desc='deal_0_details_editor_OBSERVER_NAME']",
            //    "добавляем наблюдателя");
            //addObserver.Click();

            var chooseObserver = new MobileItem("//android.widget.ImageView[@content-desc='check_off']", "выбираем первого наблюдателя");
            chooseObserver.Click();

            var btnSaveObserver = new MobileItem("//android.widget.TextView[@text='Выбрать']", "сохраняем наблюдателя");
            btnSaveObserver.Click();

            //добавление комментария
            var addComment = new MobileItem("//android.widget.TextView[@content-desc='deal_0_details_editor_COMMENTS_NAME']", "кнопка добавить комментарий");
            addComment.Click();

            var enterComment = new MobileItem("//android.widget.EditText[@text='Заполнить']", "поле заполнения комментария");
            enterComment.Click();
            enterComment.SendKeys("новый комментарий");

            var btnSaveComment = new MobileItem("//android.widget.TextView[@text='Сохранить']", "сохранить комментарий");
            btnSaveComment.Click();

            //создаем сделку
            var btnSaveDeal = new MobileItem("//android.widget.TextView[@text='Создать']", "кнопка создать сделку");
            btnSaveDeal.Click();

            //выходим из сделки
            var btnExitFromDeal = new MobileItem("//android.widget.ImageView[@resource-id='com.bitrix24.android:id/global_icon']", "кнопка свернуть сделку");
            btnExitFromDeal.Click();

            var btnSavePush = new MobileItem("//android.widget.TextView[@text='Сохранить']", "закрыть уведомление 'забронировать следующий шаг'");
            btnSavePush.Click();

            return new MobileCRMdealPage();
        }
    }
}
