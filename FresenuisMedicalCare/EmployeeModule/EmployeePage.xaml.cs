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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FresenuisMedicalCare
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            //TEST();
        }

        public class TableRowEmployee
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Birthday { get; set; }
            public string Position { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
        }

    }
}
