using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Окно для вывода сообщений.
    /// </summary>
    public partial class MessageWindow : Window
    {
        #region Константы и переменные

        const string OK = "ОК";
        const string Enter = "Войти";
        const string Yes = "Да";
        const string No = "Нет";
        const string Cancel = "Отмена";

        #endregion Константы и переменные

        #region Конструкторы

        /// <summary>
        /// Конструктор сообщения об ошибке с одной кнопкой "ОК".
        /// </summary>
        /// <param name="messageText">Текст сообщения об ошибке.</param>
        public MessageWindow(string messageText) 
        {
            InitializeComponent();

            MessageBlock.Text = messageText;

            Main_Button.Content = OK;   // кнопка ОК

            OK_Button.Visibility = Visibility.Collapsed;  //отключаем  кнопку "ОК"
            Cancel_Button.Visibility =Visibility.Collapsed;  //отключаем кнопку "Отмена"
        }

        /// <summary>
        /// Конструктор сообщения с вопросом об авторизации в программе.
        /// </summary>
        /// <param name="userLogin">Логин пользователя для выполнения входа.</param>
        /// <param name="userPassword">Пароль пользователя для выполнения входа.</param>
        /// <param name="messageText">Текст вопроса.</param>
        public MessageWindow(string messageText, bool EnterButton = false)
        {
            InitializeComponent();

            if (EnterButton)
            {
                Main_Button.Content = Enter;   // Кнопка "Войти".
                OK_Button.Content = No;  // Кнопка "Нет".

                Cancel_Button.Visibility = Visibility.Collapsed;  //отключаем  кнопку "Отмена"
            }

            MessageBlock.Text = messageText;

        }

        #endregion Конструкторы

        #region Кнопка "ОК"

        /// <summary>
        /// Обработчик события нажатия кнопки "Ок".
        /// </summary>
        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        #endregion Кнопка "ОК"

        #region Кнопка "Отмена"

        /// <summary>
        /// Обработчик события нажатия кнопки "Отмена".
        /// </summary>
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
        #endregion Кнопка "Отмена"

        #region Кнопка "Войти"

        /// <summary>
        /// Обработчик события нажатия главной кнопки.
        /// </summary>
        private void Main_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        #endregion Кнопка "Войти"

    }
}
