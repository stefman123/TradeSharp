using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TradeSharp.Core;
using TradeSharp.Core.Models;
using TradeSharp.Core.ViewModels;

namespace TradeSharp.Controllers
{
    [Authorize]
    public class BankAccountController : Controller
    {
        private readonly TransactionLog _log;
        private readonly IUnitOfWork _unitOfWork;

        public BankAccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _log = new BankAccountTransactionLog();
        }

        public ActionResult ViewBankAccount()
        {
            var currentUserId = User.Identity.GetUserId();

            var bankAccount = _unitOfWork.BankAccount.GetBankAccountByUserId(currentUserId);


            if (bankAccount == null)
                return new HttpUnauthorizedResult();

            var viewModel = new BankAccountViewModel
            {
                UserId = User.Identity.GetUserId(),
                Balance = bankAccount.Balance
            };

            return View("BankAccountForm", viewModel);
        }

        [HttpPost]
        public ActionResult Deposit(BankAccountViewModel viewModel)
        {
            var currentUserId = User.Identity.GetUserId();

            var bankAccount = _unitOfWork.BankAccount.GetBankAccountByUserId(currentUserId);

            if (bankAccount == null)
                return HttpNotFound();

            bankAccount.IncreaseBankAccountBalance(viewModel.Amount);


            var transaction = _log.LogTransaction(TransactionType.Deposit, bankAccount);

            transaction.Amount = viewModel.Amount;

            _unitOfWork.Transaction.AddTransaction(transaction);

            _unitOfWork.Complete();

            viewModel.Balance = bankAccount.Balance;


            return new JsonResult
            {
                Data = new
                {
                    success = true,
                    message = "Deposited Succesfully!",
                    view = View("BankAccountForm", viewModel)
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public ActionResult Withdraw(BankAccountViewModel viewModel)
        {
            var currentUserId = User.Identity.GetUserId();

            var bankAccount = _unitOfWork.BankAccount.GetBankAccountByUserId(currentUserId);
            if (bankAccount == null)
                return HttpNotFound();

            bankAccount.DecreaseBankAccountBalance(viewModel.Amount);

            if (!bankAccount.CheckBalanceGreaterThanZero())
                return Json(new {success = false, responseText = "Transaction Value Too High "},
                    JsonRequestBehavior.AllowGet);


            var transaction = _log.LogTransaction(TransactionType.Deposit, bankAccount);


            transaction.Amount = viewModel.Amount;

            _unitOfWork.Transaction.AddTransaction(transaction);

            _unitOfWork.Complete();

            return new JsonResult
            {
                Data = new
                {
                    success = true,
                    message = "Withdrawal was succesfull",
                    view = View("BankAccountForm", viewModel)
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            //return RedirectToAction("Index","Home");
        }
    }
}