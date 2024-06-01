
using Microsoft.AspNetCore.Identity;
using ZuZin.Roles;

namespace ZuZin.Data
{
    public class DataSeed
    {
        public static async Task Createdefaultvalue(IServiceProvider service)
        {
            var manageUser = service.GetService<UserManager<IdentityUser>>();
            var manageRole = service.GetService<RoleManager<IdentityRole>>();

            // them mot vai tro vao co so du lieu
            await manageRole.CreateAsync(new IdentityRole(Role.Admin.ToString()));
            await manageRole.CreateAsync(new IdentityRole(Role.User.ToString()));

            // tạo thông tin mac dinh cho Admin
            var Admin = new IdentityUser
            {
                UserName = "Admin2003@gmail.com",
                Email = "Admin2003@gmail.com",
                EmailConfirmed = true,
            };
            var UserInDB = await manageUser.FindByEmailAsync(Admin.Email);
            //Neu tk Admin khong ton tai 
            if (UserInDB is null)
            {
                //Tạo tài khoan admin
                await manageUser.CreateAsync(Admin, "Thuyen@2003");
                await manageUser.AddToRoleAsync(Admin, Role.Admin.ToString());
            }
        }
    }
}