using System;
using System.Globalization;
using Exercicio._119.Entities;
using Exercicio._119.Entities.Enums;

namespace Exercicio._119 {
    class Program {
        static void Main(string[] args) {
            Console.Write("Entre com o nome do departamento: ");
            string dptoName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador:");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Nivel (Junior, MidLevel, Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salario base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(dptoName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Quantos contratos possui o trabalhador? ");
            int qtdContratos = int.Parse(Console.ReadLine());
            for(int i = 1; i <= qtdContratos; i++) {
                Console.WriteLine($"Entre com os dados do contrato #{i}:");
                Console.Write("Data (DD/MM/YYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valorHora = double.Parse(Console.ReadLine());
                Console.Write("Quatidade de horas: ");
                int horas = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valorHora, horas);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Entre com o mês e ano para calcular o ganho (MM/YYYY): ");
            string mesAno = Console.ReadLine();
            int mes = int.Parse(mesAno.Substring(0, 2));
            int ano = int.Parse(mesAno.Substring(3));

            Console.WriteLine("Nome: "+ worker.Name);
            Console.WriteLine("Departamento: "+ worker.Department.Name);
            Console.WriteLine($"Ganho liquido no periodo de {mesAno} R$: "+ worker.Income(ano,mes).ToString("f2", CultureInfo.InvariantCulture));
        }
    }
}
