﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Payments.Controllers
{
    public class testerController : ApiController
    {
        // GET: api/tester
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/tester/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/tester
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/tester/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/tester/5
        public void Delete(int id)
        {
        }
    }
}
