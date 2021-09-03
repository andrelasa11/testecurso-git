using System;
using System.Globalization;
using CalcIncome.Entities;
using CalcIncome.Entities.Enums;

namespace CalcIncome
{
    class Program
    {
        static void Main(string[] args)
        {


            // ***** Start ***** //


            //Variáveis temporárias//
            string nameDpt;
            string nameWorker;
            double baseSalary;
            WorkerLevel level;

            DateTime dateContract;
            double valuePerHour;
            int hours;
            //Variáveis temporárias//

            //Variáveis//
            int numContracts;
            string monthNYear;
            int month, year;
            //Variáveis//

            //_Entrada - Dados do trabalhador_//
            Console.Write("Enter department's name: ");
            nameDpt = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            nameWorker = Console.ReadLine();
            Console.Write("Level: ");
            level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: $ ");
            baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        
            //Instanciação - Dados do trabalhador//
            Department dept1 = new Department(nameDpt);
            Worker worker1 = new Worker(nameWorker, level, baseSalary, dept1);
            //Instanciação - Dados do trabalhador//
            //_Entrada - Dados do trabalhador_//

            //_Entrada - Contratos_//
            Console.WriteLine();
            Console.Write("How many contracts to this worker?: " );
            numContracts = int.Parse(Console.ReadLine());
          
            for(int i = 1; i <= numContracts; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"*** Contract #{i} ***");
                Console.Write("Date: ");
                dateContract = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                hours = int.Parse(Console.ReadLine());

                //Instanciação - Contratos//
                HourContract contract = new HourContract(dateContract, valuePerHour, hours);
                //Instanciação - Contratos//

                worker1.AddContract(contract); //Adicionando o contrato ao trabalhador//
            }
            //_Entrada - Contratos_//

            //_Entrada - Cálculo de ganhos_//
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            monthNYear = Console.ReadLine();
            month = int.Parse(monthNYear.Substring(0, 2));
            year = int.Parse(monthNYear.Substring(3, 4));
            //_Entrada - Cálculo de ganhos_//

            //_Saída - Cálculo de ganhos_//
            Console.WriteLine();
            Console.WriteLine("Name: " + worker1.Name);
            Console.WriteLine("Departament: " + worker1.Department.Name);
            Console.WriteLine($"Income for {monthNYear}: ${worker1.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}.");
            //_Saída - Cálculo de ganhos_//


            // ***** The End ***** //


        }
    }
}
