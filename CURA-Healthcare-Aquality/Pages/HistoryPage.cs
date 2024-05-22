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
    public class HistoryPage :Form
    {
        private ILabel _historyLabel => ElementFactory.GetLabel(By.XPath("//section[@id='history']//h2"), "History Section");
        public HistoryPage() : base(By.Id("history"),"History Section") { }

    }
}
