using System.Web.Mvc;
using TradeSharp.Core.ViewModels;
using TradeSharp.Persistence;

namespace TradeSharp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public CompanyController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActionResult CompanyDetails(int id)
        {
            var company = _unitOfWork.Company.GetCompanyById(id);

            if (company == null)
                return HttpNotFound();

            var viewModal = new CompanyViewModal
            {
                Id = company.Id,
                Name = company.Name,
                Quantity = 0,
                Price = 0
            };

            return View("CompanyDetails", viewModal);
        }
    }
}