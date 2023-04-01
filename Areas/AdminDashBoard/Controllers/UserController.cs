using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;

namespace Movie_Hunter_FinalProject.Areas.AdminDashBoard.Controllers
{
    [Area("AdminDashBoard")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<SystemUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {

            return View(userManager.Users);
        }


        public async Task<IActionResult> AssignRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            ViewBag.Roles = new SelectList(roleManager.Roles, "Name", "Name");
            ViewBag.MyRoles = await userManager.GetRolesAsync(user);
            var model= new UserRoleModel() { userId = user.Id,Email=user.Email };
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> AssignRole(UserRoleModel model)
        {
            try
            {
                var data = await userManager.FindByIdAsync(model.userId);
                var result = await userManager.AddToRoleAsync(data, model.RolenName);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> RemoveRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            var data = new UserRoleModel()
            {

                userId = user.Id,
                Email = user.Email
            };

            ViewBag.Roles = await userManager.GetRolesAsync(user);

            return View(data);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveRole(UserRoleModel model)
        {
            try
            {
                var data = await userManager.FindByIdAsync(model.userId);
                var result = await userManager.RemoveFromRoleAsync(data, model.RolenName);


                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }

        }








    }
}
