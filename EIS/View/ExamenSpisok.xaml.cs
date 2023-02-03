using EIS.Model;
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

namespace EIS.View
{
    /// <summary>
    /// Логика взаимодействия для ExamenSpisok.xaml
    /// </summary>
    public partial class ExamenSpisok : Window
    {
        private SystemUser findUsers;

        public ExamenSpisok()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Model.EISEntities2 dbCon = Controller.DbConnection.GetContext();
            DGridSpisokExam.ItemsSource = dbCon.Exam.ToList();
        }

        private void btnProsmotr_Click(object sender, RoutedEventArgs e)
        {
            {

                var selectedExam = DGridSpisokExam.SelectedItem as Exam;

                if (selectedExam != null)
                {
                    View.StudentResult studentResult = new View.StudentResult(selectedExam);
                    studentResult.Show();

                }
                else
                {
                    MessageBox.Show("Вы не выбрали экзамен");
                }

            }
        }

        /*
        public ExamenSpisok(SystemUser findUsers)
        {
            InitializeComponent();
            this.findUsers = findUsers;
        }
       */
    }
}
