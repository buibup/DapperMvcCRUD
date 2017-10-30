using DapperMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DapperMvc.Enums;

namespace DapperMvc.Controllers
{
    public class FriendController : Controller
    {
        public FriendController()
        {
            // set initialize connection
            GlobalConfig.InitializeConnections(DataBaseType.MySql);
        }
        // GET: Friend
        public ActionResult Index()
        {
            var friends = GlobalConfig.Connection.GetFriends();
            return View(friends);
        }

        // GET: Friend/Details/5
        public ActionResult Details(int id)
        {
            var friend = GlobalConfig.Connection.GetFriend(id);

            return View(friend);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public ActionResult Create(Friend friend)
        {
            try
            {
                // TODO: Add insert logic here
                GlobalConfig.Connection.CreateFriend(friend);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {
            var friend = GlobalConfig.Connection.EditFriend(id);
            return View(friend);
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public ActionResult Edit(Friend friend)
        {
            try
            {
                // TODO: Add update logic here
                GlobalConfig.Connection.EditFriend(friend);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int id)
        {
            var model = GlobalConfig.Connection.DeleteFriend(id);
            return View(model);
        }

        // POST: Friend/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                GlobalConfig.Connection.DeleteFriend(id, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
