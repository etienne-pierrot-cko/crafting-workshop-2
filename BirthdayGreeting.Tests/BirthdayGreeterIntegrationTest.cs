using System;
using System.Collections.Generic;
using BirthdayGreeting.Domain;
using BirthdayGreeting.Infrastructure;
using FluentAssertions;
using Xunit;

namespace BirthdayGreeting.Tests
{
    public class BirthdayGreeterIntegrationTest
    {
        private BirthdayGreeter _greeter;
        private SpyGreetingEmailSender _spyGreetingEmailSender;

        public BirthdayGreeterIntegrationTest()
        {
            _spyGreetingEmailSender = new SpyGreetingEmailSender();
            _greeter = new BirthdayGreeter(_spyGreetingEmailSender, new FileEmployeeRegistry());
        }

        [Fact]
        public void Given_Its_Birthday_Employee_Greeter_Should_Send_Greeting()
        {
            _greeter.GreetEmployees(new DateTime(2021, 10, 8));
            _spyGreetingEmailSender.EmailsSent.Should().Equal(new List<GreetingDto>
            {
                new("john.doe@foobar.com", "John", "Doe"),
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