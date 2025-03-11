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

        [Display(Name = "Öğretmen Adı Soyadı")]
        public string TeacherFullName
        {
            get
            {
                return this.TeacherName + " " + this.TeacherSurname;
            }
        }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Başlama Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}