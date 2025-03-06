using System.ComponentModel.DataAnnotations;

namespace EfcoreApp.Data
{
    public class CourseRecord
    {
        [Key]
        public int RecordId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime RecordDate { get; set; }
    }
}