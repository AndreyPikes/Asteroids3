using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task1
{
    class FixedPaymentWorker : Worker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="payment">оплата равна зарплате</param>
        public FixedPaymentWorker(string name, int age, float payment) : base(name, age, payment)
        {
            this.salary = payment;
        }
    }
}
