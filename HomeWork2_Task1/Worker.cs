using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task1
{
    abstract class Worker : IComparable<Worker>
    {
        private string name;
        private int age;
        protected float salary; //итоговая зарплата

        public string Name { get { return name; } }
        public int Age { get { return age; } }
        public float Salary { get { return salary; } }

        public Worker(string name, int age, float payment)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Worker other)
        {
            return (int)(Salary - other.Salary);
        }
    }
}
