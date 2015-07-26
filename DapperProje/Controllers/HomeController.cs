using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DapperProje.Models;
using DapperProje.ModelViews;
using DapperProje.Repository.Dapper;

namespace DapperProje.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserRepository _userRepository = new UserRepository();
        public async Task<ActionResult> Index()
        {
            var list = await _userRepository.GetAllAsync();
            _userRepository.CommitChanges();
            var userModelView = new UserModelView()
            {
                Users = list
            };
            return View(userModelView);
        }
        [HttpPost]
        public async Task<ActionResult> AddUser(UserModelView userModelView)
        {
            //call directlly generic repository method like this
            // var result = await _userRepository.AddAsync(usr);
            //or use custom userrepository method depends on what you need
           // var result = await _userRepository.AddUserWithAddress(userModelView.User);
            var result = await _userRepository.AddAsync(userModelView.User);


            _userRepository.CommitChanges();
            if ((int)result>0)
            {
                return RedirectToAction("Index");
            }
            return null;
        }


        [HttpPost]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var result = await _userRepository.DeleteUserWithAddress(userId);
            _userRepository.CommitChanges();
            return Json(new { result = result });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}