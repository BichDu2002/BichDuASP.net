﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: admin/Base
        public ActionResult Index()
        {
            return View();
        }
    }
}