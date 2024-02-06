
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new EmployeePage());
            CloseButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            WindowedModeButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            HideButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            //NavigationMenu.Navigate(new NavigationMenuPage());
        }
        public MainWindow(string userLogin)
        {
            InitializeComponent();
            userName_Menu.Header = userLogin;
            userName_Menu.Width = userLogin.Length + 220;
            MainFrame.Navigate(new EmployeePage());
            CloseButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            WindowedModeButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            HideButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            //NavigationMenu.Navigate(new NavigationMenuPage());
        }

        private void ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new CreatePatientPage());
        }


        private void Patients_Menu_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Patients_Menu.FontWeight = FontWeights.Bold;
            Patients_Menu.IsExpanded = true;
        }

        private void Patients_Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            Patients_Menu.FontWeight = FontWeights.Regular;
            Patients_Menu.IsExpanded = false;
        }

        private void PatientsList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PatientPage());
        }

        private void CreatePatient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreatePatientPage());
        }

        #region Managers_Buttons

        // кнопка "СКРЫТЬ"
        private void HideButtonPicture_Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            HideButtonPicture_Grid.Visibility = Visibility.Collapsed;
            HideButtonPicture_Grid_Move.Visibility = Visibility.Visible;
        }
        private void HideButtonPicture_Grid_Move_MouseLeave(object sender, MouseEventArgs e)
        {
            HideButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            HideButtonPicture_Grid.Visibility = Visibility.Visible;
        }
        private void HideButtonPicture_Grid_Move_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // кнопка "ОКНО"
        private void WindowedModeButtonPicture_Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            WindowedModeButtonPicture_Grid.Visibility = Visibility.Collapsed;
            WindowedModeButtonPicture_Grid_Move.Visibility = Visibility.Visible;
        }

        private void WindowedModeButtonPicture_Grid_Move_MouseLeave(object sender, MouseEventArgs e)
        {
            WindowedModeButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            WindowedModeButtonPicture_Grid.Visibility = Visibility.Visible;
        }

        private void WindowedModeButtonPicture_Grid_Move_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            this.Height = 600;
            this.Width = 1300;
        }

        // кнопка "ЗАКРЫТЬ"
        private void CloseButtonPicture_Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            CloseButtonPicture_Grid.Visibility = Visibility.Collapsed;
            CloseButtonPicture_Grid_Move.Visibility = Visibility.Visible;
        }

        private void CloseButtonPicture_Grid_Move_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            CloseButtonPicture_Grid.Visibility = Visibility.Visible;
        }

        private void CloseButtonPicture_Grid_Move_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        #endregion


        #region Employees_Menu
        private void Employees_Menu_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Employees_Menu.FontWeight = FontWeights.Bold;
            Employees_Menu.IsExpanded = true;
        }

        private void Employees_Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            Employees_Menu.FontWeight = FontWeights.Regular;
            Employees_Menu.IsExpanded = false;
        }

        #endregion

        private void EmployeesList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeePage());
        }

        private void CreateEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateEmployeePage());
        }

        private void ProceduresList_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProceduresPage());
        }
        private void CreateProcedure_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateProcedurePage());
        }

        private void Procedures_Menu_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Procedures_Menu.FontWeight = FontWeights.Bold;
            Procedures_Menu.IsExpanded = true;
        }

        private void Procedures_Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            Procedures_Menu.FontWeight = FontWeights.Regular;
            Procedures_Menu.IsExpanded = false;
        }

    }
}
