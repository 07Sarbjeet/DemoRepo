using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataModel.Data.Entities.Common
{
    public class ApplicationUser : IdentityUser
    {

        public bool IsPasswordChanged { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryDate { get; set; }
        public bool IsLoggedIn { get; set; }

    }
}
