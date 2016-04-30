using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class Quest
    {
        public string Id { get; set; }
        public string BoardId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}