using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace CURA_Healthcare_Aquality.Pages
{
    public class MenuForm : Form
    {
        private ILink _menuLink => ElementFactory.GetLink(By.Id("menu-toggle"), "Menu Link");
        public MenuForm() : base(By.Id("sidebar-wrapper"),"Menu") { }

        public void NavigateToHistory() {
            var menuItems = ElementFactory.FindElements<ILink>(By.XPath("//nav[@id='sidebar-wrapper']//ul[@class='sidebar-nav']//a"), "Menu items");
            foreach (var item in menuItems)
            {
                if(item.Text == "History")
                {
                    item.ClickAndWait();
                    break;
                }
            }
        }

        public void OpenMenu()
        {
            _menuLink.ClickAndWait();
        }
    }
}
