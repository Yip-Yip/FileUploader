using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Prototype.Web.Helpers
{
    public static class HtmlExtentions
    {
        public static string GetIPAddress()
        {
            string ip4Address = String.Empty;
            const string AddressFamily = "InterNetwork";

            foreach (IPAddress ipa in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (ipa.AddressFamily.ToString().Equals(AddressFamily, StringComparison.InvariantCultureIgnoreCase))
                {
                    ip4Address = ipa.ToString();
                    break;
                }
            }

            if (ip4Address != String.Empty)
            {
                return ip4Address;
            }

            foreach (IPAddress ipa in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ipa.AddressFamily.ToString().Equals(AddressFamily, StringComparison.InvariantCultureIgnoreCase))
                {
                    ip4Address = ipa.ToString();
                    break;
                }
            }

            return ip4Address;
        }

        public static MvcHtmlString GetMaximumFileUploadSize(this HtmlHelper helper)
        {
            //return MvcHtmlString.Create(Settings.Default.AmendmentsFileUploadSizeMb.ToString());
            return MvcHtmlString.Create("2");

        }
    }
}