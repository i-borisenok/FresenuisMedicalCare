using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Статический класс, содержащий в себе константы с текстами сообщений и ошибок.
    /// </summary>
    public static class MessagesAndErrors
    {
        public const string EmptyStringError = "Это поле не может быть пустым!";
        public const string IncorrectDateError = "Дата не может быть позже текущей даты!";
        public const string IncorrectEmailError = "Электронная почта должна содержать символ \"@\" !";
        public const string RepeatPasswordError = "Введенные пароли не совпадают!";
        public const string PhoneNumberFormatError = "Телефон должен быть в международном формате!";
        public const string PhoneNumberLenghtError = "Телефон указан неверно!";
        public const string UserLoginError = "Данный логин уже занят! Придумайте другой.";
        public const string UserRegistrationError = "Данный пользователь уже зарегистрирован! Войдите в аккаунт!";
        public const string DataBaseConnectionError = "Произошла ошибка при подключении к базе данных!";
        public const string LoginToAccountLater = "Войдите позже!";

        public const string SendingTheMailError = "Произошла ошибки при отправке сообщения! \n Попробуйте восстановить доступ позже!";
        public const string AccountNotFoundError = "Не найден аккаунт, привязанный к данной почте! \n Возможно аккаунт заведен на другую почту!";
        public const string UserEditDataError = "Произошла ошибка при попытке записать данные.";
        public const string UserCreateAccountError = "Аккаунт не создан!";
        public const string UserCreatePasswordError = "Пароль не сохранен!";
        public const string UserRegistrationSuccessful = "Регистрация прошла успешно!";
        public const string UserRecoverPasswordSuccessful = "Новый пароль успешно сохранен!";
        public const string IncorrectLoginOrPasswordError = "Не верный логин или пароль!";
        public const string LoginOrPasswordEmptyError = "Не введен пользователь или пароль!";
        public const string QuestionAboutAuthorization = "Войти?";

        /// <summary>
        /// Процедура вывода окна ошибки.
        /// </summary>
        /// <param name="Grid">Область на форме, которая будет затемняться.</param>
        /// <param name="ErrorMessage">Сообщение об ошибке.</param>
        public static void ShowWindowError(Grid Grid, string ErrorMessage)
        {
            Application.Current.Windows[0].Opacity = 0.5;  // Затемняется фон.
            Grid.IsEnabled = false; // Отключается интерфейс.

            MessageWindow window = new MessageWindow(ErrorMessage);
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                closeWindow(Grid, window);
            }
        }

        /// <summary>
        /// Процедура вывода окна с вопросом.
        /// </summary>
        /// <param name="Grid">Область на форме, которая будет затемняться.</param>
        /// <param name="Message">Сообщение с вопросом.</param>
        /// <param name="enterButton">Значение bool, где true - форма с кнопкой "Войти", а false - форма без кнопки "Войти".</param>
        /// <param name="DialogResult">Выходной параметр bool. Ответ пользователя на вопрос.</param>
        public static void ShowWindowSuccess(Grid Grid, string Message, bool enterButton, out bool DialogResult)
        {
            Application.Current.Windows[0].Opacity = 0.5;  // Затемняется фон.
            Grid.IsEnabled = false; // Отключается интерфейс.

            MessageWindow window = new MessageWindow(Message, enterButton);
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                closeWindow(Grid, window);
                DialogResult = true;
            }
            else
            {
                closeWindow(Grid, window);
                DialogResult = false;
            }
        }

        static void closeWindow(Grid Grid, MessageWindow Window)
        {
            Window.Close();
            Application.Current.Windows[0].Opacity = 1;  // Восстанавливается фон.
            Grid.IsEnabled = true;  // Включается интерфейс.
        }
    }
}
