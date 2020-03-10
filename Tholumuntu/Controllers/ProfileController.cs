using System;
using System.Web.Mvc;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Tholumuntu.Models;

namespace Tholumuntu.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;

        public ProfileController()
        {
            _profileRepository = new UserProfileRepository();
            _userRepository = new UserRepository();
        }
        // GET: Profile
        public ActionResult Index()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var user = new UserModel();

            if (id > 0)
            {
                var currentUser = _userRepository.GetUserById(id);
                user.Id = currentUser.Id;
                user.Name = currentUser.Name;
                user.Surname = currentUser.Surname;
                user.ContactNumber = currentUser.ContactNumber;
                user.Email = currentUser.Gender;

            }
            var profile = _profileRepository.GetProfile(id);
            var model = new UserProfileModel();

            if (profile != null)
                model = new UserProfileModel(profile);
            else
            {
                model.User = user;
            }


            return View(model);
        }
        [HttpGet]
        public ActionResult SetProfile(UserProfileModel model)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProfile(UserProfileModel model)
        {
            return View(" ");
        }

        //private byte[] ConvertImageToByte()
        //{
        //    return
        //}
    }
}