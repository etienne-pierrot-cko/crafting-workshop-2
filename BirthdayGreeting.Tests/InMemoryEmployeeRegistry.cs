using System.Collections.Generic;
using System.Linq;
using BirthdayGreeting.Domain;

namespace BirthdayGreeting.Tests
{
    public class InMemoryEmployeeRegistry : EmployeeRegistry
    {
        private readonly Employee[] _employees;

        public InMemoryEmployeeRegistry(params Employee[] employees)
        {
            _employees = employees;
        }

        public List<Employee> GetAll()
            => _employees.ToList();
    }
}