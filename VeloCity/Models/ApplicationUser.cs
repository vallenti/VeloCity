using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace VeloCity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Trip> Trips { get; set; } = new Collection<Trip>();
    }
}