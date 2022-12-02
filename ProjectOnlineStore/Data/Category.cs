namespace ProjectOnlineStore.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Alias { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
