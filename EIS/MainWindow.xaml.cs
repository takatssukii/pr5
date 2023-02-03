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
using EIS.Model;
namespace EIS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnAuthorization_Click(object sender, RoutedEventArgs e)
        {

            
        }


        private void btnAuthorization_Click_1(object sender, RoutedEventArgs e)
        {
            Model.EISEntities2 dbCon = Controller.DbConnection.GetContext();

            if (!string.IsNullOrEmpty(txtBoxLogin.Text) && !string.IsNullOrEmpty(passBoxPassword.Password))
            {
                string p = HashPasswords.Hash.GetHash(passBoxPassword.Password);
                var findUsers = dbCon.SystemUser.Where(x => x.Login == txtBoxLogin.Text && x.Password == p).FirstOrDefault();
                if (findUsers != null)
                {
                    View.ExamenSpisok examenSpisok = new View.ExamenSpisok();
                    examenSpisok.Show();
                    this.Hide();
                }
            }
        }
    }
}

