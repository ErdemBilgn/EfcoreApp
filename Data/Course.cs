using System.ComponentModel.DataAnnotations;
using EfcoreApp.Models;

namespace EfcoreApp.Data
{
    public class Course
    {
        public int CourseId { get; set; }

        [Display(Name = "Başlık")]
        public string? Title { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public ICollection<CourseRecord> CourseRecords { get; set; } = new List<CourseRecord>();

        public static implicit operator Course?(CourseDTO? v)
        {
            throw new NotImplementedException();
        }
    }
}