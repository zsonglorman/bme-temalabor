﻿//using System;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace Service.Authentication
//{
//    public class RequireHttpsAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
//            {
//                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
//            }
//        }
//    }
//}