using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace GosuslugiTest
{
    /// <summary>
    /// ����� ������������ ����� "���������"
    /// </summary>
    public class GosuslugiServiceTest
    {
        /// <summary>
        /// ������ ������� ����� ����� ������ �� ��������
        /// </summary>
        private bool statusForm;

        /// <summary>
        /// �������� �������� ����� �������������� ������ � �������� Edge
        /// </summary>
        [Test]
        public void Edge_OpenThePasswordChangeForm_ReturnTrue()
        {
            OpenThePasswordChangeForm_ReturnTrue(new EdgeDriver());
        }

        /// <summary>
        /// �������� �������� ����� �������������� ������ � �������� Chrome
        /// </summary>
        [Test]
        public void Chrome_OpenThePasswordChangeForm_ReturnTrue()
        {
            OpenThePasswordChangeForm_ReturnTrue(new ChromeDriver());
        }

        /// <summary>
        /// �������� �������� ����� �������������� ������ � �������� Firefox
        /// </summary>
        [Test]
        public void Firefox_OpenThePasswordChangeForm_ReturnTrue()
        {
            OpenThePasswordChangeForm_ReturnTrue(new FirefoxDriver());
        }

        /// <summary>
        /// �������� �������� ����� �������������� ������
        /// </summary>
        public void OpenThePasswordChangeForm_ReturnTrue(IWebDriver driver)
        {
            // ������������� �������� 10 ������
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // ������������� ���� �������� �� ���� �����
            driver.Manage().Window.Maximize();
            // �������� ������ �� ���������
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");

            // �������� �� ������ "�����"
            driver.FindElement(By.CssSelector("button[tabindex='9']")).Click();
            // �������� �� ������ "�� ������� �����?"
            driver.FindElement(By.CssSelector("div[class='mt-40 text-center']")).Click();
            // �������� �� ������ "�������������� ������"
            driver.FindElement(By.CssSelector("ul[class='plain-list']")).
                FindElement(By.CssSelector("button[class='plain-button-inline']")).Click();
            // ��������� ��������� �� ����� �������������� ������ �� ��������
            statusForm = driver.FindElement(By.CssSelector("div[class='form-container']")).Displayed;
            // ��������� �������
            driver.Close();

            Assert.IsTrue(statusForm);
        }
    }
}