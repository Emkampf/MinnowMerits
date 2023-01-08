using Microsoft.Owin;
using MMRB.Data;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinnowMeritsRedBadge.Startup))]
namespace MinnowMeritsRedBadge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


          /*  createRolesandUsers();*/
        }
       /* private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // Creating First Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            //Create Admin Super User who will maintain website
            var user = new ApplicationUser();
            user.UserName = "Emily";
            user.Email = "emilykampf@gmail.com";

            string userPWD = "AQl";

            var chkUser = UserManager.Create(user, userPWD);

            //Add Default User to Role Admin
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "Admin");
            }

            //creating manager roll
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            } 
        }*/

    }
}
