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

namespace VirtualOffice
{
    /// <summary>
    /// Interaction logic for EmployeeDetailWindow.xaml
    /// </summary>
    public partial class EmployeeDetailWindow : Window
    {
        Employee employee;
        public EmployeeDetailWindow(Employee em)
        {
            InitializeComponent();
            lblEmployeeName.Content = $"    {em.FullName}";
            lblAge.Content += $"    {em.Age.ToString()}";
            lblDepartment.Content += $"      {em.Department}";
            lblSalary.Content += $"    {em.Salary.ToString()}";
            lblBiography.Content += $"     {em.ShowBio()}";

            lblBirthday.Content += $"{em.DateOfBirth}";
            
        }

        

        
    }
}
