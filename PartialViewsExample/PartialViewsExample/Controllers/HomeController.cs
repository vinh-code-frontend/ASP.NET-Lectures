using Microsoft.AspNetCore.Mvc;
using PartialViewsExample.Models;

namespace PartialViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["Data"] = new List<User>() {
                new User ()
                {
                    Id = 1,
                    Name ="Vinh",
                    Job = "FE dev"
                },
                 new User ()
                {
                    Id = 2,
                    Name ="Kim Anh",
                    Job = "Broker"
                }

            };
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("friends")]
        public IActionResult Friends()
        {
            List<User> users = new List<User>() {
                new User()
                {
                    Id = 1,
                    Name = "Tít",
                    Job = "Ngủ"
                },
                 new User()
                {
                    Id = 2,
                    Name = "Chụt",
                    Job = "Ăn"
                },
                  new User()
                {
                    Id = 2,
                    Name = "Ki",
                    Job = "Chơi"
                },
                   new User()
                {
                    Id = 2,
                    Name = "Lu",
                    Job = "Lăn"
                },
                    new User()
                {
                    Id = 2,
                    Name = "Ponny",
                    Job = "Unknown"
                },
                     new User()
                {
                    Id = 2,
                    Name = "Đấc",
                    Job = "Quẹc quẹc"
                },
            };
            return View(users);
        }
    }
}
