using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectOnlineStore.Data
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không thể quá 100 kí tự.")]
        [Display(Name = "Tên")]
        public string? Name { get; set; }
        [Display(Name = "Chi tiết")]
        public string? Detail { get; set; }
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
        [Display(Name = "Loại danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn loại danh mục")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        [Range(1, 1000000)]
        public double Price { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Vui lòng nhập hình ảnh")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số ngôi sao")]
        [Range(1, 5)]
        [Display(Name = "Ngôi sao")]
        public int Star { get; set; }
        [Display(Name = "Bán chạy")]
        public bool? BestSellers { get; set; }
        [Display(Name = "Giảm giá")]
        [Range(1, 100)]
        public double Sales { get; set; }
        [Display(Name = "Trang chủ")]
        public bool? Homepage { get; set; }
        [Display(Name = "Số lượng")]
        [Range(0, 1000000)]
        public int Remains { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
