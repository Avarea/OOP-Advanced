using System.Collections.Generic;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> documents = new List<string>()
            {
                "test 1",
                "test 2",
                "test 3",
                "test 4",
            };

            Employee employee1 = new Employee("Kuncho");
            Employee employee2 = new Employee("Ivan");
            Employee employee3 = new Employee("Genadi");
            Manager manager1 = new Manager("SurmataHari", documents);
            Manager manager2 = new Manager("SurmataHari", documents);
            Manager manager3 = new Manager("SurmataHari", documents);

            List<IPrintable> employees = new List<IPrintable>()
            {
                employee1,
                employee2,
                employee3,
                manager1,
                manager2,
                manager3
            };

            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();

        }
    }
}
