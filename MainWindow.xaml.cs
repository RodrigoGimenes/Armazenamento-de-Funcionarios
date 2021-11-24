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

namespace Armazenamento_de_funcionários
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string[] file = System.IO.File.ReadAllLines(@"C:\Users\User\source\repos\Armazenamento de funcionários\Armazenamento de funcionários\Funcionarios.txt");

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AdicionarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionarios funcionario = new Funcionarios(NomeDoFuncionario.Text,int.Parse(IdadeDoFuncionario.Text), double.Parse(SalarioDoFuncionario.Text));
            System.IO.File.AppendAllText(@"C:\Users\User\source\repos\Armazenamento de funcionários\Armazenamento de funcionários\Funcionarios.txt", funcionario.ToString() + Environment.NewLine);
            NomeDoFuncionario.Text = "";
            IdadeDoFuncionario.Text = "";
            SalarioDoFuncionario.Text = "";
        }
    }
}
