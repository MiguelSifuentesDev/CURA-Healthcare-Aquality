using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CURA_Healthcare_Aquality.Pages
{
    public class AppointmentPage : Form
    {
        private IElement _facilitySelect => ElementFactory.GetMultiChoiceBox(By.Id("combo_facility"), "Facility Selector");
        private ICheckBox _readmisionCheckbox => ElementFactory.GetCheckBox(By.Id("chk_hospotal_readmission"), "Readmision Checkbox");
        private ITextBox _visitDateTextbox => ElementFactory.GetTextBox(By.Id("txt_visit_date"), "Visit Date Textbox");
        private ITextBox _comment => ElementFactory.GetTextBox(By.Id("txt_comment"), "Comment Textarea");
        private IButton _bookAppoitmentButton => ElementFactory.GetButton(By.Id("btn-book-appointment"), "Book Appointment Button");
        private ILabel _appoitmentSummaty => ElementFactory.GetLabel(By.XPath("//section[@id='summary']//h2"), "Appointmen Summary");
        public AppointmentPage() : base(By.Id("appointment"),"Section Appoitment") { }

        public void SelectFacility(string facility)
        {
            var selectElement = new SelectElement(_facilitySelect.GetElement());
            selectElement.SelectByText(facility);
        }
        public void CheckReadmision()
        {
            _readmisionCheckbox.Check();
        }
        public void CheckMedicalProgram(string program)
        {
            var elements = ElementFactory.FindElements<IRadioButton>(By.Name("programs"), "Programs Radiobuttons");
            var programRadiobutton = elements.FirstOrDefault(r=>r.GetAttribute("value") == program);
            programRadiobutton.Click();
        }
        public void SetVisitDate(string visitDate)
        {
            _visitDateTextbox.ClearAndType(visitDate);
        }
        public void SetComment(string comment)
        {
            _comment.ClearAndType(comment);
        }
        public void submitAppoitment()
        {
            _bookAppoitmentButton.ClickAndWait();
        }
        public bool isAppoitmentBooked()
        {
            return _appoitmentSummaty.State.IsDisplayed;
        }
    }
}
