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
    public partial class CreateProcedurePage : Page
    {
        public CreateProcedurePage()
        {
            InitializeComponent();


            //TEST();
        }

        //public class TableRowPatient
        //{
        //    public string Name { get; set; }
        //    public Image Photo { get; set; }
        //    public string Phone { get; set; }
        //    public string Birthday { get; set; }
        //    public string Email { get; set; }
        //    public DateTime FirstDialysis { get; set; }
        //    public bool PeritonealDialysis { get; set; }
        //    public string Address { get; set; }
        //    public double CurrentWeight { get; set; }
        //    public double TargetWeight { get; set; }
        //}

        //private void GetPatients()
        //{
        //    MyTable.Items.Clear();
        //    try
        //    {
        //        using (DB db = new DB())
        //        {
        //            var patients = db.Patients.ToList();

        //            if ( patients != null) // есть записи
        //            {
        //                foreach (Patient patient in patients) //цикл заполняет таблицу с пациентами
        //                {
        //                    TableRowPatient row = new TableRowPatient();
        //                    row.Name = patient.Name;
        //                    row.Phone = patient.Phone;
        //                    row.Birthday = patient.Birthday.ToString("D");
        //                    row.Email = patient.Email;
        //                    row.FirstDialysis = patient.FirstDialysis;
        //                    row.PeritonealDialysis = patient.PeritonealDialysis;
        //                    row.Address = patient.Address;
        //                    row.CurrentWeight = patient.CurrentWeight;
        //                    row.TargetWeight = patient.TargetWeight;

        //                    MyTable.Items.Add(row);
        //                }
        //            }
        //            else    //  нет
        //            {
        //                MyTable.Columns.Clear();
        //                DataGridTextColumn textColumn = new DataGridTextColumn();
        //                textColumn.Header = "ЗАПИСИ НЕ НАЙДЕНЫ";
        //                textColumn.Binding = new Binding("Name");
        //                MyTable.Columns.Add(textColumn);

        //                TableRowPatient row = new TableRowPatient();
        //                row.Name = "СОТРУДНИКОВ НЕТ. СОЗДАТЬ?";
        //                MyTable.Items.Add(row);
        //            }
        //        }
        //    }
        //    catch
        //    {

        //        MyTable.Columns.Clear();
        //        DataGridTextColumn textColumn = new DataGridTextColumn();
        //        textColumn.Header = "ОШИБКА";
        //        textColumn.Binding = new Binding("Name");
        //        MyTable.Columns.Add(textColumn);

        //        TableRowPatient row = new TableRowPatient();
        //        row.Name = "ПРОИЗОШЛА ОШИБКА ЗАГРУЗКИ ДАННЫХ!";
        //        MyTable.Items.Add(row);
        //    }

        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    GetPatients();
        //}
    }
}

