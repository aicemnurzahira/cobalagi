namespace SimpleEmployeeApp.Helpers.Model
{
    public static class Message
    {
        public enum Type
        {
            Default,
            Success,
            Warning,
            Error,
            Info
        }
    }

    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
