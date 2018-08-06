using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider metadataProvider;
        private readonly IHostingEnvironment hostingEnvironment;
        public CustomExceptionFilterAttribute(IHostingEnvironment hostingEnvironment, IModelMetadataProvider metadataProvider)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.metadataProvider = metadataProvider;
        }
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                if (context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    //string controllerName = context.RouteData.Values["controller"].ToString();
                    //string actionName = context.RouteData.Values["action"].ToString();
                    //string exceptionMsg = $"在执行{controllerName}/{actionName}时产生异常！";
                    context.Result = new JsonResult(new { Code = 0, Result = "fail", Msg = "系统异常，请联系管理员！" });
                }
                else
                {
                    ViewResult viewResult = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                    viewResult.ViewData = new ViewDataDictionary(metadataProvider, context.ModelState);
                    viewResult.ViewData.Add("Exception", context.Exception);
                    context.Result = viewResult;
                }
                context.ExceptionHandled = true;
            }
        }
    }


}
