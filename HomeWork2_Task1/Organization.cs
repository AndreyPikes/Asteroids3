using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task1
{
    class Organization
    {
        public Worker[] Workers { get; set; }

        public Organization(Worker[] workers)
        {
            Workers = workers;
        }


        public void Print()
        {
            foreach (var worker in Workers)
            {
                Console.WriteLine($"Имя: {worker.Name,10} | Возраст: {worker.Age,5} | Тип работника: {worker.GetType().Name, 25} | Зарплата: {worker.Salary, 5}");
            }
        }
    }
}
