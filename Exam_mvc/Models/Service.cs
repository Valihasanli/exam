using Exam_mvc.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_mvc.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }=null!;
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? Photofile { get; set; }
    }
}
