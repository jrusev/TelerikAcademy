using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BullsCows.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public ApplicationUser()
        {
            this.Guesses = new HashSet<Guess>();
            this.Games = new HashSet<Game>();
            this.Notifications = new HashSet<Notification>();
            this.Wins = 0;
            this.Losses = 0;
            this.Rank = 0;
        }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Rank { get; set; }

        public virtual ICollection<Guess> Guesses { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
