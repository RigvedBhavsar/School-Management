using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolManagement.Models;
using System;

[assembly: OwinStartupAttribute(typeof(SchoolManagement.Startup))]
namespace SchoolManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        public void createRolesandUsers()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Cheking if User with "Admin" exists
            if (!roleManager.RoleExists("Admin"))
            {
                //Creating Admin role if not exists
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Creating new User object
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    BirthDate = DateTime.Now
                };
                //Setting password to Admin
                var password = "password";
                //Creating user and passi g usr object
                var usr = userManager.Create(user, password);

                //Checking if Admin Gets created
                if (usr.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Cheking if User with "Teacher" exits
            if (!roleManager.RoleExists("Teacher"))
            {
                //Creating Teacher role if not exists
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);

            }

            //Cheking if User with "Supervisor" exits
            if (!roleManager.RoleExists("Supervisor"))
            {
                //Creating Teacher role if not exists
                var role = new IdentityRole();
                role.Name = "Supervisor";
                roleManager.Create(role);

            }

        }
    }
}
