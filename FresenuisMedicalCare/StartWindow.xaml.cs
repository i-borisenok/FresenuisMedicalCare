using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();

            FrameRegistrationPage.Navigate(new AuthorizationPage());

            CloseButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            HideButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            //////////////////////////////////////////////////////////////////////////////////////////
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //Application.Current.Windows[0].Close();
            ////////////////////////////////////////////////////////////////////////////////////////// 

        }

        private void HideButtonPicture_Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            HideButtonPicture_Grid.Visibility = Visibility.Collapsed;
            HideButtonPicture_Grid_Move.Visibility = Visibility.Visible;
        }

        private void CloseButtonPicture_Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            CloseButtonPicture_Grid.Visibility = Visibility.Collapsed;
            CloseButtonPicture_Grid_Move.Visibility = Visibility.Visible;
        }

        private void HideButtonPicture_Grid_Move_MouseLeave(object sender, MouseEventArgs e)
        {
            HideButtonPicture_Grid_Move.Visibility = Visibility.Collapsed;
            HideButtonPicture_Grid.Visibility = Visibility.Visible;
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

        private void HideButtonPicture_Grid_Move_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) // перетаскивание окна при нажатии мыши
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
