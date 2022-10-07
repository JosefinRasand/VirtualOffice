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

namespace VirtualOffice
{
    
    public partial class MainWindow : Window
    {
        private string department;
        public MainWindow()
        {
            InitializeComponent();
            
            cbxDepartment.ItemsSource = Enum.GetValues(typeof(Departments));
            btnRemove.IsEnabled = false;
            btnShowDetails.IsEnabled = false;
            cbxMonth.ItemsSource = Enum.GetValues(typeof(Months));

            for (int i = 2022; i > 1920; i--)
            {
                cbxYear.Items.Add(i);
            }

            for (int i = 1; i < 32; i++)
            {
                cbxDay.Items.Add(i);
            }
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
            CreateEmployee();

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            lvEmployees.Items.Remove(lvEmployees.SelectedItem);
        }

        private void btnShowDetails_Click(object sender, RoutedEventArgs e)
        {
            //var selected = lvEmployees.SelectedItem as ListViewItem;
            //Employee selectedEmployee = selected.Tag as Employee;



            //ShowDetailsWindow showDetails = new(selectedEmployee);
            //showDetails.Show();
            var selected = lvEmployees.SelectedItem as ListViewItem;
            Employee selectedEmployee = selected.Tag as Employee;
            
            
            
            EmployeeDetailWindow employeeDetailWindow = new EmployeeDetailWindow(selectedEmployee);
            employeeDetailWindow.Show();
        }

        private int ConvertIntFromString(string input)
        {
            int result = Convert.ToInt32(input);
            return result;
        }

        private Decimal ConvertDecimalFromString(string input)
        {
            decimal result = Convert.ToDecimal(input);
            return result;
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            btnShowDetails.IsEnabled = true;
        }

        private void CreateEmployee()
        {
            string firstName = tbxFirstName.Text;
            string lastName = tbxLastName.Text;
            string stringAge = tbxAge.Text;
            string stringSalary = tbxSalary.Text;
            string bio = tbxBiography.Text;
            int year = ConvertIntFromString(cbxYear.Text);
            int month = cbxMonth.SelectedIndex +1;
            int day = ConvertIntFromString(cbxDay.Text);
            int daysUntilBirthday = CalculateBirthDay(year, month, day);

            if (cbxDepartment.SelectedItem != null)
            {
                department = cbxDepartment.SelectedItem.ToString();
            }
            else
            {
                department = "";
            }


            if (firstName == "" || lastName == "" || stringAge == "" || stringSalary == "" || department == "")
            {
                MessageBox.Show("Please fill out the form correctly!", "Warning!");

            }
            else
            {
                int age = ConvertIntFromString(stringAge);
                decimal salary = ConvertDecimalFromString(stringSalary);
                
                
                ListViewItem item = new();

                Employee newEmployee = new(firstName, lastName, age, salary, department,daysUntilBirthday);
                newEmployee.Bio = bio;
                item.Tag = newEmployee;
                item.Content = newEmployee.ShowEmployee();


                lvEmployees.Items.Add(item);
                ResetUI();
            }
        }

        private void ResetUI()
        {
            tbxFirstName.Clear();
            tbxLastName.Clear();
            tbxAge.Clear();
            tbxSalary.Clear();
            tbxBiography.Clear();
        }
        public int CalculateBirthDay(int year, int month, int day)
        {
            
            DateTime birthday = new DateTime(year, month, day);
            DateTime today = DateTime.Today;
            DateTime next = birthday.AddYears(today.Year - birthday.Year);

            if (next < today)
                next = next.AddYears(1);

            int numDays = (next - today).Days;
            return numDays;
        }
    }
}
