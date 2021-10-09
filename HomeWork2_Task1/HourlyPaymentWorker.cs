using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task1
{
    class HourlyPaymentWorker : Worker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="payment">оплата * 20,8 * 8 = зарплата</param>
        public HourlyPaymentWorker(string name, int age, float payment) : base (name, age, payment)
        {
            this.salary = (float)(payment * 20.8 * 8);
        }
    }
}
