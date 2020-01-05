using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models.Auth
{
    public class CustomUserRole : IdentityUserRole<int>
    {
        //prop
        public virtual CustomRole Role { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}