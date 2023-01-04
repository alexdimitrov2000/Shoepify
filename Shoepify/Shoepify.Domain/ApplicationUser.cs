using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoepify.Domain
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string? LastName { get; set; }
    }
}
