using System;

namespace BirthdayGreeting.Domain
{
    public record Employee(string Firstname, string Lastname, DateTime DateOfBirth, string Email)
    {
         public bool IsBirthday(DateTime now)
            => DateOfBirth.Month == now.Month && DateOfBirth.Day == now.Day;
    }
}