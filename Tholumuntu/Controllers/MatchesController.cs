using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tholaumuntu.Services.Services;
using Tholumuntu.Models;

namespace Tholumuntu.Controllers
{
    public class MatchesController : Controller
    {
        private readonly UserService _userService;
        private readonly UserProfileService _profileService;

        public MatchesController()
        {
            _userService = new UserService();
            _profileService = new UserProfileService();
        }

        public ActionResult Index()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var users = _userService.GetAllUsers().ToList();
            var user = users.Single(x => x.Id == id);
            var userProfile = _profileService.GetProfileByUserId(id);

            if (userProfile.ProfilePicture != null)
            {
                var returnImage = new FileContentResult(userProfile.ProfilePicture, "image/jpeg");

                ViewBag.ImgData = Session["ImgDataUrl"];
                CreateTemporaryFolderToStoreImage(returnImage);
            }
            var userProfileModel = new List<UserProfileModel>();

            foreach (var user1 in users)
            {
                var profile = _profileService.GetProfileByUserId(user1.Id);
                profile.User = user1;
                var imageByte = profile.ProfilePicture != null? Convert.ToBase64String(profile.ProfilePicture): string.Empty;

                profile.Image = !string.IsNullOrEmpty(imageByte) ? $"data:image/png;base64,{imageByte}" : string.Empty;
                userProfileModel.Add(new UserProfileModel(profile));
            }

            ViewBag.User = user;

            return View(userProfileModel);
        }
        private void CreateTemporaryFolderToStoreImage(FileContentResult returnImage)
        {
            var imgBase64Data = Convert.ToBase64String(returnImage.FileContents);
            var imgDataUrl = $"data:image/png;base64,{imgBase64Data}";

            ViewBag.ImgData = imgDataUrl;
            Session["ImgDataUrl"] = imgDataUrl;

        }
    }
}