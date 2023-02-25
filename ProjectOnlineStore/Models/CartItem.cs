using ProjectOnlineStore.Data;

namespace ProjectOnlineStore.Models
{
    public class CartItem
    {
        public int Quantity { set; get; }
        public Product Product { set; get; }
    }
}
