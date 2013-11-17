using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HighSchoolMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Bll.Course bllCourse = new Bll.Course();
            List<Model.Course> courseList = bllCourse.FindLatest(8);

            ViewBag.CourseList = courseList;

            return View();
        }

    }
}
