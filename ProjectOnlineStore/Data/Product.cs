namespace ProjectOnlineStore.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortDesc { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public Category? Category { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public string? Image { get; set; }
        public string? ImageLeft { get; set; }
        public string? ImageRight { get; set; }
        public string? HomePageImage { get; set; }
		public string? AdsImage { get; set; }
        public string? Video { get; set; }
        public int? Star { get; set; }
		public double? Rating { get; set; }
		public DateTime? DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool? BestSellers { get; set; }
        public string? HomeFlag { get; set; }
        public string? Title { get; set; }
        public string? Alias { get; set; }
        public int? Remains { get; set; }
        public bool? Sales { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
