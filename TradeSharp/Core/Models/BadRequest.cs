﻿using System.Web.Mvc;

namespace TradeSharp.Core.Models
{
    public class BadRequest : JsonResult
    {
        public BadRequest()
        {
        }

        public BadRequest(string message)
        {
            Data = message;
        }

        public BadRequest(object data)
        {
            Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = 400;
            base.ExecuteResult(context);
        }
    }
}