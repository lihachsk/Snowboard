using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snowboard.WebUI.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string MessageError { get; set; }
        public int ErrorNumber { get; set; }
    }
}