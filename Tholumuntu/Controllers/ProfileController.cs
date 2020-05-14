using System;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Tholaumuntu.DataAcces.Domain;
using Tholaumuntu.Repository.Contracts;
using Tholaumuntu.Repository.Repositories;
using Tholumuntu.Helpers;
using Tholumuntu.Models;

namespace Tholumuntu.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserProfileRepository _profileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPersonalQuizRepository _personalQuizRepository;
        public int Id { get; set; }
        public ProfileController()
        {
            _profileRepository = new UserProfileRepository();
            _userRepository = new UserRepository();
            _personalQuizRepository = new PersonalQuizRepository();
        }
        // GET: Profile
        public ActionResult Index()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            Id = id;

            if (id > 0)
            {
                var user = new User { ContactNumber = string.Empty, Email = "", Name = "", Surname = "" };
                var choices = Enum.GetValues(typeof(Choice)).Cast<Choice>();
                var loveLanguages = Enum.GetValues(typeof(LoveLanguage)).Cast<LoveLanguage>();
                var horoscopes = Enum.GetValues(typeof(Horoscope)).Cast<Horoscope>();

                var horoscopeList = horoscopes.Select(
                    item => new SelectListItem
                    {
                        Selected = false,
                        Text = item.GetEnumDescription(),
                        Value = ((int)item).ToString()
                    }).ToList();

                var loveLanguageList = loveLanguages.Select(
                    item => new SelectListItem
                    {
                        Selected = false,
                        Text = item.GetEnumDescription(),
                        Value = ((int)item).ToString()
                    }).ToList();

                var choiceItems = choices.Select(
                    item => new SelectListItem
                    {
                        Selected = false,
                        Text = item.GetEnumDescription(),
                        Value = ((int)item).ToString()
                    }).ToList();

                var model = new UserProfileModel
                {
                    LoveLanguageList = loveLanguageList,
                    ChoiceItemList = choiceItems,
                    HoroscopeItemList = horoscopeList
                };

                var currentUser = _userRepository.GetUserById(id);
                user.Id = currentUser.Id;
                user.Name = currentUser.Name;
                user.Surname = currentUser.Surname;
                user.ContactNumber = currentUser.ContactNumber;
                user.Email = currentUser.Email;
                var quiz = _personalQuizRepository.GetQuizByUserId(currentUser.Id);
                var userProfile = _profileRepository.GetProfileByUserId(currentUser.Id);

                model.Horoscope = userProfile != null ? userProfile.Horoscope : string.Empty;
                model.Gender = userProfile?.Gender;

                if (userProfile != null)
                {
                    model.SelectedDropdownValueForLove = GetSelectedValueForLove(userProfile.LoveLanguage);
                    model.GetFullName(currentUser);
                    Session["FullName"] = model.FullName;
                }

                if (quiz != null)
                {
                    model.Quiz = new PersonalQuizModel(quiz);
                    model.SelectedDropdownValue = GetSelectedValue(quiz.ChoiceBetweenMoneyLoveHappiness);
                }

                model.SetUser(currentUser);

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        public string FullName()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var currentUser = _userRepository.GetUserById(id);

            return currentUser.Name + " " + currentUser.Surname;
        }
        public FileContentResult ProfilePhoto()
        {
            var id = Convert.ToInt32(Session["UserId"]);
            var currentUser = _userRepository.GetUserById(id);
            var userProfile = _profileRepository.GetProfileByUserId(currentUser.Id);

            if (userProfile != null && userProfile.ProfilePicture != null)
                return new FileContentResult(userProfile.ProfilePicture, "image/jpeg");
            else
            {
                var fileName = HttpContext.Server.MapPath(@"~/Images/heart.gif");

                byte[] imageData = null;
                var fileInfo = new FileInfo(fileName);
                var imageFileLength = fileInfo.Length;
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
            }
        }
        private string GetSelectedValueForLove(LoveLanguage loveLanguage)
        {
            var value = string.Empty;

            switch (loveLanguage)
            {
                case LoveLanguage.WordsOfAffirmation:
                    value = "1";
                    break;
                case LoveLanguage.ActOfService:
                    value = "2";
                    break;
                case LoveLanguage.ReceivingGifts:
                    value = "3";
                    break;
                case LoveLanguage.QualityTime:
                    value = "4";
                    break;
                case LoveLanguage.PhysicalTouch:
                    value = "5";
                    break;
            }

            return value;
        }
        private string GetSelectedValue(Choice choice)
        {
            var value = string.Empty;

            switch (choice)
            {
                case Choice.Happiness:
                    value = "3";
                    break;
                case Choice.Love:
                    value = "2";
                    break;
                case Choice.Money:
                    value = "1";
                    break;
            }

            return value;
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
        [HttpPost]
        public ActionResult UpdateProfile(string name, string surname, string number,
                                          string city, string state, string gender, string _profile, string imgType)
        {
            try
            {
                var imgString = string.Empty;
                byte[] image = null;

                switch (imgType)
                {
                    case "image/jpeg":
                        imgString = _profile.Substring(23);
                        image = Convert.FromBase64String(imgString);
                        break;
                    case "image/png":
                        imgString = _profile.Substring(22);
                        image = Convert.FromBase64String(imgString);
                        break;
                    case "image/gif":
                        imgString = _profile.Substring(22);
                        image = Convert.FromBase64String(imgString);
                        break;
                }

                var user = _userRepository.GetUserById(Convert.ToInt32(Session["UserId"]));
                var profile = _profileRepository.GetProfileByUserId(Convert.ToInt32(Session["UserId"]));

                if (profile != null)
                {
                    profile.Gender = gender;
                    profile.ProfilePicture = image;

                    _profileRepository.UpdateUserProfile(profile);
                }
                if (user != null)
                {
                    user.Name = name;
                    user.Surname = surname;
                    user.ContactNumber = number;
                    user.Street = city;
                    user.State = state;
                    user.ModifiedAt = DateTime.Now;

                    _userRepository.Update(user);
                }

                return Json(new { success = true, JsonRequestBehavior.AllowGet });
            }
            catch (DbException e)
            {
                return Json(new { error = e.Message, JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message, JsonRequestBehavior.AllowGet });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPersonalQuizToProfile(UserProfileModel model)
        {
            var choice = Choice.Happiness;
            Id = Convert.ToInt32(Session["UserId"]);
            var currentUser = _userRepository.GetUserById(model.User.Id);

            switch (Convert.ToInt32(model.Quiz.Choice))
            {
                case 1:
                    choice = Choice.Money;
                    break;
                case 2:
                    choice = Choice.Love;
                    break;
                case 3:
                    choice = Choice.Happiness;
                    break;
            }
            var quiz = new PersonalQuiz
            {
                AttractiveInPartner = model.Quiz.AttractiveInPartner,
                WordsThatDescribesMe = model.Quiz.WordsThatDescribesMe,
                ChoiceBetweenMoneyLoveHappiness = choice,
                UserId = currentUser.Id,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            try
            {
                var transactionPassed = false;

                if (model.Quiz.Id > 0)
                {
                    quiz.Id = model.Quiz.Id;

                    if (_personalQuizRepository.Update(quiz))
                        transactionPassed = true;
                }
                else
                {
                    var id = _personalQuizRepository.Add(quiz);

                    if (id > 0)
                        transactionPassed = true;
                }

                if (transactionPassed)
                {
                    var profile = _profileRepository.GetProfileByUserId(Id);
                    profile.QuizId = quiz.Id;
                    profile.Horoscope = model.Horoscope;
                    profile.LoveLanguage = model.LoveLanguage;

                    _profileRepository.UpdateUserProfile(profile);
                    ViewBag.Success = true;

                    return RedirectToAction("Index","FindLove");
                }

                ViewBag.Success = false;

                return RedirectToAction("Index");
            }
            catch (DbException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Index");
                return Json(new { Error = e.Message, JsonRequestBehavior.AllowGet });
            }
        }
        [HttpPost]
        public ActionResult AddHoroscopeToProfile(string horoscope)
        {
            try
            {
                var profile = _profileRepository.GetProfileByUserId(Convert.ToInt32(Session["UserId"]));

                if (profile != null)
                {
                    profile.Horoscope = horoscope;
                    profile.ModifiedAt = DateTime.Now;

                    _profileRepository.UpdateUserProfile(profile);
                }

                return Json(new { success = true, JsonRequestBehavior.AllowGet });
            }
            catch (DbException e)
            {
                return Json(new { error = e.Message, JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message, JsonRequestBehavior.AllowGet });
            }
        }
        [HttpPost]
        public ActionResult AddLoveLanguageToProfile(int loveLanguage)
        {
            try
            {
                var love = LoveLanguage.WordsOfAffirmation;

                switch (loveLanguage)
                {
                    case 1:
                        love = LoveLanguage.WordsOfAffirmation;
                        break;
                    case 2:
                        love = LoveLanguage.ActOfService;
                        break;
                    case 3:
                        love = LoveLanguage.ReceivingGifts;
                        break;
                    case 4:
                        love = LoveLanguage.QualityTime;
                        break;
                    case 5:
                        love = LoveLanguage.PhysicalTouch;
                        break;
                }

                var profile = _profileRepository.GetProfileByUserId(Convert.ToInt32(Session["UserId"]));
                profile.LoveLanguage = love;
                profile.ModifiedAt = DateTime.Now;

                _profileRepository.UpdateUserProfile(profile);

                return Json(new { success = true, JsonRequestBehavior.AllowGet });
            }
            catch (DbException e)
            {
                return Json(new { error = e.Message, JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message, JsonRequestBehavior.AllowGet });
            }
        }
        //private byte[] ConvertImageToByte()
        //{
        //    return
        //}
    }
}