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
            AtualizarTabela();
        }
        private void AdicionarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionarios funcionario = new Funcionarios(NomeDoFuncionario.Text, int.Parse(IdadeDoFuncionario.Text), double.Parse(SalarioDoFuncionario.Text));
            System.IO.File.AppendAllText(path, funcionario.ToString() + Environment.NewLine);
            NomeDoFuncionario.Text = "";
            IdadeDoFuncionario.Text = "";
            SalarioDoFuncionario.Text = "";
            lines = System.IO.File.ReadAllLines(path);
            AtualizarTabela();
        }

        private void RemoverFuncionario_Click(object sender, RoutedEventArgs e)
        {
            int indexToRemove = int.Parse(IdFuncionario.Text);
            lines = lines.Where((source, index) => index != indexToRemove).ToArray();
            System.IO.File.WriteAllText(path, String.Empty);
            for (int i = 0; i < lines.Length; i++)
            {
                System.IO.File.AppendAllText(path, lines[i] + Environment.NewLine);
            }
            lines = System.IO.File.ReadAllLines(path);
            IdFuncionario.Text = "";
            AtualizarTabela();
        }
        public object AtualizarTabela()
        {
            lb_funcionarios.Items.Clear();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] func = lines[i].Split(' ');
                lb_funcionarios.Items.Add("Nome: " + func[0] + Environment.NewLine + "Idade: " + func[1] + Environment.NewLine + "Salario: " + func[2] + Environment.NewLine + "ID: " + i);
                lb_funcionarios.Items.Add("");
            }
            return null;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}