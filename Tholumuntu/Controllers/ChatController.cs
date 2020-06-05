using System;
using System.Web.Mvc;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Tholumuntu.Models;

namespace Tholumuntu.Controllers
{
    public class ChatController : Controller
    {
        private readonly IUserRepository _userRepository;

        public ChatController()
        {
            _userRepository = new UserRepository();
        }
        // GET: Chat
        public ActionResult LetsChat()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var model = new UserModel();

            if (id > 0)
            {
                var user = _userRepository.GetUserById(id);

                model = new UserModel(user);
                model.FullName = model.GetFullName(user.Name, user.Surname);
                ViewBag.ImgData = Session["ImgDataUrl"];
            }
            else
            {
                RedirectToAction("index", "Home");
            }

            return View(model);
        }
    }
}