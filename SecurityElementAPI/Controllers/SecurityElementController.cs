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
        static readonly Dictionary<Guid, SecEleReq> input = new Dictionary<Guid, SecEleReq>();
        static readonly Dictionary<Guid, SecEleRes> output = new Dictionary<Guid, SecEleRes>();
        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(SecurityElementResponse))]
        public HttpResponseMessage PostProduct(SecEleReq req)
        {
            if (ModelState.IsValid && req!=null)
            {
                req.dataInput = System.Web.HttpUtility.HtmlEncode(req.dataInput);

                var Id = Guid.NewGuid();
                input[Id] = req;

                var response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(req.dataInput)
                };
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { action = "type", Id = Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
