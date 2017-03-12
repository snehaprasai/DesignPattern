using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.Pattern.Models;
using Leapfrog.Pattern.Repository;

namespace Leapfrog.Pattern.Controller
{
    public class EmployeeController
    {
        public IEmployeeRepository _EmployeeRepository;
        
       
        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            this._EmployeeRepository = EmployeeRepository;
        }
        public void Menu()
        {
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Search");
            Console.WriteLine("3. Show All");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter an option: ");
        }
        public void Insert()
        {
            Employee _employee = new Employee();
            Console.WriteLine("Enter employee id:");
            _employee.Eid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            _employee.Ename = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            _employee.Address = Console.ReadLine();
            Console.WriteLine("Enter Mobile Number:");
            _employee.Mnumber = Console.ReadLine();
            Console.WriteLine("Enter Designation:");
            _employee.Designation = Console.ReadLine();
            Console.WriteLine("Enter Salary:");
            _employee.Salary = Convert.ToDecimal(Console.ReadLine());
            _EmployeeRepository.insert(_employee);
        }
        public void ShowAll()
        {
            Console.WriteLine("Printing Records");
            Console.WriteLine("=======================================");
            foreach (Employee e in _EmployeeRepository.GetAll())
            {
                Console.WriteLine("Eid:{0}\r\nName:{1}\r\nAddress:{2}\r\nMobile Number:{3}\r\nDesignation:{4}\r\nSalary:{5}", e.Eid, e.Ename, e.Address, e.Mnumber, e.Designation, e.Salary);
            }
            Console.WriteLine("=======================================");
        }
        public void Delete()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Delete by ID");
            Console.WriteLine("2. Delete by name");
            Console.WriteLine("Enter an option:");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter id:");
                    int eid = Convert.ToInt32(Console.ReadLine());
                    _EmployeeRepository.delete(eid);

                    break;
                case 2:
                    Console.WriteLine("Enter employee name:");
                    string name = Console.ReadLine();
                    _EmployeeRepository.deleteName(name);
                    break;
            }
            
            
        }
        public void Search()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("1.Search by ID");
            Console.WriteLine("2.Search by Name");
            Console.WriteLine("Enter an option");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter ID:");
                    int Eid = Convert.ToInt32(Console.ReadLine());
                    //_EmployeeRepository.GetByID(Eid);
                    foreach (Employee e in _EmployeeRepository.GetAll()) {
                    if (e.Eid==Eid){
                        Console.WriteLine("Eid:{0}\r\nName:{1}\r\nAddress:{2}\r\nMobile Number:{3}\r\nDesignation:{4}\r\nSalary:{5}", e.Eid, e.Ename, e.Address, e.Mnumber, e.Designation, e.Salary);
                    }
                    
                    }
                    
                    break;
                case 2:
                    Console.WriteLine("Enter Employee Name:");
                    string name = Console.ReadLine();
                    foreach (Employee e in _EmployeeRepository.GetAll())
                    {
                        if (e.Ename == name)
                        {
                            Console.WriteLine("Eid:{0}\r\nName:{1}\r\nAddress:{2}\r\nMobile Number:{3}\r\nDesignation:{4}\r\nSalary:{5}", e.Eid, e.Ename, e.Address, e.Mnumber, e.Designation, e.Salary);
                        }
                        
                    }
                    break;
            }


        }
        public void Process(int choice)
        {
            switch (choice)
            {
                case 1:
                    Insert();

                    break;
                case 2:
                    Search();
                    break;
                case 3:
                    ShowAll();
                    break;
                case 4:
                    Delete();
                    break;
                case 5:
                    Console.WriteLine("Do you really want to exit [Y/N]?");
                    if (Console.ReadLine().ToUpper().Equals("Y")) {
                    Environment.Exit(0);
                    }
                    
                    break;
            }
        }
    }
}
