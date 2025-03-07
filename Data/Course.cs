using System.ComponentModel.DataAnnotations;

namespace EfcoreApp.Data
{
    public class Course
    {
        public int CourseId { get; set; }

        [Display(Name = "Başlık")]
        public string? Title { get; set; }
    }
}