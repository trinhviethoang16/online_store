using Microsoft.AspNetCore.Identity;

namespace ProjectOnlineStore.Data
{
    public class AppUser : IdentityUser
    {
        public string? phone { get; set; }
        public string? address { get; set; }
        public int? age { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }

    }
}
