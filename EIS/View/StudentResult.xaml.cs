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

    public partial class StudentResult : Window
    {
        public Exam exam { get; set; }
        public Aspect aspect { get; set; }
        public ProModule proModule { get; set; }
        public StudentResult studentResult { get; set; }


        public StudentResult(Exam exam)
        {
            InitializeComponent();
            this.exam = exam;
            txtNameExam.Content = exam.ProModule.Title;
            LoadStudents();
        }

        public StudentResult()
        {

        }

        public void LoadStudents()
        {
            var students = Controller.DbConnection.GetContext().Student.Where(x => x.IdGroup == exam.IdGroup).ToList();
            StudentsListBox.ItemsSource = students;
        }

        public void LoadResultStudent(Model.Aspect aspect)
        {
            var results = Controller.DbConnection.GetContext().Aspect.ToList();
            DGridOcenki.ItemsSource = results;
        }

        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var aspect = StudentsListBox.SelectedItem as Model.Aspect;
            LoadResultStudent(aspect);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void DGridOcenki_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column.DisplayIndex != 4)
            {
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = StudentsListBox.SelectedItem as Model.Student;
            var studentResult = Controller.DbConnection.GetContext().StudentResult.Where(x => x.IdStudent == selectedStudent.IdStudent).ToList();
            Controller.DbConnection.GetContext().StudentResult.Where(x => x.IdStudent == selectedStudent.IdStudent);
            for (int i = 0; i < DGridOcenki.Items.Count - 1; i++)
            {
                var aspectTextBlock = DGridOcenki.Columns[4].GetCellContent(DGridOcenki.Items[i]) as TextBlock;
                string countPoints = aspectTextBlock.Text;
                studentResult[i].NumberOfPointsForAspects = countPoints;
                Controller.DbConnection.GetContext().SaveChanges();

            }

            decimal sum = 0m;
            for (int i = 0; i < DGridOcenki.Items.Count - 1; i++)
            {
                sum += decimal.Parse((DGridOcenki.Columns[4].GetCellContent(DGridOcenki.Items[i]) as TextBlock).Text);
            }
            var db = Controller.DbConnection.GetContext();
            var vedomosti = new Model.Vedomosti()
            {

                IdStudent = selectedStudent.IdStudent,
                TheNumberOfPointsForTheExam = 1.ToString(),
            };

            db.Vedomosti.Add(vedomosti);
            db.SaveChanges();


            MessageBox.Show("Данные успешно занесены");



        }

        private void DGridOcenki_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}