using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using Movie_Hunter_FinalProject.Models;
using Movie_Hunter_FinalProject.RepoInterface;
using Stripe;

namespace Stripe_Payment.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class PaymentsController : Controller
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly SignInManager<SystemUser> _signInManager;
        private readonly IGenericRepo<LookUpTable> _lookUpTableRepository;
        private readonly ILookValueRepo _lookValueRepo;
        public PaymentsController(UserManager<SystemUser> _userManager, 
            IGenericRepo<LookUpTable> _lookUpTableRepository,
            ILookValueRepo _lookValueRepo, SignInManager<SystemUser> _signInManager)
        {
            this._userManager = _userManager;
            this._lookUpTableRepository = _lookUpTableRepository;
            this._lookValueRepo= _lookValueRepo;
            this._signInManager= _signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Charge(string stripeEmail, string stripeToken,string test, string plan)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken

            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = long.Parse(test),//charge in cents
                Description = "test Charge",
                Currency = "usd",
                Customer = customer.Id

            });

            switch (plan)
            {
                case "Basic":
                    await CheckPlanExits("Basic");
                    break;
                case "Pro":
                   await  CheckPlanExits("Pro");
                    break;
                case "Premium":
                  await  CheckPlanExits("Premium");
                    break;
            }



            return View();
            // further application specific code goes here

        }

		private async Task<bool> CheckPlanExits(string plan)
		{
			if (_lookUpTableRepository.GetByName("Plans") == null)
			{
				_lookUpTableRepository.Create(new LookUpTable() { LookUpName = "Plans" });

				var PlanId = _lookUpTableRepository.GetByName("Plans").Id;
				_lookValueRepo.Create(new LookUpValues() { lookupId = PlanId, Value = plan });

				var SelectedPlanID = _lookValueRepo.GetAll().FirstOrDefault(p => p.Value == plan).Id;
				var CurrentUser = await _userManager.GetUserAsync(User);
				CurrentUser.Plan_Id = SelectedPlanID;
				var result = await _userManager.UpdateAsync(CurrentUser);
				await _signInManager.RefreshSignInAsync(CurrentUser);
				return true;
			}
			else
			{
				var PlanId = _lookUpTableRepository.GetByName("Plans").Id;
                var result = _lookValueRepo.GetAll().FirstOrDefault(c=>c.Value== plan);
                if (result == null)
                {
					_lookValueRepo.Create(new LookUpValues() { lookupId = PlanId, Value = plan });
					var SelectedPlanID = _lookValueRepo.GetAll().FirstOrDefault(p => p.Value == plan).Id;
					var CurrentUser = await _userManager.GetUserAsync(User);
					CurrentUser.Plan_Id = SelectedPlanID;
					var result2 = await _userManager.UpdateAsync(CurrentUser);
					await _signInManager.RefreshSignInAsync(CurrentUser);
					return true;
                }
                else
                {
					var CurrentUser = await _userManager.GetUserAsync(User);
					CurrentUser.Plan_Id = result.Id;
					var result2 = await _userManager.UpdateAsync(CurrentUser);

                    if (result2.Succeeded)
                    {
						await _signInManager.RefreshSignInAsync(CurrentUser);
						return true;

                    }
                    else
                    {
                        return false;
                    }
				}
			}

		}
	}
}
