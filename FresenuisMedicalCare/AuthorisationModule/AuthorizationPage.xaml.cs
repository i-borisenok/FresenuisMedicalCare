using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Страница авторизации.
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        #region Константы и переменные

        const string emptyString = "";

        #endregion Константы и переменные

        #region Конструкторы

        /// <summary>
        /// Конструктор страницы авторизации с двумя необязательными параметрами.
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        /// <param name="userPassword">Пароль пользователя.</param>
        public AuthorizationPage(string userName = emptyString, string userPassword = emptyString)
        {
            InitializeComponent();

            UserLogin.Text = userName;
            UserPassword.Password = userPassword;

            ShowPasswordImage_OFF.Visibility = Visibility.Collapsed; // Отключается картинка "Показать пароль".
        }

        #endregion Конструкторы

        #region Кнопка "Назад"

        /// <summary>
        /// Кнопка открытия страницы регистрации нового пользователя.
        /// </summary>
        private void OpenRegistrationPage_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        #endregion

        #region Кнопка "Авторизация"

        /// <summary>
        /// Кнопка авторизации пользователя.
        /// </summary>
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {          
            if(checkUserInput())
            {
                if (сheckUserInDataBase())
                {
                    MainWindow mainWindow = new MainWindow(UserLogin.Text);
                    mainWindow.Show();
                    Application.Current.Windows[0].Close();
                }
                else
                {
                    ErrorMessageBlock.Text = MessagesAndErrors.IncorrectLoginOrPasswordError;
                }
            }
        }

        /// <summary>
        /// Проверка на заполнение данных пользователем.
        /// </summary>
        private bool checkUserInput()
        {
            ErrorMessageBlock.Text = emptyString;

            if (UserLogin.Text == emptyString || UserPassword.Password == emptyString)
            {
                ErrorMessageBlock.Text = MessagesAndErrors.LoginOrPasswordEmptyError;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Поиск пользователя в базе данных по логину и паролю.
        /// </summary>
        private bool сheckUserInDataBase()
        {
            try
            {
                using (DB db = new DB())
                {
                    Employee employee = db.Employees
                        .Where(c => c.Login == UserLogin.Text)
                        .Where(c => c.Password == UserPassword.Password)
                        .FirstOrDefault();

                    if (employee != null)  // Если пользователь найден.
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                string message = MessagesAndErrors.DataBaseConnectionError + "\n" + MessagesAndErrors.LoginToAccountLater;
                MessagesAndErrors.ShowWindowError(AuthorizationContentGrid, message);
                
                return false;
            }
        }

        #endregion

        #region Поля "Ввод логина/пароля"

        /// <summary>
        /// Событие при нажатии кнопки Enter на поле ввода логина пользователя.
        /// </summary>
        private void UserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                UserPassword.Focus();  // Курсор ввода перемещается в поле пароля.
            }    
        }

        /// <summary>
        /// Событие при нажатии кнопки Enter на поле ввода пароля пользователя.
        /// </summary>
        private void UserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AuthorizationButton_Click(sender, e);  // Вызывается обработчик нажатия кнопки авторизации.
            }
        }

        #endregion

        #region Поля "Вывод ошибок"

        /// <summary>
        /// Событие при нажатии левой кнопки мыши на поле ввода логина пользователя.
        /// </summary>
        private void UserLogin_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearErrorMessageBlock();
        }

        /// <summary>
        /// Событие при нажатии левой кнопки мыши на поле ввода пароля пользователя.
        /// </summary>
        private void UserPassword_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearErrorMessageBlock();
        }

        /// <summary>
        /// Процедура, очищающая поле вывода ошибок.
        /// </summary>
        void ClearErrorMessageBlock()
        {
            ErrorMessageBlock.Text = emptyString;
        }
        
        #endregion

        #region Кнопки "Показать/скрыть пароль"

        /// <summary>
        /// Событие при нажатии на картинку "Показать пароль".
        /// </summary>
        private void ShowPasswordImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordImage_OFF.Visibility = Visibility.Visible;  // Включается картинка "Скрыть пароль".
            ShowPasswordImage_ON.Visibility = Visibility.Collapsed;  // Отключается картинка "Показать пароль".

            UserPassword.Visibility = Visibility.Collapsed;  // Отключается скрытый пароль.
            UserPasswordText_Visible.Visibility = Visibility.Visible;  // Включается открытый пароль.
            UserPasswordText_Visible.Text = UserPassword.Password;  // Открытому паролю присваивается текст скрытого пароля.
        }

        /// <summary>
        /// Событие при нажатии на картинку "Скрыть пароль".
        /// </summary>
        private void ShowPasswordImage_OFF_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordImage_OFF.Visibility = Visibility.Collapsed;  // Отключается картинка "Скрыть пароль".
            ShowPasswordImage_ON.Visibility = Visibility.Visible;  // Включается картинка "Показать пароль".

            UserPassword.Visibility = Visibility.Visible;  // Включается скрытый пароль.
            UserPasswordText_Visible.Visibility = Visibility.Collapsed;  // Выключается открытый пароль.
            UserPassword.Password = UserPasswordText_Visible.Text; // Скрытому паролю присваивается текст открытого пароля.
        }
        
        #endregion

        #region Кнопка "Восстановить пароль"

        /// <summary>
        /// Событие при наведении курсора мыши на надпись "Восстановить пароль".
        /// </summary>
        private void RecoverPassword_label_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            RecoverPassword_text.TextDecorations = TextDecorations.Underline;  // Текст подчеркивается.
            RecoverPassword_text.FontStyle = FontStyles.Italic;  // Шрифт текста меняется на курсив.
        }

        /// <summary>
        /// Событие, когда курсор мыши покидает надпись "Восстановить пароль".
        /// </summary>
        private void RecoverPassword_label_MouseLeave(object sender, MouseEventArgs e)
        {
            RecoverPassword_text.TextDecorations = null; // Текст становится без подчеркивания.
            RecoverPassword_text.FontStyle = FontStyles.Normal; // Текст приобретает обычный шрифт.
        }

        /// <summary>
        /// Событие при нажатии мыши на надпись "Восстановить пароль".
        /// </summary>
        private void RecoverPassword_label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RecoverPasswordPage());  // Открывается страница восстановления пароля.
        }

        #endregion
    }
}
