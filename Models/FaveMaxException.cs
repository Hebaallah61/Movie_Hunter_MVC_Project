using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Movie_Hunter_FinalProject.Models
{
    public class FaveMaxException :/* ExceptionFilterAttribute, */IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            
            Exception ex = context.Exception;
            context.ExceptionHandled = true;

            context.Result = new ViewResult()
            {
               //StatusCode= 500,
               ViewName = "CustomException"

            };
            //context.Result = new ContentResult { Content = context.Exception.ToString() };
            //base.OnException(context);
        }
    }
}
