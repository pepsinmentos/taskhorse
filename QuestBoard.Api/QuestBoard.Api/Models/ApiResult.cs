using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}