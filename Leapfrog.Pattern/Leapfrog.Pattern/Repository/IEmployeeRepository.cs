using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leapfrog.Pattern.Models;

namespace Leapfrog.Pattern.Repository
{
    public interface IEmployeeRepository
    {
        void insert(Employee e);
        bool delete(int eid);
        bool deleteName(string name);
        Employee GetByName(string name);
        Employee GetByID(int eid);
        IList<Employee> GetAll();
        
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private IList<Employee> _EmployeeList = new List<Employee>();
        public void insert(Employee e)
        {
            _EmployeeList.Add(e);
        }
        public bool delete(int eid)
        {
            Employee e = GetByID(eid);
            if (e != null)
            {
                return _EmployeeList.Remove(e);
            }
            return false;
        }
        public bool deleteName(string name)
        {
            Employee e = GetByName(name);
            if (e != null)
            {
                return _EmployeeList.Remove(e);
            }
            return false;
        }
        public Employee GetByID(int eid)
        {
            foreach (Employee e in _EmployeeList)
            {
                if (e.Eid == eid)
                {
                    return e;
                }
            }
            return null;
        }
        public Employee GetByName(string name)
        {
            foreach (Employee e in _EmployeeList)
            {
                if (e.Ename == name)
                {
                    return e;
                }
            }
            return null;
        }
        public IList<Employee> GetAll()
        {
            return _EmployeeList;
        }
        
    }
}
