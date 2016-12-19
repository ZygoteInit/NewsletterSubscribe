using AutoMapper;
using GreenFinch.Models;
using GreenFinch.Service;
using GreenFinch.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenFinch.Web.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly ISubscriberService subscriberService;
        private readonly ISourceService sourceService;

        public NewsLetterController(ISubscriberService subscriberService, ISourceService sourceService)
        {
            this.subscriberService = subscriberService;
            this.sourceService = sourceService;
        }

        // GET: Subscribers/Create
        public ActionResult Create()
        {
            ViewBag.SourceId = new SelectList(GetSourceViewModel().ToList(), "SourceId", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include="Id,Email,SubscriptionReason,SourceId")] SubscriberViewModel subscriber)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                Subscriber subscriberModel = Mapper.Map<SubscriberViewModel, Subscriber>(subscriber);
                subscriberService.CreateSubscriber(subscriberModel);
                subscriberService.SaveSubscriber();

                return View("Success");
            }
            catch(Exception ex)
            {
                LogException(ex);
            }

            ViewBag.SourceId = new SelectList(GetSourceViewModel().ToList(), "SourceId", "Name");

            return View();
        }

        public JsonResult CheckIfEmailExists(string Email)
        {
            if (Email == null)
            {
                return Json(false);
            }

            try
            {
                return Json(subscriberService.CheckIfEmailExists(Email));
            }
            catch(Exception ex)
            {
                LogException(ex);
            }

            return Json(false);
        }


        IEnumerable<SourceViewModel> GetSourceViewModel()
        {
            IEnumerable<SourceViewModel> sourceViewModel = new List<SourceViewModel>();
            try
            {
               var sources = sourceService.GetSources();
               sourceViewModel = Mapper.Map<IEnumerable<Source>, IEnumerable<SourceViewModel>>(sources);
            }
            catch(Exception ex)
            {
                LogException(ex);
            }

            return sourceViewModel;
        }

        private void LogException(Exception ex)
        {
            Trace.WriteLine("[GreenfinchNewsLetter]" + ex.Message);
            if (ex.InnerException != null)
            {
                LogException(ex.InnerException);
            }
        }
    }
}