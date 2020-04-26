using System.Web.Mvc;

namespace Tholumuntu.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult LetsChat()
        {
            return View();
        }
    }
}