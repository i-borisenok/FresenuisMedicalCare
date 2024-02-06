using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FresenuisMedicalCare.Authorization
{
    /// <summary>
    /// Окно ввода пинкода из письма.
    /// </summary>
    public partial class RecoverPasswordMessageWindow : Window
    {
        #region Константы и переменные

        private bool pinIsTrue = false;
        private string pin;

        #endregion Константы и переменные

        #region Конструкторы

        /// <summary>
        /// Конструктор страницы Ввода пинкода из письма.
        /// </summary>
        /// <param name="Pin">Пинкод из 4 цифр.</param>
        public RecoverPasswordMessageWindow(string Pin)
        {
            InitializeComponent();

            pin = Pin;
            PasswordFromEmail.Focus();  // Курсор ввода устанавливается на поле ввода пинкода.
        }

        #endregion Конструкторы

        #region Кнопка "Ввести"

        /// <summary>
        /// Обработчик события при нажатии на кнопку "Ввести".
        /// </summary>
        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordFromEmail.Text.Length == PasswordFromEmail.MaxLength)
            {
                if (pinIsTrue == true)
                {
                    this.DialogResult = true;
                }
            }
            else
            {
                ErrorMessageBlock.Text = MessagesAndErrors.EmptyStringError;
            }
        }

        #endregion Кнопка "Ввести"

        #region Кнопка "Отмена"

        /// <summary>
        /// Обработчик события при нажатии на кнопку "Отмена".
        /// </summary>
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion Кнопка "Отмена"

        #region Поле "Пинкод"

        /// <summary>
        /// Обработчик события при вводе текста в поле "Пинкод".
        /// </summary>
        private void PasswordFromEmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {   
            if (!Char.IsDigit(e.Text, 0))  // Разрешен ввод только десятичных цифр.
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик события при нажатии клавиши в поле "Пинкод".
        /// </summary>
        private void PasswordFromEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ErrorMessageBlock.Text = string.Empty;

            if (e.Key == Key.Space)  // Запрещен ввод пробелов.
            {
                e.Handled = true;
            }
            if (e.Key == Key.Enter)  // При нажатии на Enter в поле "Пинкод".
            {
                Enter_Button_Click(sender, e);  // Вызывается обработчик нажатия на кнопку "Ввести".
            }
        }

        /// <summary>
        /// Обработчик события при изменении текста в поле "Пинкод".
        /// </summary>
        private void PasswordFromEmail_TextChanged(object sender, TextChangedEventArgs e) 
        {
            if (PasswordFromEmail.Text.Length == PasswordFromEmail.MaxLength)  // При изменении текста проверяем верность пароля, если его длина равна максимальной.
            {
                if (PasswordFromEmail.Text == pin)
                {
                    pinIsTrue = true;
                    PasswordFromEmail.Background = new SolidColorBrush(Color.FromArgb(50, 32, 230, 154));  // Зеленый фон.
                }
                else
                {
                    pinIsTrue = false;
                    PasswordFromEmail.Background = new SolidColorBrush(Color.FromArgb(40, 239, 123, 171));  // Красный фон.
                }
            }
            else
            {
                pinIsTrue = false;
                PasswordFromEmail.Background = new SolidColorBrush(Color.FromArgb(30, 123, 151, 239));  // Обычный фон.
            }
        }

        /// <summary>
        /// Обработчик события при нажатии левой клавишей мыши на поле "Пинкод".
        /// </summary>
        private void PasswordFromEmail_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ErrorMessageBlock.Text = string.Empty;
        }

        #endregion Поле "Пинкод"

    }            
}
