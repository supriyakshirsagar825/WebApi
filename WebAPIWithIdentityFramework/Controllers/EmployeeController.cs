﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIWithIdentityFramework.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
           using(WEBAPIDATABASEEntities db=new WEBAPIDATABASEEntities())
            {
                 var list=  db.DBEmployees.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            
        }
    }
}