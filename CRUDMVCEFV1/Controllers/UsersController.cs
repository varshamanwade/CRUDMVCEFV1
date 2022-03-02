using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVCEFV1.Data.Data.Models;
using CRUDMVCEFV1.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVCEFV1.Controllers
{
    public class UsersController : Controller
    {
        public readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(_userService.Get());
        }
        public ViewResult Create()
        {
            var model = new User();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.CreateDate = DateTime.Now;
                    if (_userService.Save(user))
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Can Not Create User");
                    }
                }
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(user);
        }

        // To fill data in the form 
        // to enable easy editing
        public IActionResult Edit(int id)
        {

            var data = _userService.GetUserByID(id);
            return View(data);
        }

        // To specify that this will be 
        // invoked when post method is called
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User model)
        {
            if (id > 0)
            {
                _userService.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

    }
}