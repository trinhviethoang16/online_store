using System.ComponentModel.DataAnnotations;

namespace ProjectOnlineStore.Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên")]
        [StringLength(50, ErrorMessage = "Tên danh mục không thể quá 50 kí tự")]
        public string? Name { get; set; }
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
