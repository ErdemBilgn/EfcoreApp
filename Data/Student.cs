using System.ComponentModel.DataAnnotations;

namespace EfcoreApp.Data
{
    public class Student
    {
        // id => primary key
        [Display(Name = "Öğrenci Id")]
        public int StudentId { get; set; }

        [Display(Name = "Öğrenci Adı")]
        public string? StudentName { get; set; }

        [Display(Name = "Öğrenci Soyadı")]
        public string? StudentSurname { get; set; }

        [Display(Name = "Öğrenci Adı Soyadı")]
        public string StudentFullName
        {
            get
            {
                return this.StudentName + " " + this.StudentSurname;
            }
        }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }
    }
}