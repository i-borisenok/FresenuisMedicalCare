using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using FresenuisMedicalCare.Authorization;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Страница изменения пароля.
    /// </summary>
    public partial class RecoverPasswordPage : Page
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор страницы изменения пароля.
        /// </summary>
        public RecoverPasswordPage()
        {
            InitializeComponent();
        }

        #endregion Конструкторы

        #region Кнопка "Назад"

        /// <summary>
        /// Обработчик нажатия кнопки "Назад".
        /// </summary>
        private void OpenPreviousPage_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());  // Открывается страница авторизации пользователя.
        }

        #endregion Кнопка "Назад"

        #region Кнопка "Отправить письмо на почту"

        /// <summary>
        /// Обработчик нажатия кнопки "Отправить письмо на почту".
        /// </summary>
        private void SendPasswordOnEmail_Click(object sender, RoutedEventArgs e)
        {
            if (userEmail.Text != string.Empty)
            {
                if (!userEmail.Text.Contains("@"))
                {
                    ErrorMessageBlock.Text = MessagesAndErrors.IncorrectEmailError;
                }
                else
                {
                    try  // Поиск аккаунта, привязанного к почте.
                    {
                        using (DB db = new DB())
                        {
                            //Employee employee = db.Employees
                            //    .Where(c => c.Email == userEmail.Text)
                            //    .FirstOrDefault();
                            Employee employee = Employee.SearchEmployeeByEmail(userEmail.Text, db);

                            if (employee != null)   // Пользователь с такой почтой найден.
                            {
                                SendMail();  // Отправка письма.
                            }
                            else
                            {
                                MessagesAndErrors.ShowWindowError(RecoverPasswordContentGrid, MessagesAndErrors.AccountNotFoundError);
                            }
                        }
                    }
                    catch
                    {
                        string message = MessagesAndErrors.DataBaseConnectionError + "\n" + MessagesAndErrors.LoginToAccountLater;
                        MessagesAndErrors.ShowWindowError(RecoverPasswordContentGrid, message);
                    }
                }
            }
            else
            {
                ErrorMessageBlock.Text = MessagesAndErrors.EmptyStringError;
            }
        }

        /// <summary>
        /// Процедура, отправляющая письмо на электронную почту.
        /// </summary>
        void SendMail() 
        {
            try
            {
                EmailMessage message = new EmailMessage(userEmail.Text);
                message.SendMessage();
                string pin = Convert.ToString(message.GetPin());

                Application.Current.Windows[0].Opacity = 0.5;  // Затемняется фон.
                RecoverPasswordContentGrid.IsEnabled = false;  // Отключается интерфейс.

                RecoverPasswordMessageWindow messageWindow = new RecoverPasswordMessageWindow(pin);  // Открывается окно ввода пинкода из письма.
                messageWindow.ShowDialog();

                if (messageWindow.DialogResult == true)  // Пароли совпадают. 
                {
                    messageWindow.Close();
                    Application.Current.Windows[0].Opacity = 1;   // Восстанавливается фон.

                    NavigationService.Navigate(new CreateNewPasswordPage(userEmail.Text));  // Открывается страница создания нового пароля.
                }
                else
                {
                    Application.Current.Windows[0].Opacity = 1;
                    NavigationService.Navigate(new AuthorizationPage());  // Открывается страница авторизации пользователя.
                }
            }
            catch  // При отправке сообщения произошла ошибка. 
            {
                MessagesAndErrors.ShowWindowError(RecoverPasswordContentGrid, MessagesAndErrors.SendingTheMailError);
            }
        }

        #endregion Кнопка "Отправить письмо на почту"

        #region Поле "Email"

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Email".
        /// </summary>
        private void userEmail_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ErrorMessageBlock.Text = string.Empty;
        }

        /// <summary>
        /// Событие при нажатии кнопки Enter на поле "Email".
        /// </summary>
        private void userEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendPasswordOnEmail_Click(sender, e);
            }
        }

        #endregion Поле "Email"

    }
}
