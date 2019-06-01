using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using Newtonsoft.Json.Serialization;

using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FinanceWebsite.MVC.App_Start.FormatterConfig), "ConfigFormat")]
namespace FinanceWebsite.MVC.App_Start
{
    public static class FormatterConfig
    {
        public static void ConfigFormat()
        {
            var config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}