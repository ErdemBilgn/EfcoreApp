using System.ComponentModel.DataAnnotations;
using EfcoreApp.Data;

namespace EfcoreApp.Models
{
    public class CourseDTO
    {
        public int CourseId { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık Alanı Boş Bırakılamaz")]
        [StringLength(50, ErrorMessage = "Başlık 50 karakterden uzun olamaz")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Öğretmen Seçiniz")]
        public int TeacherId { get; set; }

        public ICollection<CourseRecord> CourseRecords { get; set; } = new List<CourseRecord>();


    }
}