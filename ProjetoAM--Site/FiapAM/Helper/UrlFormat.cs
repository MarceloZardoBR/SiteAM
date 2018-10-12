using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FiapAM.Helper
{
    public class UrlFormat
    {
        public static String UrlAmigavel(string url)
        {
            url = url.Replace(' ', '-');
            url = Regex.Replace(url, @"[^A-Za-z0-9'()\*\\+_~\:\/\?\-\.,;=#\[\]@!$&]", "");
            url = Regex.Replace(url, @"\W+", "-");
            return url;
        }
    }
}