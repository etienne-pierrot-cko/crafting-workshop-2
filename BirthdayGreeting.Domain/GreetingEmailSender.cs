namespace BirthdayGreeting.Domain
{
    public interface GreetingEmailSender
    {
        void Send(GreetingDto greetingDto);
    }
}