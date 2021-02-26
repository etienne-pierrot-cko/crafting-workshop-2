using System;
using System.Linq;

namespace BirthdayGreeting.Domain
{
    public class BirthdayGreeter
    {
        private readonly GreetingEmailSender _greetingEmailSender;
        private readonly EmployeeRegistry _employeeRegistry;

        public BirthdayGreeter(GreetingEmailSender greetingEmailSender, EmployeeRegistry employeeRegistry)
        {
            _greetingEmailSender = greetingEmailSender;
            _employeeRegistry = employeeRegistry;
        }
        
        public void GreetEmployees(DateTime now)
            => _employeeRegistry
                .GetAll()
                .Where(e =>  e.IsBirthday(now))
                .ToList()
                .ForEach(Send);

        private void Send(Employee e)
            => _greetingEmailSender.Send(new GreetingDto(e.Email, e.Firstname, e.Lastname));
    }
}