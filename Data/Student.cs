namespace EfcoreApp.Data
{
    public class Student
    {
        // id => primary key
        public int StudentId { get; set; }

        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}