using AssignmentAppDev2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentAppDev2021.Controllers
{
    public class AdminController : Controller
    {
        MockDB _Db = new MockDB();

        public AdminController()
        {
            _Db = new MockDB();
            _Db.InitDb();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View("AdminConsole");
        }

        public ActionResult AddRoom(Room newRoom) {
            newRoom.RoomId = Guid.NewGuid().ToString();
            _Db.AddRoom(newRoom);
            return RedirectToAction("Index","Home");
        }
    }
}