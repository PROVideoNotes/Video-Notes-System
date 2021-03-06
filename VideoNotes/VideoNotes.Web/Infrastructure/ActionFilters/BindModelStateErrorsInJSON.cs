﻿namespace VideoNotes.Web.Infrastructure.ActionFilters
{
    using System;
    using System.Web.Mvc;
    using System.Linq;
    using System.Net;

    public class BindModelStateErrorsInJSON : ActionFilterAttribute
    {
      
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;
            if (!modelState.IsValid)
            {
                var errorModel =
                        from x in modelState.Keys
                        where modelState[x].Errors.Count > 0
                        select new
                        {
                            key = x,
                            errors = modelState[x].Errors.
                            Select(y => y.ErrorMessage).
                            ToArray()
                        };

                filterContext.Result = new JsonResult()
                {
                    Data = errorModel
                };

                filterContext.HttpContext.Response.StatusCode =(int)HttpStatusCode.BadRequest;
            }
        }
    }
}