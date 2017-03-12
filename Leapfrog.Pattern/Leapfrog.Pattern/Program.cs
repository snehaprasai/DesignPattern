using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.Pattern.Models;
using Leapfrog.Pattern.Repository;
using Leapfrog.Pattern.Controller;

namespace Leapfrog.Pattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEmployeeRepository _EmployeeRepository = new EmployeeRepository();
            EmployeeController _EmployeeController = new EmployeeController(_EmployeeRepository);
            while (true)
            {
                _EmployeeController.Menu();
                _EmployeeController.Process(Convert.ToInt32(Console.ReadLine()));

                
            }
        }
    }
}
