using System;
using System.Collections.Generic;
using System.Text;

namespace Armazenamento_de_funcionários
{
    class Funcionarios
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Salario { get; set; }

        public Funcionarios(string nome, int idade, double salario)
        {
            Nome = nome;
            Idade = idade;
            Salario = salario;
        }

        public override string ToString()
        {
            return Nome + " " + Idade + " " + Salario;
        }
    }
}
