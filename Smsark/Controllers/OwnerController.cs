using Microsoft.AspNetCore.Mvc;
using Smsark.Models;

namespace Smsark.Controllers
{
    public class OwnerController : Controller
    {

        private readonly SmsarkDb _smsarkDbContext;
        private readonly IWebHostEnvironment _environment;

        public OwnerController(SmsarkDb _smsarkDbContext, IWebHostEnvironment _environment)
        {
            this._smsarkDbContext = _smsarkDbContext;
            this._environment = _environment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";
            }
            TempData["flag"] = 0;
            TempData["EditFlag"] = 0;
            return View();

        }
        public IActionResult ownerProfile()
        {
            return View();
        }

        public IActionResult signin()
        {

            return View();

        }
        [HttpPost("Owner/signin")]
        public IActionResult signin(Owner O)
        {

            var owner = _smsarkDbContext.owners.Where(s => s.Email ==
              O.Email && s.Password == O.Password).FirstOrDefault();
            if (owner == null)
            {
                return Redirect("/Owner/signin");
            }
            HttpContext.Session.SetString("Email", owner.Email);
            HttpContext.Session.SetString("OwnerId", (owner.OwnerId).ToString());
            HttpContext.Session.SetString("SignedInOwner", "1");
            return Redirect("/Owner/UserProfile");
        }

        //public IActionResult Signn(IFormCollection req)
        //{
        //    TempData["SignInEmail"] = req["email"];
        //    TempData["SignInPassword"] = req["password"];


        //    if (TempData["SignInEmail"].ToString() == "Radwa@gmail.com" && TempData["SignInPassword"].ToString() == "1234")
        //    {
        //        HttpContext.Session.SetString("SignedInOwner", "1");
        //        TempData["SigninOwnerFlag"] = "1";

        //        return View("Index", "Owner");
        //    }

        //    else
        //    {
        //        TempData["Wrong"] = 1;
        //        return RedirectToAction("signin");
        //    }
        //}

        //Edit Owner
        public IActionResult UserProfile()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            var OwnerEmail = HttpContext.Session.GetString("Email");
            var owner = _smsarkDbContext.owners.Where(s => s.Email == OwnerEmail).FirstOrDefault();

            if (owner == null)
            {
                return Redirect("owner/signin");
            }
            ViewBag.Owner = owner;
            TempData["n"] = owner.Email;

            return View(owner);
            //return View();
        }

        [HttpPost]
        public IActionResult UserProfile(Owner owner)
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }

            String ownerEmail = HttpContext.Session.GetString("Email");
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";

            }

            var tempOwner = _smsarkDbContext.owners.Where(owner => owner.Email == ownerEmail).FirstOrDefault();
            if (tempOwner == null)
            {
                return BadRequest("there's no owner with the same owner email");
            }

            tempOwner.Email = owner.Email ?? tempOwner.Email;
            tempOwner.Password = owner.Password ?? tempOwner.Password;
            tempOwner.Name = owner.Name ?? tempOwner.Name;
            tempOwner.PhoneNo = owner.PhoneNo ?? tempOwner.PhoneNo;
            tempOwner.Gender = owner.Gender ?? tempOwner.Gender;

            _smsarkDbContext.owners.Update(tempOwner);
            _smsarkDbContext.SaveChanges();
            TempData["upd"] = "1";
            return Redirect("/Owner/UserProfile");
        }


        public IActionResult Contact()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";
            }
            return View();
        }


        public IActionResult DeleteAccount()
        {
            var owner = _smsarkDbContext.owners.Where(o => o.Email ==
              HttpContext.Session.GetString("Email")).FirstOrDefault();

            if (owner == null)
            {
                return BadRequest("there's no customer with this CustomerEmail");
            }

            _smsarkDbContext.owners.Remove(owner);
            _smsarkDbContext.SaveChanges();

            LogOut();
            return Redirect("/Owner/Index");
        }



        public IActionResult AddApartments()
        {

            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            var OwnerEmail = HttpContext.Session.GetString("Email");
            var owner = _smsarkDbContext.owners.Where(s => s.Email == OwnerEmail).FirstOrDefault();

            if (owner == null)
            {
                return Redirect("owner/signin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddApartments(Apartment a, IFormFile img_file, IFormFile img_file1, IFormFile img_file2, IFormFile img_file3)
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            var OwnerEmail = HttpContext.Session.GetString("Email");
            var owner = _smsarkDbContext.owners.Where(s => s.Email == OwnerEmail).FirstOrDefault();

            string path = Path.Combine(_environment.WebRootPath, "img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string unique = (DateTime.Now.Ticks + 50).ToString();
            if (img_file1 != null && img_file1.Length > 0)
            {
                string path1 = Path.Combine(path, unique + img_file1.FileName); // for example : /Img/Photoname.png
                using (var stream = new FileStream(path1, FileMode.Create))
                {
                    img_file1.CopyTo(stream);
                    //ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }

                a.SecPhoto = unique + img_file1.FileName;
            }
            else
            {
                a.SecPhoto = "default.jpeg"; // to save the default image path in database.
            }
            unique = (DateTime.Now.Ticks + 10).ToString();
            if (img_file2 != null && img_file2.Length > 0)
            {
                string path2 = Path.Combine(path, unique + img_file2.FileName); // for example : /Img/Photoname.png
                using (var stream = new FileStream(path2, FileMode.Create))
                {
                    img_file2.CopyTo(stream);
                    //ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }

                a.ThirdPhoto = unique + img_file2.FileName;
            }
            else
            {
                a.ThirdPhoto = "default.jpeg"; // to save the default image path in database.
            }
            unique = (DateTime.Now.Ticks + 20).ToString();
            if (img_file3 != null && img_file3.Length > 0)
            {
                string path3 = Path.Combine(path, unique + img_file3.FileName); // for example : /Img/Photoname.png
                using (var stream = new FileStream(path3, FileMode.Create))
                {
                    img_file3.CopyTo(stream);
                    //ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }

                a.FourthPhoto = unique + img_file3.FileName;
            }
            else
            {
                a.FourthPhoto = "default.jpeg"; // to save the default image path in database.
            }
            unique = (DateTime.Now.Ticks + 30).ToString();
            if (img_file != null && img_file.Length > 0)
            {
                string path4 = Path.Combine(path, unique + img_file.FileName); // for example : /Img/Photoname.png
                using (var stream = new FileStream(path4, FileMode.Create))
                {
                    img_file.CopyTo(stream);
                    //ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }

                a.MainPhoto = unique + img_file.FileName;
            }
            else
            {
                a.MainPhoto = "default.jpeg"; // to save the default image path in database.
            }

            a.OwnerId = owner.OwnerId;

            _smsarkDbContext.Add(a);
            _smsarkDbContext.SaveChanges();
            TempData["Successful"] = "1";
            return RedirectToAction("DispApartment", a);

        }

        public IActionResult LogOut()
        {

            HttpContext.Session.SetString("SignedInOwner", "0");
            HttpContext.Session.Clear();
            return View("Index", "Owner");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }


        [HttpPost("/Register")]
        [ValidateAntiForgeryToken]  // to more security
        public IActionResult Register(Owner owner, IFormFile img_file)
        {


            string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string unique = DateTime.Now.Ticks.ToString();
            if (img_file != null && img_file.Length > 0)
            {
                path = Path.Combine(path, unique + img_file.FileName); // for example : /Img/Photoname.png
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img_file.CopyTo(stream);
                    //ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
                }
                owner.NationalIdPhoto = unique + img_file.FileName;
            }
            else
            {
                owner.NationalIdPhoto = "default.jpeg"; // to save the default image path in database.
            }


            _smsarkDbContext.Add(owner);
            _smsarkDbContext.SaveChanges();
            TempData["Successful"] = "1";
            return Redirect("/Owner/signin");

        }


        public IActionResult signupp()
        {
            TempData["Successful"] = 1;
            return RedirectToAction("signin");

        }


        public IActionResult DisplayRooms()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                var ow = HttpContext.Session.GetString("OwnerId");

                List<Apartment> ownerAparts = _smsarkDbContext.apartments.Where(s => (s.OwnerId).ToString() == ow).ToList();
                TempData["SigninOwnerFlag"] = "1";
                TempData["Num"] = ownerAparts.Count;
                return View(ownerAparts);
            }
            else
            {
                TempData["SignedInException"] = "1";
                return RedirectToAction("Index");


            }

        }


        public IActionResult EditRooms()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";
                return View();
            }
            else
            {
                TempData["SignedInException"] = "1";
                return RedirectToAction("Index");


            }
        }


        public IActionResult AddRooms()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";
                return View();
            }
            else
            {
                TempData["SignedInException"] = "1";
                return RedirectToAction("Index");


            }
        }


        //public RedirectToActionResult AddRoom()
        //{
        //    TempData["flag"] = 1;
        //    return RedirectToAction("DisplayRooms");

        //}


        /*  public IActionResult AddRoom(Room r )
           {
               if (HttpContext.Session.GetString("SignedInOwner") == "1")
               {
                   TempData["SigninOwnerFlag"] = "1";

               }

               return View(r);
           }
           */

        public IActionResult DispRooms(int apartmentID)
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
           
            List<Room> rooms = _smsarkDbContext.Rooms.Where(s => s.ApartmentId == apartmentID).ToList();

           
            if (rooms == null)
            {
                return Redirect("Index");
            }
            return View(rooms);
        }
      // [HttpPost]
        public IActionResult AddRoom( int apartmentID)
        {

            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            var room = new Room();
            var apartment = _smsarkDbContext.apartments.Where(s => s.ApartmentId == apartmentID).FirstOrDefault();
            if (apartment == null) {
                return Redirect("/Home/Index");
            }
            room.ApartmentId = apartment.ApartmentId;
            room.apartment = apartment;
           
            _smsarkDbContext.Add(room);
            _smsarkDbContext.SaveChanges();
            TempData["SuccessfulRoomAdd"] = "1";
            List<Room> rooms = _smsarkDbContext.Rooms.Where(s => s.ApartmentId == apartmentID).ToList();
            HttpContext.Session.SetString("CurrentApart", apartmentID.ToString());
            return RedirectToAction("DispApartment", apartment);
           

        }
        //  [HttpPost]
        public IActionResult DispApartment(Apartment a)
        {
            return View(a);
        }
        public RedirectToActionResult EditRoom()
        {
            TempData["EditFlag"] = 1;
            return RedirectToAction("DisplayRooms");

        }

        public IActionResult AddBed(int RoomId) {
            HttpContext.Session.SetString("CurrentRoomId",RoomId.ToString());
        return View();
        }

        [HttpPost]
        public IActionResult AddBed(Bed bed)
        {

            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
         
                String RoomId = HttpContext.Session.GetString("CurrentRoomId");
            

            var room = _smsarkDbContext.Rooms.Where(s => s.RoomId.ToString() == RoomId).FirstOrDefault();

            bed.RoomId = room.RoomId;
            bed.BedPrice = bed.BedPrice;
            _smsarkDbContext.Add(bed);
            _smsarkDbContext.SaveChanges();
            TempData["SuccessfulAdd"] = "1";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteRoom(int RoomId)
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            var room = _smsarkDbContext.Rooms.Where(s => s.RoomId == RoomId).FirstOrDefault();

            if (room == null)
            {
                return BadRequest("there's no customer with this CustomerEmail");
            }

            _smsarkDbContext.Rooms.Remove(room);
            _smsarkDbContext.SaveChanges();
            TempData["RoomRemoved"] = 1;
            return RedirectToAction("Index");


        }
        public IActionResult DeleteBed(int bedId)
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            var bed = _smsarkDbContext.Beds.Where(s => s.BedId == bedId).FirstOrDefault();

            if (bed == null)
            {
                return BadRequest("there's no customer with this CustomerEmail");
            }

            _smsarkDbContext.Beds.Remove(bed);
            _smsarkDbContext.SaveChanges();
            TempData["Removed"] = 1;
            return RedirectToAction("Index");

        }

        public IActionResult DeleteApartment(int ApartmentId)
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            var apart = _smsarkDbContext.apartments.Where(s => s.ApartmentId == ApartmentId).FirstOrDefault();

            if (apart == null)
            {
                return BadRequest("there's no customer with this CustomerEmail");
            }

            _smsarkDbContext.apartments.Remove(apart);
            _smsarkDbContext.SaveChanges();
            TempData["RemovedApartment"] = 1;
            return RedirectToAction("Index");

        }
        public IActionResult DispBeds(int RoomId) {

            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";

            }
            List<Bed> bed = _smsarkDbContext.Beds.Where(s => s.RoomId == RoomId).ToList();
            foreach(var b in bed)
            {
                ViewBag.BedId = b;
            }
         
            return View(bed);
        }
        }
    }