using System.ComponentModel.DataAnnotations;

namespace EfcoreApp.Data
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Öğretmen Id")]

        public int TeacherId { get; set; }

        [Display(Name = "Öğretmen Adı")]
        public string? TeacherName { get; set; }

        [Display(Name = "Öğretmen Soyadı")]
        public string? TeacherSurname { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Başlama Tarihi")]
        public DateTime StartDate { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}