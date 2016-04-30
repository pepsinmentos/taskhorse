using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class ActivityLog
    {
        public Member Member { get; set; }
        public string Activity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}