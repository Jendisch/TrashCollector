using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Address Line One")]
        [Required]
        public string Line1Address { get; set; }

        [Display(Name = "Address Line Two (optional)")]
        public string Line2Address { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [Required]
        public string ZipCode { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public string StartDate { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        [ForeignKey("Schedule")]
        public int ScheduleId;
        public virtual Schedule schedule { get; set; }

        [Display(Name = "Address")]
        public string CombineAddress
        {
            get
            {
                string displayLine1Address = string.IsNullOrWhiteSpace(this.Line1Address) ? "" : this.Line1Address;
                string displayLine2Address = string.IsNullOrWhiteSpace(this.Line2Address) ? "" : this.Line2Address;
                string displayCity = string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
                string displayState = string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
                string displayZipCode = string.IsNullOrWhiteSpace(this.ZipCode) ? "" : this.ZipCode;

                return string.Format($"{displayLine1Address} {displayLine2Address} {displayCity} {displayState} {displayZipCode}");

            }
        }



    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Payment> Payment { get; set; }


    }
}