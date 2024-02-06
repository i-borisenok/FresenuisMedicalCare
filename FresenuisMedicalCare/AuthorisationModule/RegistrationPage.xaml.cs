using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Страница регистрации.
    /// </summary>
    public partial class RegistrationPage : Page
    {
        #region Константы и переменные.

        const string phoneNumberFormat = "+7";
        List<int> years = new List<int>(Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse());  // Содержит список лет.
        List<string> months = new List<string> { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };  // Содержит список из 12 месяцев.

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор страницы регистрации.
        /// </summary>
        public RegistrationPage()
        {
            InitializeComponent();

            Years_ComboBox.ItemsSource = years;
            Months_ComboBox.ItemsSource = months;
        }

        #endregion Конструкторы

        #region Кнопка "Зарегистрироваться"
        
        /// <summary>
        /// Нажатие на кнопку регистрации нового пользователя.
        /// </summary>
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = string.Empty;

            if (CheckCorrectUserInput())  // Проверка на правильность введенных пользователем данных.
            {
                CorrectUserInput();  // Редактирование введенных пользователем данных.

                if (checkLoginInDataBase()) // Такой же пользователь не найден.
                {                 
                    NewUserRegistration();  // Регистрация нового пользователя.
                }
                else 
                {
                    ErrorTextBlock.Text = MessagesAndErrors.UserRegistrationError;
                    return;
                }
            }
        }

        #endregion Кнопка "Зарегистрироваться"

        #region Валидация данных пользователя

        /// <summary>
        /// Процедура по удалению лишних пробелов из строк и приведению первых букв к верхнему регистру, а последующих букв - к нижнему регистру.
        /// </summary>
        private void CorrectUserInput()
        {
            UserSurname.Text = UserSurname.Text.Replace(" ", "");  // Удалаются пробелы в строке.
            UserSurname.Text = UserSurname.Text.Substring(0, 1).ToUpper()
                + UserSurname.Text.Substring(1).ToLower();  // Первая буква строки приводится к верхнему регистру.

            UserName.Text = UserName.Text.Replace(" ", "");  // Удалаются пробелы в строке.
            UserName.Text = UserName.Text.Substring(0, 1).ToUpper()
                + UserName.Text.Substring(1).ToLower();    // Первая буква строки приводится к верхнему регистру.

            UserPatronymic.Text = UserPatronymic.Text.Replace(" ", "");  // Удалаются пробелы в строке.
            UserPatronymic.Text = UserPatronymic.Text.Substring(0, 1).ToUpper()
                + UserPatronymic.Text.Substring(1).ToLower();  // Первая буква строки приводится к верхнему регистру.

            UserEmail.Text = UserEmail.Text.Replace(" ", "");  // Удалаются пробелы в строке.
        }

        /// <summary>
        /// Процедура поиска логина пользователя в базе данных.
        /// </summary>
        /// <returns>Возвращает значение True если логин свободен. Иначе False.</returns>
        private bool checkLoginInDataBase()
        {
            try
            {
                using (DB db = new DB())
                {
                    Employee employee = db.Employees
                        .Where(c => c.Login == UserLogin.Text)
                        .FirstOrDefault();

                    if (employee != null) // логин занят
                    {
                        UserLogin_ErrorTextBlock.Text = MessagesAndErrors.UserLoginError;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                MessagesAndErrors.ShowWindowError(RegistrationContentGrid, MessagesAndErrors.DataBaseConnectionError);
                return false;
            }
        }

        /// <summary>
        /// Процедура по регистрации нового пользователя.
        /// </summary>
        private void NewUserRegistration()
        {
            string userName = UserSurname.Text + " " + UserName.Text + " " + UserPatronymic.Text;

            try
            {
                using (DB db = new DB())
                {
                    Employee employee = new Employee()
                    {
                        Name = userName,
                        Login = UserLogin.Text,
                        Password = UserPassword.Text,
                        Email = UserEmail.Text,
                        Phone = UserPhoneNumber.Text,
                        Birthday = Convert.ToDateTime(Years_ComboBox.Text + "." + Months_ComboBox.Text + "." + Days_ComboBox.Text),
                        Position = UserPosition.Text,
                    };
                    db.Employees.Add(employee);
                    db.SaveChanges();

                    // Вызов метода SaveChanges() сохраняет изменения в базе данных.
                    // И при первой вставке данных вызов SaveChanges() создаст базу данных.
                    // При первой отправке возникает заметная задержка в ответе от сервера
                    // – именно в данной точке и создается база данных.

                    Application.Current.Windows[0].Opacity = 0.5;  // Затемняется фон.
                    RegistrationContentGrid.IsEnabled = false;  // Отключается интерфейс.

                    string messageText = MessagesAndErrors.UserRegistrationSuccessful + "\n" + MessagesAndErrors.QuestionAboutAuthorization;
                    bool enterButton = true;
                    MessageWindow window = new MessageWindow(messageText, enterButton);
                    window.ShowDialog();

                    if (window.DialogResult == true)
                    {
                        window.Close();
                        Application.Current.Windows[0].Opacity = 1;  // Восстанавливается фон.
                        NavigationService.Navigate(new AuthorizationPage(UserLogin.Text, UserPassword.Text));  // Открывается страница авторизации с заполненными полями "Логин" и "Пароль".
                    }
                    else
                    {
                        window.Close();
                        Application.Current.Windows[0].Opacity = 1;  // Восстанавливается фон.
                        RegistrationContentGrid.IsEnabled = true;  // Включается интерфейс.
                    }
                }
            }
            catch
            {
                string message = MessagesAndErrors.DataBaseConnectionError + "\n" + MessagesAndErrors.UserCreateAccountError;
                MessagesAndErrors.ShowWindowError(RegistrationContentGrid, message);
                NavigationService.Navigate(new AuthorizationPage());
            }
        }

        /// <summary>
        /// Процедура проверки введенных пользователем данных.
        /// </summary>
        private bool CheckCorrectUserInput()
        {
            bool usersInputIsCorrect = true;

            // Проверка фамилии.
            if (UserSurname.Text == string.Empty)
            {
                UserSurname_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }

            // Проверка имени.
            if (UserName.Text == string.Empty)
            {
                UserName_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }

            // Проверка отчества.
            if (UserPatronymic.Text == string.Empty)
            {
                UserPatronymic_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }

            // Проверка даты рождения.
            if (Days_ComboBox.Text == string.Empty)
            {
                UserBirthday_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }
            else if (Convert.ToDateTime(Years_ComboBox.Text + "." + Months_ComboBox.Text + "." + Days_ComboBox.Text) >= DateTime.Today)
            {
                UserBirthday_ErrorTextBlock.Text = MessagesAndErrors.IncorrectDateError;
                usersInputIsCorrect = false;
            }

            // Проверка электронной почты.
            if (UserEmail.Text == string.Empty)
            {
                UserEmail_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }
            else if (!UserEmail.Text.Contains("@"))
            {
                UserEmail_ErrorTextBlock.Text = MessagesAndErrors.IncorrectEmailError;
                usersInputIsCorrect = false;
            }

            // Проверка номера телефона.
            if (UserPhoneNumber.Text == string.Empty)
            {
                UserPhoneNumber_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }
            else if (UserPhoneNumber.Text.Length != UserPhoneNumber.MaxLength)
            {
                UserPhoneNumber_ErrorTextBlock.Text = MessagesAndErrors.PhoneNumberLenghtError;
                usersInputIsCorrect = false;
            }
            else if (UserPhoneNumber.Text.Substring(0, 2) != phoneNumberFormat)
            {
                UserPhoneNumber_ErrorTextBlock.Text = MessagesAndErrors.PhoneNumberFormatError;
                usersInputIsCorrect = false;
            }

            // Проверка должности.
            if (UserPosition.Text == string.Empty)
            {
                UserPosition_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }

            // Проверка логина.
            if (UserLogin.Text == string.Empty)
            {
                UserLogin_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }

            // Проверка пароля.
            if (UserPassword.Text == string.Empty)
            {
                UserPassword_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }

            // Проверка копии пароля.
            if (UserPasswordRepeat.Text == string.Empty)
            {
                UserPasswordRepeat_ErrorTextBlock.Text = MessagesAndErrors.EmptyStringError;
                usersInputIsCorrect = false;
            }
            else if (UserPassword.Text != UserPasswordRepeat.Text)
            {
                UserPasswordRepeat_ErrorTextBlock.Text = MessagesAndErrors.RepeatPasswordError;
                usersInputIsCorrect = false;
            }

            return usersInputIsCorrect;
        }

        /// <summary>
        /// Процедура поиска пользователя в базе данных.
        /// </summary>
        private bool checkUserInDataBase()
        {
            try
            {
                using (DB db = new DB())
                {
                    Employee employee = db.Employees
                        .Where(c => c.Email == UserEmail.Text)
                        .FirstOrDefault();

                    if (employee != null) // пользователь найден
                    {
                        return true;
                    }
                    else    // такого пользователя нет
                    {
                        return false;
                    }
                }
            }
            catch
            {
               MessagesAndErrors.ShowWindowError(RegistrationContentGrid, MessagesAndErrors.DataBaseConnectionError);
                return false;
            }
        }

        #endregion Валидация данных пользователя

        #region Кнопка "Назад"

        /// <summary>
        /// Кнопка, открывающая предыдущую страницу.
        /// </summary>
        private void OpenPreviousPage_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        #endregion Кнопка "Назад"

        #region Поле "Фамилия"

        /// <summary>
        /// Обработчик перед вводом текста в поле "Фамилия".
        /// </summary>
        private void UserSurname_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;  // Запрещено вводить все, кроме текста.
            }

            if (UserSurname.Text.Length == 1)
            {
                UserSurname.Text = UserSurname.Text.ToUpper();  // Приводит первый символ строки к верхнему регистру.
                UserSurname.Select(UserSurname.Text.Length, 0);  // Сдвигает курсор ввода текста правее от первого символа.
            }
        }

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Фамилия".
        /// </summary>
        private void UserSurname_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserSurname_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Фамилия".
        /// </summary>
        private void UserSurname_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Фамилия"

        #region Поле "Имя"

        /// <summary>
        /// Обработчик перед вводом текста в поле "Имя".
        /// </summary>
        /// 
        private void UserName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;  // Запрещено вводить все, кроме текста.
            }

            if (UserName.Text.Length == 1)
            {
                UserName.Text = UserName.Text.ToUpper();  // Приводит первый символ строки к верхнему регистру.
                UserName.Select(UserName.Text.Length, 0);  // Сдвигает курсор ввода текста правее от первого символа.
            }
        }

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Имя".
        /// </summary>
        private void UserName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserName_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Имя".
        /// </summary>
        private void UserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Имя"

        #region Поле "Отчество"

        /// <summary>
        /// Обработчик перед вводом текста в поле "Отчество".
        /// </summary>
        private void UserPatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, 0))
            {
                e.Handled = true;  // Запрещено вводить все, кроме текста.
            }

            if (UserPatronymic.Text.Length == 1)
            {
                UserPatronymic.Text = UserPatronymic.Text.ToUpper();  // Приводит первый символ строки к верхнему регистру.
                UserPatronymic.Select(UserPatronymic.Text.Length, 0);  // Сдвигает курсор ввода текста правее от первого символа.
            }
        }

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Отчество".
        /// </summary>
        private void UserPatronymic_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserPatronymic_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Отчество".
        /// </summary>
        private void UserPatronymic_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Отчество"

        #region Поле "Год"

        /// <summary>
        /// Событие после выбора значения в поле "Год".
        /// </summary>
        private void Years_ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (Years_ComboBox.Text != string.Empty)
            {
                Months_ComboBox.IsEnabled = true;  // Включается поле выбора месяца.
            }
        }

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Год".
        /// </summary>
        private void Years_ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserBirthday_ErrorTextBlock.Text = string.Empty;
        }

        #endregion Поле "Год"

        #region Поле "Месяц"

        /// <summary>
        /// Событие после выбора значения в поле "Месяц".
        /// </summary>
        private void Months_ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (Months_ComboBox.Text != string.Empty)  // Если месяц выбран.
            {
                Days_ComboBox.IsEnabled = true;  // Включается поле выбора дня.
            }
            if (Days_ComboBox.Text != string.Empty) // Если день уже был выбран.
            {
                int year = Convert.ToInt32(Years_ComboBox.Text);
                int month = GetMonthByName(Months_ComboBox.Text);
                int daysInMonths = DateTime.DaysInMonth(year, month);

                int day = Convert.ToInt32(Days_ComboBox.Text);

                if (day > daysInMonths)  // Если выбранный день больше крайнего дня в месяце.
                {
                    Days_ComboBox.Text = string.Empty;  // Очищается поле с днем.
                }
            }
        }

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Месяц".
        /// </summary>
        private void Months_ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserBirthday_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Возвращает номер месяца по названию.
        /// </summary>
        /// <param name="Month">Название месяца.</param>
        private int GetMonthByName(string Month)
        {
            switch (Month)
            {
                case "Январь":   return 1;
                case "Февраль":  return 2;
                case "Март":     return 3;
                case "Апрель":   return 4;
                case "Май":      return 5;
                case "Июнь":     return 6;
                case "Июль":     return 7;
                case "Август":   return 8;
                case "Сентябрь": return 9;
                case "Октябрь":  return 10;
                case "Ноябрь":   return 11;
                case "Декабрь":  return 12;
                default:         return 1;
            }
        }

        #endregion Поле "Месяц"

        #region Поле "День"

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "День".
        /// </summary>
        private void Days_ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserBirthday_ErrorTextBlock.Text = string.Empty;

            int startDay = 1;
            int month = GetMonthByName(Months_ComboBox.Text);
            int year = Convert.ToInt32(Years_ComboBox.Text);
            int endDay = DateTime.DaysInMonth(year, month);
            var daysInMonth = Enumerable.Range(startDay, endDay);
            Days_ComboBox.ItemsSource = new List<int>(daysInMonth);  // В поле выбора дня присваивается список из дней в данном месяце.
        }

        #endregion Поле "День"

        #region Поле "Email"

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Email".
        /// </summary>
        private void UserEmail_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserEmail_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Email".
        /// </summary>
        private void UserEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Email"

        #region Поле "Телефон"

        /// <summary>
        /// Обработчик перед вводом текста в поле "Телефон".
        /// </summary>
        private void UserPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;  // Запрещено вводить все, кроме десятичных цифр.
            }
            if (e.Text == "+")
            {
                e.Handled = false;  // Разрешено вводить плюс.
            }
        }

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Телефон".
        /// </summary>
        private void UserPhoneNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (UserPhoneNumber.Text == string.Empty)
            {
                UserPhoneNumber.Text = phoneNumberFormat;
            }
            UserPhoneNumber_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Событие при схождении фокуса с поля "Телефон".
        /// </summary>
        private void UserPhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UserPhoneNumber.Text == phoneNumberFormat)  // Если в поле номера телефона только "+7"
            {
                UserPhoneNumber.Text = string.Empty;
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Телефон".
        /// </summary>
        private void UserPhoneNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Телефон"

        #region Поле "Должность"

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Должность".
        /// </summary>
        private void UserPosition_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserPosition_ErrorTextBlock.Text = string.Empty;
        }

        #endregion Поле "Должность"

        #region Поле "Логин"

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Логин".
        /// </summary>
        private void UserLogin_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserLogin_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Логин".
        /// </summary>
        private void UserLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Логин"

        #region Поле "Пароль"

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Пароль".
        /// </summary>
        private void UserPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserPassword_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Пароль".
        /// </summary>
        private void UserPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Пароль"

        #region Поле "Повторите пароль"

        /// <summary>
        /// Событие при нажатии левой кнопкой мыши на поле "Повторите пароль".
        /// </summary>
        private void UserPasswordRepeat_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserPasswordRepeat_ErrorTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Обработчик нажатия кнопки клавиатуры на поле "Повторите пароль".
        /// </summary>
        private void UserPasswordRepeat_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckForASpase(sender, e);
        }

        #endregion Поле "Повторите пароль"

        #region Общие методы

        /// <summary>
        /// Процедура, запрещающая вводить пробел в текстовое поле.
        /// </summary>
        private void CheckForASpase(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)  // Если клавиша является пробелом.
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}   



