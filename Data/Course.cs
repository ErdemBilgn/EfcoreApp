using System.ComponentModel.DataAnnotations;

namespace EfcoreApp.Data
{
    public class Course
    {
        public int CourseId { get; set; }

        [Display(Name = "Başlık")]
        public string? Title { get; set; }

        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public ICollection<CourseRecord> CourseRecords { get; set; } = new List<CourseRecord>();
    }
}