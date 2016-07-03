using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecurityElementAPI.Models
{
    public class SecurityElementRequest
    {
        //public string MethodToCall { get; set; }
        [Required]
        [MaxLength(140)]
        public string Id { get; set; }
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
    public class SecEleReq
    {
        [Required]
        [MaxLength(140)]
        public string dataInput { get; set; }
    }
    public class SecEleRes
    {
        [Required]
        [MaxLength(140)]
        public string dataInput { get; set; }
    }
}