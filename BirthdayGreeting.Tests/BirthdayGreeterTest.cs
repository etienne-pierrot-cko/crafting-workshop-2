using System;
using System.Collections.Generic;
using BirthdayGreeting.Domain;
using Xunit;
using FluentAssertions;

namespace BirthdayGreeting.Tests
{
    public class BirthdayGreeterTest
    {
        private BirthdayGreeter _greeter;
        private SpyGreetingEmailSender _spyGreetingEmailSender;

        public BirthdayGreeterTest()
        {
            _spyGreetingEmailSender = new SpyGreetingEmailSender();
            var johnDoe = new Employee("John", "Doe", new DateTime(1982, 10, 8), "john.doe@foobar.com");
            var zlata = new Employee("Zlata", "Shtamburg", new DateTime(1982, 10, 8), "zlata.shtamburg@foobar.com");
            _greeter = new BirthdayGreeter(_spyGreetingEmailSender, new InMemoryEmployeeRegistry(johnDoe, zlata));
        }

        [Fact]
        public void Given_Its_Birthday_Employee_Greeter_Should_Send_Greeting()
        {
            _greeter.GreetEmployees(new DateTime(2021, 10, 8));
            _spyGreetingEmailSender.EmailsSent.Should().Equal(new List<GreetingDto>
            {
                new("john.doe@foobar.com", "John", "Doe"),
                new("zlata.shtamburg@foobar.com", "Zlata", "Shtamburg")
            });
        }

        [Fact]
        public void Given_Its_Not_Birthday_Employee_Greeter_Should_Not_Send_Greeting()
        {
            _greeter.GreetEmployees(new DateTime(2021, 11, 8));
            _spyGreetingEmailSender.EmailsSent.Should().HaveCount(0);
        }
    }
}