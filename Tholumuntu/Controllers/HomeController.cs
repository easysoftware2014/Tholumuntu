﻿using System;
using System.Data.Common;
using System.Web.Mvc;
using Tholaumuntu.DataAcces.Contexts;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Domain = Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        public HomeController()
        {
            _userRepository = new UserRepository();
        }
        public ActionResult Index()
        {
            return View();
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

        public JsonResult Register(string firstName, string surname, string email, string password, string contact)
        {
            var user = new Domain.User
            {
                Name = firstName,
                ContactNumber = contact,
                Email = email,
                Password = password,
                Surname = surname,
                DateOfBirth = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            if (_userRepository != null)
            {
                try
                {
                    var isSaved = _userRepository.AddUser(user);

                    if (isSaved == 1)
                        return Json(new { data = true, JsonRequestBehavior.AllowGet });

                    return Json(new { data = false, JsonRequestBehavior.AllowGet });
                }
                catch (DbException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }

            return Json(new { data = false, JsonRequestBehavior.AllowGet });
        }
    }
}