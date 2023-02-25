using Microsoft.AspNetCore.Identity;

namespace ProjectOnlineStore.Data
{
    public class AppUser : IdentityUser
    {
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
