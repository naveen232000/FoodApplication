using FoodAppDALLayer.Interface;
using FoodAppDALLayer.Models;
using FoodAppDALLayer.Repository;
using FoodAppUILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodAppUILayer.Controllers
{
    public class RatingController : Controller
    {
        private IRatingRepository ratingRepository;


        public RatingController(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;

        }

        public ActionResult AddRatings(int id)
        {
            ViewBag.orderid = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRatings(Rating rating)
        {
            int userid = (int)Session["UserId"];
            Rating rat = new Rating();
            {
                rat.RatingCount = rating.RatingCount;
                rat.RatingId = rating.RatingId;
                rat.Comments = rating.Comments;
                rat.UserId = userid;
            };
            ratingRepository.InsertRating(rating);
            ratingRepository.Save();
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}