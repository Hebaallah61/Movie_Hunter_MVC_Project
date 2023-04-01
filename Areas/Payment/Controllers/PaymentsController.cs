using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Stripe_Payment.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public ActionResult Charge(string stripeEmail, string stripeToken,string test, string plan)
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

            return View();
            // further application specific code goes here

        }
    }
}
