using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Olm.Model;
using Olm.Model.Entities;

namespace Olm.Web.Configurations.Initializes
{
    public class DbInitialize
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public DbInitialize(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Administrator",
                    NormalizedName = "Administrator",
                    Description = "Administrator"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Description = "User"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin@lionsstory.vn",
                    FullName = "Super Admin",
                    Email = "admin@lionsstory.vn",
                    IsActive = true
                }, "Lionsstory@123");
                var user = await _userManager.FindByEmailAsync("admin@lionsstory.vn");
                await _userManager.AddToRoleAsync(user, "Administrator");
            }
        }
    }
}