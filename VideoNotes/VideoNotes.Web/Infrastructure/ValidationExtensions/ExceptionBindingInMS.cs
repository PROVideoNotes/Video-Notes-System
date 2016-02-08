using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoNotes.Validation.Common.Helpers;


namespace VideoNotes.Web.Infrastructure.ValidationExtensions
{
    public static class ExceptionBindingInMS
    {
        public static void AddModelErrors(this ModelStateDictionary state,
       ValidationException exception)
        {
            foreach (var error in exception.Errors)
                state.AddModelError(error.Key, error.Message);
        }
    }
}