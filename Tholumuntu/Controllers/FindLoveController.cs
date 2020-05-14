using System;
using System.Web.Mvc;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Tholumuntu.Helpers;

namespace Tholumuntu.Controllers
{
    public class FindLoveController : Controller
    {
        private readonly IUserRepository _userRepository;

        public FindLoveController()
        {
            _userRepository = new UserRepository();
        }
        public ActionResult Index()
        {
            ViewBag.FullName = Session["FullName"];

            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(string subject, string message)
        {
            try
            {
                var user = _userRepository.GetUserById(Convert.ToInt32(Session["UserId"]));

                if (!string.IsNullOrEmpty(subject) && !string.IsNullOrEmpty(message))
                {
                    if (user != null)
                    {
                        var isSent = SendEmail.SendMessageToAdmin
                        (subject, message, user.Email, user.ContactNumber,
                            string.Concat(user.Name, user.Surname));

                        if (isSent)
                        {
                            return Json(new { isSent = true, JsonRequestBehavior.AllowGet });
                        }
                    }
                }

                return Json(new { isSent = false, JsonRequestBehavior.AllowGet });

            }
            catch (Exception error)
            {
                return Json(new {error = error.Message, JsonRequestBehavior.AllowGet});
            }
        }
    }
}