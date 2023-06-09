using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smsark.Models;
using System.Security.Cryptography;

namespace Smsark.Controllers
{
    public class ReservationController1 : Controller
    {
        SmsarkDb smsarkDbContext;
        IMapper _Mapper;
        private readonly SmsarkDb SmsarkDbContext;
        private readonly IWebHostEnvironment _environment;


        public ReservationController1(SmsarkDb context, IWebHostEnvironment environment, IMapper mapper)
        {
            smsarkDbContext = context;
            _environment = environment;
            _Mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddReservation(ReservationData RD, int BedId)
        {
            String CustomerEmail = HttpContext.Session.GetString("CustomerEmail");
            RD.CustomerEmail = CustomerEmail;
            var cust = smsarkDbContext.customers.Where(c => c.CustomerEmail == RD.CustomerEmail).FirstOrDefault();
            if (cust == null)
            {
                return Unauthorized("your email isn't valid ");
            }

            Reservation reservation = new Reservation()
            {
                CustomerEmail = RD.CustomerEmail

            };
            var checkreserv = smsarkDbContext.reservationItems.Where(i => i.BedId == BedId).FirstOrDefault();
            if (checkreserv == null)
            {
                smsarkDbContext.reservations.Add(reservation);
                smsarkDbContext.SaveChanges();
                ReservationItem item = new ReservationItem()
                {
                    ReservationId = reservation.ReservationId,
                    BedId = BedId
                };
                smsarkDbContext.reservationItems.Add(item);
                smsarkDbContext.SaveChanges();
            }
            var changeFlag = smsarkDbContext.Beds.Where(d => d.BedId == BedId).FirstOrDefault();
            changeFlag.IsReserved = true;
            smsarkDbContext.Beds.Update(changeFlag);
            smsarkDbContext.SaveChanges();
            TempData["SucessfullReservation"] = 1;
            return RedirectToAction("Index","Home");

        }
        public IActionResult RemoveReservation(int reservID)
        {
            var check = SmsarkDbContext.reservations.Where(i => i.ReservationId == reservID).FirstOrDefault();
            if (check == null)
            {
                return BadRequest("this reservation doesn't exist");
            }
            SmsarkDbContext.reservations.Remove(check);
            SmsarkDbContext.SaveChanges();
            var remItems = SmsarkDbContext.reservationItems.Where(a => a.ReservationId == reservID).ToList();
            foreach (var item in remItems)
            {
                SmsarkDbContext.reservationItems.Remove(item);
                var remBed = SmsarkDbContext.Beds.Where(i => i.BedId == item.BedId).FirstOrDefault();
                remBed.IsReserved = false;
            }
            SmsarkDbContext.SaveChanges();
            return View();

        }



    }
}
