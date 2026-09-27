using System.ComponentModel.DataAnnotations;

namespace QLy_Sach1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Tên sách")]
        [Required(ErrorMessage = "Không được để trống tên sách")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Giá sách")]
        [Required(ErrorMessage = "Không được để trống giá sách")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }
    }
}