using System.Collections.Generic;

namespace BirthdayGreeting.Domain
{
    public interface EmployeeRegistry
    {
        List<Employee> GetAll();
    }
}