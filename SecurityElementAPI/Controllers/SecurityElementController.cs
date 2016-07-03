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
        static readonly Dictionary<Guid, SecurityElementRequest> input = new Dictionary<Guid, SecurityElementRequest>();
        static readonly Dictionary<Guid, SecEleRes> output = new Dictionary<Guid, SecEleRes>();
        // POST: api/Products
        [HttpPost]
        [ActionName("SecCon")]
        [ResponseType(typeof(SecurityElementResponse))]
        public HttpResponseMessage PostProduct(SecurityElementRequest req)
        {
            if (ModelState.IsValid && req!=null)
            {
                SecurityElementDBEntities db = new SecurityElementDBEntities();
                SecurityElementRequest request = new SecurityElementRequest();
                SecurityElementResponse response = new SecurityElementResponse();

                request.Id =System.Web.HttpUtility.HtmlEncode(req.Id);
                int id = Convert.ToInt32(request.Id);
                var resp = db.SecurityMasters.SingleOrDefault(sec => sec.Id == id);

                if(resp != null)
                {
                    response.Id = resp.Id;
                    response.CID = resp.CID;
                    response.UID = resp.UID;
                }
                
                var Id = Guid.NewGuid();
                input[Id] = req;

                var res = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    //Content = new StringContent(Convert.ToString(response.Id) +response.UID+response.CID+ " success is this")
                    Content = new StringContent(response + " success is this")
                };
                res.Headers.Location = new Uri(Url.Link("DefaultApi", new { action = "type", Id = Id }));
                return res;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
