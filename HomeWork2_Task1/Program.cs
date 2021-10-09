using System;

namespace HomeWork2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Organization organization = new Organization (new Worker[4] 
            { 
                new HourlyPaymentWorker("Леша", 34, 150),
                new HourlyPaymentWorker("Петя", 23, 650),
                new FixedPaymentWorker("Саша", 45, 54000),
                new FixedPaymentWorker("Вася", 24, 16000) 
            });

            organization.Print();

            Console.WriteLine("\nСортируем по зарплате:");
            Array.Sort(organization.Workers);
            organization.Print();

            //Console.WriteLine("\nСортируем по возрасту:");
            //Array.Sort(organization.Workers, delegate (Worker obj1, Worker obj2) { return obj1.Age.CompareTo(obj2.Age); });
            //organization.Print(); //полный вариант

            Console.WriteLine("\nСортируем по возрасту:");
            Array.Sort(organization.Workers, (obj1, obj2) => obj1.Age.CompareTo(obj2.Age)); //сокращенная лямбда
            organization.Print();

            Console.WriteLine("\nСортируем по имени:");
            Array.Sort(organization.Workers, (obj1, obj2) => obj1.Name.CompareTo(obj2.Name)); 
            organization.Print();

            Console.ReadLine();
        }
    }
}
