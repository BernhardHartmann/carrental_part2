using System;
using System.Net;
using System.Web.Http;
using Payments.Models;
using Payments.RabbitMQ;

namespace Payments.Controllers
{
    public class UserController : ApiController
    {        
           [HttpPost]
        public IHttpActionResult AddUser([FromBody] Users user)
        {
            string reply= "";

            try
            {
                RabbitMQDirectClient client = new RabbitMQDirectClient();
                client.CreateConnection();
                //reply = client.AddUser(user);
                client.Close();
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            return Ok(reply);
        }
    }
}
