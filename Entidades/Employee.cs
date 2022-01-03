namespace Armazenamento_de_funcionários
{
    class Employee
    {
        public string Name { get; }
        public int Age { get; }
        public double Salary { get; set; }

        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return Name + " " + Age + " " + Salary;
        }
    }
}
