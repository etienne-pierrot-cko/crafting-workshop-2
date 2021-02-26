using System.Collections.Generic;
using BirthdayGreeting.Domain;

namespace BirthdayGreeting.Tests
{
    public class SpyGreetingEmailSender : GreetingEmailSender
    {
        public SpyGreetingEmailSender()
        {
            EmailsSent = new List<GreetingDto>();
        }

        public List<GreetingDto> EmailsSent { get; }

        public void Send(GreetingDto greetingDto)
            => EmailsSent.Add(greetingDto);
    }
}