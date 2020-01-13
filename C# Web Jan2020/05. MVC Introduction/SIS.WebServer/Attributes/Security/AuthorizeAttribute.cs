namespace SIS.MvcFramework.Attributes.Security
{
    using System;
    using System.Text;
    using SIS.MvcFramework.Identity;
    using System.Collections.Generic;

    public class AuthorizeAttribute : Attribute
    {


        public AuthorizeAttribute(string authority = "authorized")
        {
            this.authority = authority;
        }

        private readonly string authority;

        private bool IsLoggedIn(Principal principal)
        {
            return principal != null;
        }

        public bool IsInAuthority(Principal principal)
        {
            if (!this.IsLoggedIn(principal))
            {
                return this.authority == "anonymous";
            }


            return this.authority == "authorized" || principal.Roles.Contains(this.authority.ToLower());
        }
    }
}
