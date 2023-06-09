using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Smsark.Models;
using System.Diagnostics;


namespace Smsark.Controllers
{

    public class HomeController : Controller
    {

        private readonly SmsarkDb _smsarkDbContext;
        private readonly IWebHostEnvironment _environment;
      //  private readonly ILogger<HomeController> _logger;

        public HomeController(SmsarkDb _smsarkDbContext, IWebHostEnvironment _environment)
        {
        //    _logger = logger;
            this._smsarkDbContext = _smsarkDbContext;
            this._environment = _environment;
        }
        public string SignInFlag = "0";
        




        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            var name = HttpContext.Session.GetString("Name");
            if (string.IsNullOrEmpty(name))
            {
                //    return RedirectToAction("index", "Home");
                return View();
            }
            return View();
        }

        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }

            return View();

        }
        public IActionResult DisplayRooms()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            //from bed in _context.Beds
            //join room in _context.Rooms
            //on bed.RoomId equals room.Id
            //select new { Bed = bed, Room = room }
            var listt = from bed in _smsarkDbContext.Beds join room in _smsarkDbContext.Rooms on bed.RoomId equals room.RoomId join apartment in _smsarkDbContext.apartments on room.ApartmentId equals apartment.ApartmentId select  new { Bed = bed, Room = room, Apartment = apartment };
            var newlistt = listt.Where( s => s.Bed.IsReserved == false);
            //     var availableBeds = _smsarkDbContext.Beds.Where(i => i.IsReserved == false).ToList();
            TempData["Counttt"] = newlistt.Count();
            if (listt == null) {
                return Redirect("/Home/index");
            }
            return View(newlistt);
            
        }

        public IActionResult Booking()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }

            return Redirect("/Home/Index/#booking");
        }

        public IActionResult abt()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {

                TempData["SigninFlag"] = "1";
            }

            return Redirect("/Home/Index/#aboutus");
        }
        public IActionResult Rooms()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }

        public RedirectResult signup()
        {
            return Redirect("/Customer/CustomerRegister");
        }

        public RedirectResult signin()
        {
            TempData["SignInEmail"] = "";
            TempData["SignInPassword"] = "";
            return Redirect("/Customer/CustomerLogin");
        }

        public IActionResult Signn(IFormCollection req)
        {
            TempData["SignInEmail"] = req["email"];
            TempData["SignInPassword"] = req["password"];


            if (TempData["SignInEmail"].ToString() == "Radwa@gmail.com" && TempData["SignInPassword"].ToString() == "1234")
            {
                HttpContext.Session.SetString("SignedIn", "1");
                TempData["SigninFlag"] = "1";
                return View("Index", "Home");
            }

            else
            {
                TempData["Wrong"] = 1;
                return RedirectToAction("signin");
            }
        }

        public IActionResult LogOut()
        {

            HttpContext.Session.SetString("SignedIn", "0");
            return View("Index", "Home");
        }
        public IActionResult UserProfile()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }
        public IActionResult payment()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
                return View();
            }
            else
            {
                TempData["ReservExcept"] = "1";
                return RedirectToAction("Room");

            }

        }

        public IActionResult Aboutus()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View("Aboutus");
        }

        public IActionResult Contact()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }

        public IActionResult Room(int BedId)
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
           // var bed = _smsarkDbContext.Beds.Where(b => b.BedId == BedId).FirstOrDefault();
            var packs = from bed in _smsarkDbContext.Beds join room in _smsarkDbContext.Rooms on bed.RoomId equals room.RoomId join apartment in _smsarkDbContext.apartments on room.ApartmentId equals apartment.ApartmentId select new { Bed = bed, Room = room, Apartment = apartment };
            var pack = packs.Where(r => r.Bed.BedId == BedId).FirstOrDefault();
            RoomViewModel roro = new RoomViewModel();

              roro.Bed = pack.Bed;
                roro.Apartment = pack.Apartment;
                roro.Room = pack.Room;
            
            return View(roro);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}