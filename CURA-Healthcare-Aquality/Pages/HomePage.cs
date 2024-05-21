using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace CURA_Healthcare_Aquality.Pages
{
    internal class HomePage : Form
    {
        private IButton _makeAppoitmentButton => ElementFactory.GetButton(By.Id("btn-make-appointment"), "Make Appoitment Button");
        public HomePage() : base(By.Id("btn-make-appointment"),"Home Page") { }

        public void MakeAppointment() { 
            _makeAppoitmentButton.Click();
        }

    }
}
