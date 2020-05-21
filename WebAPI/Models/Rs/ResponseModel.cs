using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Rs
{
    public class ResponseModel
    {
        public Boolean Success { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
    public class ResponseModelObj
    {
        public Boolean Success { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public Object Object { get; set; }
    }
    public class ResponseModelList
    {
        public Boolean Success { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<Object> LstObject { get; set; }
    }
}