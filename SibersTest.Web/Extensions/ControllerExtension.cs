using SibersTest.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTest.Web.Extensions
{
    public static class ControllerExtension
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<ValidationResult> validationResults)
        {
            if (validationResults == null)
                return;

            foreach (var validationResult in validationResults)
            {
                string key = validationResult.Key ?? string.Empty;
                modelState.AddModelError(key, validationResult.ErrorMessage);
            }
        }
    }
}