using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DisserMVC.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int CurrentState { get; set; }
        public int PreviousState { get; set; }

        public List<Tests> UserTests { get; set; }
    }
}
