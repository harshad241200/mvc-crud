using MVCWebApplication.Models;
using MVCWebApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            UserService service = new UserService();
            List<Users> userlist =  service.getAllUsers();

            return View(userlist);
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

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult AddUser(Users user)
        {

            UserService service = new UserService();
             int status =    service.Insertuser(user);

            if (status > 0)
            {
              return Redirect("/Home/Index");
            }else
            {
                return Redirect("/Error");
            }
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Edit(string id) {
            UserService service = new UserService();
            List<Users> userlist = service.getAllUsersByid(id);
            return View(userlist);
        }

        public ActionResult UpdateUser(Users user)
        {

            UserService service = new UserService();
            int status = service.UpdateUser(user);

            if (status > 0)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/Error");
            }
            return null;
        }


        public ActionResult Delete(string id)
        {
            UserService service = new UserService();
            int status = service.DeleteUser(id);

            if (status > 0)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/Error");
            }
            return null;
        }

    }
}