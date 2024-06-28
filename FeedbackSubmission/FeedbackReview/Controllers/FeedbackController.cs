using FeedbackReview.DAL;
using FeedbackReview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackReview.Controllers
{
	public class FeedbackController : Controller
	{
        private readonly IFeedback _feedbackEF;

		public FeedbackController(IFeedback feedbackEF)
		{
			_feedbackEF = feedbackEF;
		}

		// GET: FeedbackController
		public ActionResult Index()
		{
			var pendingFeedbacks = _feedbackEF.GetAll().Where(f => f.Status == "Pending").ToList();
			var reviewedFeedbacks = _feedbackEF.GetAll().Where(f => f.Status == "Reviewed").ToList();

			//ViewBag.PendingFeedbacks = pendingFeedbacks;
			ViewBag.ReviewedFeedbacks = reviewedFeedbacks;

			//return View();
			return View(pendingFeedbacks);
		}

        // GET: FeedbackController/Details/5
        public ActionResult Details(int id)
		{
			return View();
		}

		// GET: FeedbackController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FeedbackController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: FeedbackController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: FeedbackController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: FeedbackController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: FeedbackController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// POST: FeedbackController/Review/5
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public ActionResult Review(int id)
		{
			var feedback = _feedbackEF.GetById(id);
			if (feedback != null)
			{
				feedback.Status = "Reviewed";
				_feedbackEF.Update(feedback);
			}
			return RedirectToAction(nameof(Index));
		}
	}

	internal class FeedbackIndexViewModel
	{
		public List<Feedback> PendingFeedbacks { get; set; }
		public List<Feedback> ReviewedFeedbacks { get; set; }
	}
}
