namespace Andreys.Models
{
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
