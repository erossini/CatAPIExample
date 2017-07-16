using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatAPI.Helpers
{
    public static class UIHelpers
    {
        public static string GetCurrentUrl()
        {
            return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
        }
    }
}