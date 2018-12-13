using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPLabs2.Models;

namespace ASPLabs2.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        [Authorize]
        public ActionResult Index()
        {
            ASPLabs2Entities ORM = new ASPLabs2Entities();
            
            ViewBag.Users = ORM.Users.ToList();
            // USER and USERS NOT WORKING ?

            
            return View();

        }

        public ActionResult AddUser(User newUser)
        {
            ASPLabs2Entities ORM = new ASPLabs2Entities();
            ORM.Users.Add(newUser);
            ORM.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int ID)
        {
            ASPLabs2Entities ORM = new ASPLabs2Entities();
            User found = ORM.Users.Find(ID);
            ORM.Users.Remove(found);
            ORM.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult EditUser(int ID)
        {
            ASPLabs2Entities ORM = new ASPLabs2Entities();
            User found = ORM.Users.Find(ID);
            return View(found);
        }

        public ActionResult SaveChanges(User updatedUser)
        {
            ASPLabs2Entities ORM = new ASPLabs2Entities();
            User oldUser = ORM.Users.Find(updatedUser.UserID);

            oldUser.username = updatedUser.username;
            oldUser.password = updatedUser.password;
            oldUser.email = updatedUser.email;
            oldUser.UserID = updatedUser.UserID;

            ORM.Entry(oldUser).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("Index");

        }
    }

    
}