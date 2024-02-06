using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Страница создания нового пароля.
    /// </summary>
    public partial class CreateNewPasswordPage : Page
    {
        #region Константы и переменные

        string mail;
        bool enterButton = true;
        bool dialogResult;

        #endregion Константы и переменные

        #region Конструкторы

        /// <summary>
        /// Конструктор страницы создания нового пароля.
        /// </summary>
        /// <param name="userEmail">Email аккаунта, для которого создается новый пароль.</param>
        public CreateNewPasswordPage(string userEmail)
        {
            mail = userEmail;
            InitializeComponent();
        }

        #endregion Конструкторы

        #region Поле "Пароль"

        /// <summary>
        /// Обработчик события нажатия левой кнопки мыши на поле "Пароль".
        /// </summary>
        private void userPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserPassword_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик события при нажатии клавиши Enter на поле "Пароль".
        /// </summary>
        private void userPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                userPassword_Copy.Focus();  // Курсор ввода текста перемещается на поле "Повторите пароль".
            }
        }

        #endregion Поле "Пароль"

        #region Поле "Повторите пароль"

        /// <summary>
        /// Обработчик события нажатия левой кнопки мыши на поле "Повторите пароль".
        /// </summary>
        private void userPassword_Copy_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserPassword_Copy_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик события при нажатии клавиши Enter на поле "Повторите пароль".
        /// </summary>
        private void userPassword_Copy_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateNewPassword_Click(sender, e);  // Вызывается обработчик нажатия кнопки "Сохранить пароль".
            }
        }

        #endregion "Повторите пароль"

        #region Кнопка "Сохранить пароль"

        /// <summary>
        /// Событие при нажатии на кнопку "Сохранить пароль".
        /// </summary>
        private void CreateNewPassword_Click(object sender, RoutedEventArgs e)
        {
            if (CheckCorrectUserInput())
            {
                try
                {
                    using (DB db = new DB())
                    {
                        Employee employee = Employee.SearchEmployeeByEmail(mail, db);

                        if (employee != null)  // Пользователь найден.
                        {
                            employee.Password = userPassword_Copy.Text;  // Сохраняется новый пароль в записи с пользователем.
                            db.SaveChanges();

                            string message = MessagesAndErrors.UserRecoverPasswordSuccessful + "\n " + MessagesAndErrors.QuestionAboutAuthorization;

                            MessagesAndErrors.ShowWindowSuccess(CreateNewPasswordContentGrid, message, enterButton, out dialogResult);

                            if (dialogResult) 
                            {
                                NavigationService.Navigate(new AuthorizationPage(employee.Login, employee.Password));
                            }
                            else
                            {
                                NavigationService.Navigate(new AuthorizationPage());
                            }
                        }
                        else
                        {
                            MessagesAndErrors.ShowWindowError(CreateNewPasswordContentGrid, MessagesAndErrors.AccountNotFoundError);
                        }
                    }
                }
                catch
                {
                    string message = MessagesAndErrors.UserEditDataError + "\n" + MessagesAndErrors.UserCreatePasswordError;
                    MessagesAndErrors.ShowWindowError(CreateNewPasswordContentGrid, message);

                    NavigationService.Navigate(new AuthorizationPage());
                }
            }
        }

        /// <summary>
        /// Функция, проверяющая правильность вводимых пользователем данных.
        /// </summary>
        /// <returns>Возвращает true если пароли совпадают.</returns>
        bool CheckCorrectUserInput()
        {
            bool userInputIsCorrect = true;

            UserPassword_ErrorTextBlock.Text = string.Empty;
            UserPassword_Copy_ErrorTextBlock.Text = string.Empty;

            if (userPassword.Text == string.Empty)  // Проверка поля "Пароль".
            {
                UserPassword_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                userInputIsCorrect = false;
            }
            else if (userPassword_Copy.Text == string.Empty)  // Проверка поля "Повторите пароль".
            {
                UserPassword_Copy_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                userInputIsCorrect = false;
            }
            else
            {
                if (userPassword.Text != userPassword_Copy.Text)  // Проверка полей на одинаковость.
                {
                    UserPassword_Copy_ErrorTextBlock.Text = MessagesAndErrors.RepeatPasswordError;
                    userInputIsCorrect = false;
                }
            }

            return userInputIsCorrect;
        }

        #endregion Кнопка "Сохранить пароль"

        #region Кнопка "Отмена"

        /// <summary>
        /// Событие при нажатии на кнопку "Отмена".
        /// </summary>
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());  // Открывается страница авторизации.     
        }

        #endregion Кнопка "Отмена"

    }
}
