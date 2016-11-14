using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TradeSharp.Core.ViewModels;
using TradeSharp.Persistence;

namespace TradeSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActionResult Index()
        {
            var companies = _unitOfWork.Company.GetCompanies();

            var viewModel = new UserAccountCompainesViewModel
            {
                UserId = User.Identity.GetUserId(),
                Companies = companies
            };

            return View(viewModel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}