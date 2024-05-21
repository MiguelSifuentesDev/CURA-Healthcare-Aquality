using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aquality.Selenium.Core.Forms;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace CURA_Healthcare_Aquality.Pages
{
    internal class LoginPage : Form
    {
        private ITextBox _usernameTextBox => ElementFactory.GetTextBox(By.Id("txt-username"), "username textbox");
        private ITextBox _passwordTextBox => ElementFactory.GetTextBox(By.Id("txt-password"), "password textbox");
        private IButton _loginButton => ElementFactory.GetButton(By.Id("btn-login"), "login button");
        private ILabel _errorMessage => ElementFactory.GetLabel(By.XPath("//section[@id=\"login\"]//p[contains(@class,'text-danger')]"), "Login Error Message");
        public LoginPage() : base(By.Id("login"), "Section Login") { }

        public void SetUsername(string username)
        {
            _usernameTextBox.ClearAndType(username);
        }

        public void SetPassword(string password)
        {
            _passwordTextBox.ClearAndType(password);
        }

        public void SubmitForm()
        {
            _loginButton.WaitAndClick();
        }

        public bool UnsuccessfulLogin()
        {
            return _errorMessage.State.IsDisplayed;
        }
    }
}
