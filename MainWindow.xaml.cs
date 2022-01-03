using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Armazenamento_de_funcionários
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = System.IO.Path.GetFullPath(@"C:\Users\User\source\repos\Armazenamento de funcionários\Armazenamento de funcionários\Funcionarios.txt");
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\User\source\repos\Armazenamento de funcionários\Armazenamento de funcionários\Funcionarios.txt");
        public MainWindow()
        {
            InitializeComponent();
            ListBoxUpdate();
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee(EmployeesName.Text, int.Parse(EmployeesAge.Text), double.Parse(EmployeesSalary.Text));
            System.IO.File.AppendAllText(path, employee.ToString() + Environment.NewLine);
            EmployeesName.Text = "";
            EmployeesAge.Text = "";
            EmployeesSalary.Text = "";
            lines = System.IO.File.ReadAllLines(path);
            ListBoxUpdate();
        }

        private void RemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            int indexToRemove = int.Parse(EmployeesId.Text);
            lines = lines.Where((source, index) => index != indexToRemove).ToArray();
            System.IO.File.WriteAllText(path, String.Empty);
            for (int i = 0; i < lines.Length; i++)
            {
                System.IO.File.AppendAllText(path, lines[i] + Environment.NewLine);
            }
            lines = System.IO.File.ReadAllLines(path);
            EmployeesId.Text = "";
            ListBoxUpdate();
        }
        public object ListBoxUpdate()
        {
            lb_employees.Items.Clear();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] func = lines[i].Split(' ');
                lb_employees.Items.Add("Nome: " + func[0] + Environment.NewLine + "Idade: " + func[1] + Environment.NewLine + "Salario: " + func[2] + Environment.NewLine + "ID: " + i);
                lb_employees.Items.Add("");
            }
            return null;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}