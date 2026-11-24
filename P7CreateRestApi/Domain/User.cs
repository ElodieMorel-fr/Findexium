using Microsoft.AspNetCore.Identity;

namespace P7CreateRestApi.Domain
{
    public class User : IdentityUser<int>
    {          
        public string FullName { get; set; } = string.Empty;        

    }
}