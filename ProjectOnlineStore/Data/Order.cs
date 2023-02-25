using System.ComponentModel.DataAnnotations;

namespace ProjectOnlineStore.Data
{
    public class Order
    {
        public int Id { get; set; }
        [StringLength(450)]
        public string UserId { get; set; } = null!;
        public string? Status { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Note { get; set; }
        public double? Total { get; set; }
        public string UserName { get; set; } = null!;
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
