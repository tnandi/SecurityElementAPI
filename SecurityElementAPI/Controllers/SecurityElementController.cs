using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SecurityElementAPI.Models;


namespace SecurityElementAPI.Controllers
{
    public class SecurityElementController : ApiController
    {
        // POST: api/Products
        [ResponseType(typeof(SecurityElementResponse))]
        public IHttpActionResult PostProduct(SecurityElementRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SecurityElementDBEntities db = new SecurityElementDBEntities();
            SecurityElementResponse resp = new SecurityElementResponse()
            {
                Id = req.Id,
                UID = req.UID,
                CID = req.CID
            };

            if(db.SecurityMasters.Find(req.Id) == null)
            {
                resp.Ack = "FAIL";
            }
            else
            {
                resp.Ack = "SUCCESS";
            }


            return null;
        }
    }
}
