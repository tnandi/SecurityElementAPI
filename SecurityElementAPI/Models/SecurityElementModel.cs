using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecurityElementAPI.Models
{
    public class SecurityElementRequest
    {
        public string MethodToCall { get; set; }
        public int Id { get; set; }
        public string UID { get; set; }
        public string CID { get; set; }
    }
    public class SecurityElementResponse
    {
        public int Id { get; set; }
        public string UID { get; set; }
        public string CID { get; set; }
        public string Ack { get; set; }
    }
}