using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace GosuslugiTest
{
    /// <summary>
    /// Класс тестирования сайта "Госуслуги"
    /// </summary>
    public class GosuslugiServiceTest
    {
        /// <summary>
        /// Статус наличия формы смена пароля на странице
        /// </summary>
        private bool statusForm;

        /// <summary>
        /// Проверка открытия формы восстановления пароля в браузере Edge
        /// </summary>
        [Test]
        public void Edge_OpenThePasswordChangeForm_ReturnTrue()
        {
            OpenThePasswordChangeForm_ReturnTrue(new EdgeDriver());
        }

        /// <summary>
        /// Проверка открытия формы восстановления пароля в браузере Chrome
        /// </summary>
        [Test]
        public void Chrome_OpenThePasswordChangeForm_ReturnTrue()
        {
            OpenThePasswordChangeForm_ReturnTrue(new ChromeDriver());
        }

        /// <summary>
        /// Проверка открытия формы восстановления пароля в браузере Firefox
        /// </summary>
        [Test]
        public void Firefox_OpenThePasswordChangeForm_ReturnTrue()
        {
            OpenThePasswordChangeForm_ReturnTrue(new FirefoxDriver());
        }

        /// <summary>
        /// Проверка открытия формы восстановления пароля
        /// </summary>
        public void OpenThePasswordChangeForm_ReturnTrue(IWebDriver driver)
        {
            // Устанавливаем ожидание 10 секунд
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // Устанавливаем окно браузера на весь экран
            driver.Manage().Window.Maximize();
            // Открытие ссылки на Госуслуги
            driver.Navigate().GoToUrl("https://www.gosuslugi.ru/");

            // Нажимаем на кнопку "Войти"
            driver.FindElement(By.CssSelector("button[tabindex='9']")).Click();
            // Нажимаем на кнопку "Не удается войти?"
            driver.FindElement(By.CssSelector("div[class='mt-40 text-center']")).Click();
            // Нажимаем на кнопку "Восстановление пароля"
            driver.FindElement(By.CssSelector("ul[class='plain-list']")).
                FindElement(By.CssSelector("button[class='plain-button-inline']")).Click();
            // Проверяем открылась ли форма восстановления пароля на странице
            statusForm = driver.FindElement(By.CssSelector("div[class='form-container']")).Displayed;
            // Закрываем браузер
            driver.Close();

            Assert.IsTrue(statusForm);
        }
    }
}