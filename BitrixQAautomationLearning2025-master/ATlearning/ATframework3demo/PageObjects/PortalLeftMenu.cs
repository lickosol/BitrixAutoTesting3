using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalLeftMenu
    {
        public IWebDriver Driver { get; }

        public PortalLeftMenu(IWebDriver driver = default)
        {
            Driver = driver;
        }

        private void ClickMenuItem(WebItem menuItem)
        {
            var menuItemsArea = new WebItem("//div[@id='menu-items-block']", "Область с пунктами левого меню");
            if (menuItemsArea.Size(Driver).Width < 150)
            {
                var expandMenuButton = new WebItem("//div[@class='menu-switcher']", "Кнопка сворачивания левого меню");
                expandMenuButton.Hover(Driver);
                var menuHeader = new WebItem("//div[@class='menu-items-header-title']", "Кнопка сворачивания левого меню");
                menuHeader.Click(Driver);
            }

            if (menuItem.WaitElementDisplayed(driver: Driver) == false)
            {
                //развернуть меню
                var btnMore = new WebItem("//span[@id='menu-more-btn-text']", "Кнопка Ещё левого меню");
                btnMore.Click(Driver);
            }
            //клик в пункт меню
            menuItem.Click(Driver);
        }

        public TasksListPage OpenTasks()
        {
            ClickMenuItem(new WebItem("//li[@id='bx_left_menu_menu_tasks']", "Пункт левого меню 'Задачи'"));
            return new TasksListPage(Driver);
        }

        public SiteListPage OpenSites()
        {
            ClickMenuItem(new WebItem("//li[@id='bx_left_menu_menu_sites']", "Пункт левого меню 'Сайты'"));
            return new SiteListPage(Driver);
        }

        public PortalSettingsMainPage OpenSettings()
        {
            var btnSettings = new WebItem("//li[@id='bx_left_menu_menu_configs_sect']", "Пункт левого меню настройки");
            ClickMenuItem(btnSettings);
            return new PortalSettingsMainPage(Driver);
        }

        public NewsPage OpenNews()
        {
            //клик в пункт меню Новости
            var btnNews = new WebItem("//li[@id='bx_left_menu_menu_live_feed']", "Пункт левого меню Новости");
            ClickMenuItem(btnNews);
            return new NewsPage(Driver);
        }

        public AutomatisationListPage OpenAutomatisation()
        {
            //клик в пункт меню Автоматизация
            var btnAutomatisation = new WebItem("//li[@id='bx_left_menu_menu_automation']", "Пункт левого меню Автоматизация");
            ClickMenuItem(btnAutomatisation);
            return new AutomatisationListPage(Driver);
        }

        public HobbyPage OpenHobbies()
        {
            //клик в пункт меню Досуг
            var btnHobby = new WebItem("//span[contains(@class, 'menu-item-link-text') and contains(text(), 'Досуг')]", "Пункт левого меню Досуг");
            ClickMenuItem(btnHobby);
            return new HobbyPage(Driver);
        }

        public MessengerPage OpenChats()
        {
            //клик в пункт меню Мессенджер
            var btnMessenger = new WebItem("//span[contains(@class, 'menu-item-link-text') and contains(text(), 'Мессенджер')]", "Пункт левого меню Досуг");
            ClickMenuItem(btnMessenger);            
            return new MessengerPage(Driver);
        }

        public CalendarPage OpenCalendar()
        {
            //клик в пункт меню Мессенджер
            var btnCalendar = new WebItem("//span[contains(@class, 'menu-item-link-text') and contains(text(), 'Календарь')]", "Пункт левого меню Календарь");
            ClickMenuItem(btnCalendar);
            return new CalendarPage(Driver);
        }

        public CreationEventFramePage OpenCreationEventFrame()
        {
            //клик в пункт меню Мессенджер
            var btnCalendar = new WebItem("//span[contains(@class, 'menu-item-link-text') and contains(text(), 'Создать событие')]", "Пункт левого меню Календарь");
            ClickMenuItem(btnCalendar);
            return new CreationEventFramePage(Driver);
        }
    }
}
