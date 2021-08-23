using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MissingPersons.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MissingPersons.Startup))]
namespace MissingPersons
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string adminRole = "Admin";
            string adminEmail = "admin@admin.pl";
            string adminPwd = "admin123";
 
            if (!roleManager.RoleExists(adminRole))
            {
                var role = new IdentityRole();
                role.Name = adminRole;
                roleManager.Create(role);            

                var user = new ApplicationUser();
                user.UserName = adminEmail;
                user.Email = adminEmail;

                var newUserResult = userManager.Create(user, adminPwd);
   
                if (newUserResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, adminRole);
                }
            }
        }
    }
}
