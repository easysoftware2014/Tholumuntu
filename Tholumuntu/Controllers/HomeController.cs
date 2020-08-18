using Microsoft.AspNet.SignalR.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Tholumuntu.Helpers;
using Tholumuntu.Models;
using Domain = Tholaumuntu.DataAcces.Domain;

namespace Tholumuntu.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserProfileRepository _profileRepository;
        public HomeController()
        {
            _userRepository = new UserRepository();
            _profileRepository = new UserProfileRepository();
        }
        private List<string> GetAllRegisteredUsersEmails()
        {
            return _userRepository.GetAllUsers().Select(x => x.Email).ToList();
        }
        public ActionResult Index()
        {

            var cache = GetAllRegisteredUsersEmails();
            var api = ConfigurationManager.AppSettings["NumberVerificationAPI"];
            var apiKey = ConfigurationManager.AppSettings["ApiAccessKey"];

            ViewBag.URL = api + apiKey + "&number=";
            ViewBag.EmailCache = cache;

            return View();
        }

        public ActionResult LogOut()
        {
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index");
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
        private string MaskPassword(string password)
        {
            return Encryption.Encrypt(password);
        }

        private string GetSalt(string password)
        {
            return Encryption.Salt(password);
        }
        public ActionResult Register(string firstName, string surname, string email, string password, string contact, string age)
        {

            if (!IsEmailUnique(email))
            {
                return null;
            }

            var salt = GetSalt(password);

            var user = new Domain.User
            {
                Name = firstName,
                ContactNumber = contact,
                Email = email,
                Password = MaskPassword(password) + salt,
                Surname = surname,
                DateOfBirth = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Salt = salt,
                EntityStatus = Domain.EntityStatus.InActive,
                EmailVerified = false
            };
            var convertAge = CalculateAge.GetAge(Convert.ToDateTime(age));

            if (_userRepository != null)
            {
                try
                {
                    user.Age = convertAge;
                    var id = _userRepository.AddUser(user);

                    var profile = new Domain.UserProfile
                    {
                        UserId = user.Id,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    };

                    _profileRepository.AddUserProfile(profile);

                    if (id > 0)
                    {
                        Session["UserId"] = user.Id;
                        SendEmail.SendUserEmail(user.Email, user.Password);

                        return Json(new { data = true, JsonRequestBehavior.AllowGet });
                    }

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

        private bool IsEmailUnique(string email)
        {
            return !GetAllRegisteredUsersEmails().Contains(email);
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                var maskedPass = MaskPassword(password);
                var salt = GetSalt(password);
                var finalPass = maskedPass + salt;

                var user = _userRepository.GetUserByEmailAndPassword(email, finalPass);
                var model = new UserModel();

                if (user != null)//&&user.EmailVerified
                {
                    Session["UserId"] = user.Id;
                    model = new UserModel(user);

                    return Json(new { data = model, JsonRequestBehavior.AllowGet });
                }

                return Json(new { data = model });
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public ActionResult VerifyPhoneNumber(string number)
        {
            try
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult EmailVerification(string username, string confirm_id)
        {

            try
            {
                var user = _userRepository.GetUserByEmailAndPassword(username, confirm_id);

                if (user != null)
                {
                    user.EmailVerified = true;
                    user.EntityStatus = Domain.EntityStatus.Active;

                    var isSuccessful = _userRepository.Update(user);

                    if (isSuccessful)
                        Session["UserId"] = user.Id;

                    return RedirectToAction("Index", "QuestionAnswer");
                }
                else
                    return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                var user = _userRepository.GetUserByEmail(email);
                var model = new UserModel();

                if (user != null)
                {
                    Session["UserId"] = user.Id;
                    model = new UserModel(user);
                    var tempPass = Encryption.Encrypt(user.Email + user.Name);

                    user.Password = tempPass;
                    var hasUpdated = _userRepository.Update(user);

                    if (hasUpdated)
                        SendEmail.SendForgotPasswordEmail(user.Email, user.Name, tempPass);

                    return Json(new { EmailSent = true, JsonRequestBehavior.AllowGet });
                }

                return Json(new { EmailSent = false, JsonRequestBehavior.AllowGet });
            }
            catch (DbException ex)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult ResetPassword(string tempUrl, string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(tempUrl) && !string.IsNullOrEmpty(email))
                {
                    var user = _userRepository.GetUserByEmail(email);
                    Session["email"] = email;

                    if(user.Id > 0)
                    {
                       return View();                       
                    }

                    return View();
                }

                return View();
            }
            catch (DbException ex)
            {


                return null;
            }

        }
        [HttpPost]
        public ActionResult ResetPassword(string password)
        {
            try
            {
                var email = Session["email"].ToString();
                var user = _userRepository.GetUserByEmail(email);

                if(user.Id > 0)
                {
                    var encrypted = MaskPassword(password);
                    var salt = GetSalt(password);

                    user.Password = encrypted + salt;
                    user.Salt = salt;

                    _userRepository.Update(user);

                    return Json(new {data =  true, JsonRequestBehavior.AllowGet } );

                }

            }
            catch (DbException ex)
            {
                
                return Json(new { data = false, JsonRequestBehavior.AllowGet });
            }

            return View("");

        }
    }
}