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
    /// Логика взаимодействия для StudentRes.xaml
    /// </summary>
public partial class StudentRes : Window
    {
        public Exam exam { get; set; }
        private Model.Aspect _selectedAspect { get; set; }
        private Model.StudentResult _studentResult { get; set; }
        private Model.ProModule _proModule { get; set; }
        private string _countPoints { get; set; }


        //private static int idStudent;



        public StudentRes(Exam exam)
        {

            InitializeComponent();
            this.exam = exam;
            txtNameExam.Content = exam.ProModule.Title;
            LoadStudents();

        }



        public void LoadStudents()
        {
            var students = Controller.DbConnection.GetContext().Student.Where(x => x.IdGroup == exam.IdGroup).ToList();
            StudentsListBox.ItemsSource = students;

        }


        private void StudentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = Controller.DbConnection.GetContext();
            var selectedStudent = StudentsListBox.SelectedItem as Model.Student;
            if (selectedStudent != null)
            {
                var studentResult = db.StudentResult.Where(x => x.IdStudent == selectedStudent.IdStudent).ToList();
                var aspects = db.Aspect.ToList();
                var asp = db.Aspect.Where(x => x.SubCriteria.Criteria.IdProModule == exam.IdProModule).ToList();
                
                foreach (var aspect in asp)
                {
                    var searchResult = studentResult.Where(x => x.IdAspect == aspect.IdAspect).FirstOrDefault();
                    if (searchResult == null)
                    {
                        var lastId = db.StudentResult.ToList();
                        var newResult = new Model.StudentResult()
                        {
                            IdStudentResult = lastId[lastId.Count - 1].IdStudentResult + 1,
                            IdAspect = aspect.IdAspect,
                            IdStudent = selectedStudent.IdStudent,
                            NumberOfPointsForAspects = 0.ToString()
                        };
                        db.StudentResult.Add(newResult);
                        db.SaveChanges();
                    }
                }
                var studentResult2 = db.StudentResult.Where(x => x.IdStudent == selectedStudent.IdStudent).ToList();
                DGridOcenki.ItemsSource = asp;

            }


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

        private void btnBack_Copy_Click(object sender, RoutedEventArgs e)
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








        /* row = DGridOcenki.Items.Count;
        for (int i =0; i<row; i++)
        {
            Model.StudentResult studRes = new Model.StudentResult();
            //получить значение ячеек idAspect и Количество баллов занести в соответствующие им поля объекта studRes
         decimal i = 0;
        for (Int32 j = 0; j < DGridOcenki.Items.Count; j++)
            i += Convert.ToDecimal(DGridOcenki[0, j].Value)
            studRes.IdStudent = idStudent;
            studRes.IdAspect = 1;
            studRes.NumberOfPointsForAspects = ""2,00;
            Model.OcenivenieStudentovEntities db = Controller.DbConnection.GetContext();
            db.StudentResult.Add(studRes);
            db.SaveChanges(); 

        }
        */


        private void vivod1_Click(object sender, RoutedEventArgs e)
        {
            decimal sum = 0m;
            for (int i = 0; i < DGridOcenki.Items.Count - 1; i++)
            {
                sum += decimal.Parse((DGridOcenki.Columns[4].GetCellContent(DGridOcenki.Items[i]) as TextBlock).Text);
                vivod.Text = sum.ToString();
            }
        }
    }
}