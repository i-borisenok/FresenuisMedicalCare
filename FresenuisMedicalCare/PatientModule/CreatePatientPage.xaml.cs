using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace FresenuisMedicalCare
{
    public partial class CreatePatientPage : Page
    {
        bool patientImage;

        public CreatePatientPage()
        {
            InitializeComponent();

            ProfilePhoto_Move.Visibility = Visibility.Collapsed;

            Years_ComboBox.ItemsSource = new List<int>(Enumerable.Range(DateTime.Now.Year - 99, 100).Reverse() );

            Months_ComboBox.ItemsSource = new List<string>{ "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        }

        #region PatientsPhoto
        private void ProfilePhoto_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            ProfilePhoto_Move.Visibility = Visibility.Visible;

            if(patientImage == true)
            {
                Label_ProfilePhoto_Move.Content = "ИЗМЕНИТЬ ФОТО";  
            }
            else
            {
                Label_ProfilePhoto_Move.Content = "ДОБАВИТЬ ФОТО";
            }
        }

        private void ProfilePhoto_Move_MouseLeave(object sender, MouseEventArgs e)
        {
            ProfilePhoto_Move.Visibility = Visibility.Collapsed;
        }

        private void ProfilePhoto_Move_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            openDialogFile();
        }

        private void AddDeleteImage_Button_Click(object sender, RoutedEventArgs e)           
        {
            if(patientImage == true)
            {   
                patientImage = false;
                AddDeleteImage_Button.Content = "Добавить фото";

                ImageBrush image = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "image/ProfilePhoto.png")));
                image.Stretch = Stretch.UniformToFill;

                ProfilePhoto.Background = image;
                
            }
            else
            {
                openDialogFile();
            }

        }
        private void openDialogFile()
        {
            OpenFileDialog dialogFile = new OpenFileDialog();
            dialogFile.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            dialogFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (dialogFile.ShowDialog() == true) //  пользователь выбрал файл
            {
                ImageBrush img = new ImageBrush(new BitmapImage(new Uri(dialogFile.FileName)));
                img.Stretch = Stretch.UniformToFill;

                ProfilePhoto.Background = img;

                patientImage = true;
                AddDeleteImage_Button.Content = "Удалить фото";

            }
        }

        #endregion

        private void Days_ComboBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            int month; 

            switch (Months_ComboBox.Text)
            {
                case "Январь":
                {
                    month = 1;
                    break;
                }
                case "Февраль":
                {
                    month = 2;
                    break;
                }
                case "Март":
                {
                    month = 3;
                        break;
                }
                case "Апрель":
                {
                    month = 4;
                    break;
                }
                case "Май":
                {
                    month = 5;
                    break;
                }
                case "Июнь":
                {
                    month = 6;
                    break;
                }
                case "Июль":
                {
                    month = 7;
                    break;
                }
                case "Август":
                {
                    month = 8;
                    break;
                }
                case "Сентябрь":
                {
                    month = 9;
                    break;
                }
                case "Октябрь":
                {
                    month = 10;
                    break;
                }
                case "Ноябрь":
                {
                    month = 11;
                    break;
                }
                case "Декабрь":
                {
                    month = 12;
                    break;
                }
                default:
                {
                    month = 1;
                    break;
                }
            }

            Days_ComboBox.ItemsSource = new List<int>(Enumerable.Range(1, DateTime.DaysInMonth(Convert.ToInt32(Years_ComboBox.Text), month)));

        }

        private void Months_ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (Months_ComboBox.Text != String.Empty)
            {
                Days_ComboBox.IsEnabled = true; // включаем дни
            }
        }

        private void Years_ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (Years_ComboBox.Text != String.Empty)
            {
                Months_ComboBox.IsEnabled = true; // включаем месяцы
            }
        }
    }
}

