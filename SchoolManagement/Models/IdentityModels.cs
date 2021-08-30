using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //New Field Added
        public DateTime BirthDate  { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
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
    }
}


/*
 **************** HOW To Do Migreation after Adding New Fields (BirthDate)********************
 *          
 *          open Packge Manager Console from nuget package manager
 *          run Commands -  
 *             1. enable-migrations       (For Firt time)
 *             2. enable-migrations -ContextTypeName SchoolManagement.Models.ApplicationDbContext
 *                      (For Specific Database)
 *                      
 *             3. Add-Migration "Added BirthDate"
 *             4. Update-Database
 *             
 *             **** For Second Time Onwards
 *                
 *                 1. Add-Migration "Added BirthDate"
 *                 2. Update-Database
 *          
 *  After Above Step completed Update View    
 */            