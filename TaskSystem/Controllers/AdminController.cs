using System;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Controllers.API;
using TaskSystem.DTO.Admin;
using TaskSystem.Models;

namespace TaskSystem.Controllers
{
    public class AdminController : Controller
    {

        public AdminController()
        {
            GlobalLogin._userName = "vreddy";
        }

        public IActionResult Index()
        {
            //var userName = "vreddy";
            //var response = UserAPI.GetListAdministrator($"http://{Request.Host}", userName);
            var response = UserAPI.GetListAdministrator($"http://{Request.Host}", GlobalLogin.UserName);
           
            return View(response);
        }

        public IActionResult MainAdmin()
        {
            ViewBag.Name = GlobalLogin.UserName;
            var response = AdminAPI.GetTaskOwnerByUsername($"http://{Request.Host}", GlobalLogin.UserName);
            //if (response == null)
            // response = GetTaskList(taskOwner).OrderByDescending(s => s.Id).ToList();
            //var response1 = TaskAPI.GetTasksByUsername($"http://{Request.Host}", GlobalLogin._userName);
            //return View("~/Views/Home/TaskIndex.cshtml");
            return View(response);
        }

        [HttpDelete]
        public IActionResult DeleteAdminUser([FromBody]RemoveUserAdminRequest request)
        {
            UserAPI.DeleteUser($"http://{Request.Host}",request);            
            return Ok(request);
        }
        [HttpPost]
        public IActionResult CreateAdminUser([FromBody] string userName)
        {
            var user = "vreddy";
            var request = new AddUserAdminRequest
            {
                ActualUser = userName,
                DelegateUser = user
            };

            AdminAPI.AddTaskOwner($"http://{Request.Host}", request);
            return Ok(request);
        }
        [HttpGet]
        [Route("api/[controller]/[action]/{searchName}")]
        public IActionResult GetAllUsers(string searchName)
        {
           var result = UserAPI.GetAllUsers($"http://{Request.Host}", searchName);

            return Ok(result);
        }
    }
}