using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TradeSharp.Core;
using TradeSharp.Core.Models;
using TradeSharp.Core.ViewModels;

namespace TradeSharp.Controllers
{
    [Authorize]
    public class InvestmentController : Controller
    {
        private readonly TransactionLog _log;
        private readonly IUnitOfWork _unitOfWork;

        public InvestmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = new InvestmentTransactionLog();
        }

        // GET: Investment
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Buy(int id)
        {
            var userId = User.Identity.GetUserId();
            var company = _unitOfWork.Company.GetCompanyById(id);
            var account = _unitOfWork.BankAccount.GetBankAccountByUserId(userId);

            var currentInvestment = _unitOfWork.Investment.GetInvestmentByCompanyId(company.Id, userId);


            if (account == null)
                return HttpNotFound();

            var viewModel = currentInvestment != null
                ? new InvestmentViewModel(currentInvestment)
                : new InvestmentViewModel(account, company);


            viewModel.Type = TransactionType.Buy;


            return View("InvestmentForm", viewModel);
        }


        public ActionResult Sell(int id)
        {
            var userId = User.Identity.GetUserId();
            var company = _unitOfWork.Company.GetCompanyById(id);
            var account = _unitOfWork.BankAccount.GetBankAccountByUserId(userId);

            var currentInvestment = _unitOfWork.Investment.GetInvestmentByCompanyId(company.Id, userId);

            if (account == null)
                return HttpNotFound();

            var viewModel = currentInvestment == null
                ? new InvestmentViewModel(account, company)
                : new InvestmentViewModel(currentInvestment);

            viewModel.Type = TransactionType.Sell;

            return View("InvestmentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Buy(InvestmentViewModel investment)
        {
            if (!ModelState.IsValid)
                return View("InvestmentForm", investment);
            var currentInvestment = _unitOfWork.Investment.GetInvestment(investment);

            var account = _unitOfWork.BankAccount.GetBankAccountById(investment.AccountId);

            var company = _unitOfWork.Company.GetCompanyById(int.Parse(investment.CompanyId));

            Transaction transaction;

            if (account == null)
                return HttpNotFound();

            if (currentInvestment == null)
            {
                var newInvestment = new Investment(account, company);
                newInvestment.CalculateNewInvestmentAmount(investment.SharePrice, investment.ShareQuantity);
                newInvestment.DecreaseInvestmentCostToBankAccount(account);
                //account.IncreaseBankAccountBalance(investmentAmount);
                _unitOfWork.Investment.AddInvestment(newInvestment);
                transaction = _log.LogTransaction(TransactionType.Buy, newInvestment);
            }
            else
            {
                currentInvestment.CalCurrentInvestmentAmountAndShareQuantity(investment.SharePrice,
                    investment.ShareQuantity, investment.Type);
                account.DecreaseBankAccountBalance(investment.SharePrice*investment.ShareQuantity);
                transaction = _log.LogTransaction(TransactionType.Buy, currentInvestment);
            }

            if (!account.CheckBalanceGreaterThanZero())
                return Json(new {success = false, responseText = "Account Balance Too Low "},
                    JsonRequestBehavior.AllowGet);

            _unitOfWork.Transaction.AddTransaction(transaction);
            _unitOfWork.Complete();


            return Json(new {success = true, responseText = "Share Purchase Was Successfull"},
                JsonRequestBehavior.AllowGet);
            // var viewModel = new InvestmentViewModel(currentInvestment) {Type = TransactionType.Buy};
            // return View("InvestmentForm", investment);
        }


        [HttpPost]
        public ActionResult Sell(InvestmentViewModel investment)
        {
            var currentInvestment = _unitOfWork.Investment.GetInvestment(investment);

            var account = _unitOfWork.BankAccount.GetBankAccountById(investment.AccountId);

            if ((currentInvestment == null) || (account == null))
                return HttpNotFound();

            if (investment.ShareQuantity > investment.CurrentShareQuantity)
                return Json(new {success = false, responseText = "Share Quantity Too High"},
                    JsonRequestBehavior.AllowGet);

            currentInvestment.CalCurrentInvestmentAmountAndShareQuantity(investment.SharePrice, investment.ShareQuantity,
                investment.Type);

            account.IncreaseBankAccountBalance(investment.SharePrice*investment.ShareQuantity);

            //currentInvestment.AddInvestmentSaleToBankAccount(account);

            var transaction = _log.LogTransaction(TransactionType.Sell, currentInvestment);

            if (currentInvestment.ShareQuantity == 0)
                _unitOfWork.Investment.RemoveInvestment(currentInvestment);

            _unitOfWork.Transaction.AddTransaction(transaction);
            _unitOfWork.Complete();

            return Json(new {success = true, responseText = "Share Sale Was Successfull"},
                JsonRequestBehavior.AllowGet);

            //var model = new InvestmentViewModel(currentInvestment) {Type = TransactionType.Sell};

            //return View("InvestmentForm", model);
        }


        public ActionResult ViewProfitAndLoss()
        {
            var userId = User.Identity.GetUserId();

            var bankAccount = _unitOfWork.BankAccount.GetBankAccountInvestmentsByUserId(userId);

            if (bankAccount == null)
                return HttpNotFound();
            var investments = _unitOfWork.Investment.SumInvestments(bankAccount.Investments);

            var viewModel = new ProfitAndLossViewModel
            {
                BankAccountBalance = bankAccount.Balance,
                InvestmentAmount = investments,
                FinalAmount = bankAccount.CalculateProfitOrLoss(investments)
            };

            return View(viewModel);
        }
    }
}