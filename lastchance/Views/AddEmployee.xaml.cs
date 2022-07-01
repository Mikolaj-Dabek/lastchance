using lastchance.ViewModels;
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

namespace lastchance.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel(); //Take data from EmployeeViewModel() and put into DataContext
        }

        //////////////////////////////////////////////////////////////////
        /* Bottom Menu Commands */
        private void BtnToEmployeeDetails(object sender, RoutedEventArgs e)
        {
            var newForm = new EmplyeeDetails(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }
        private void BtnToMenu(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }
        private void BtnToAddEmployee(object sender, RoutedEventArgs e)
        {
            var newForm = new AddEmployee(); //create your new form.
            newForm.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }
        //////////////////////////////////////////////////////////////////
    }
}
