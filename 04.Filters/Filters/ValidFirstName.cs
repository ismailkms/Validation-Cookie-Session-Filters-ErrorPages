using _04.Filters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _04.Filters.Filters
{
    public class ValidFirstName : ActionFilterAttribute
    {
        //OnActionExecuted => İlgili action çalıştıktan sonra çalışır.
        //OnActionExecuting => İlgili action çalışmadan önce çalışır.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.FirstOrDefault(c => c.Key == "customer");
            //ActionArguments controllerdaki actionların parametreleridir. Burada parametresi customer olanı çekiyoruz. (public IActionResult CreateCustomer(Customer customer))

            var customer = dictionary.Value as Customer;

            if (customer.FirstName == "ismail")
                context.Result = new RedirectResult("/Home/Index");

            base.OnActionExecuting(context);
        }
    }
}
