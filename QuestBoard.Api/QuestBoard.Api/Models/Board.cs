using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class Board
    {
        public string Id { get; set; }
        public List<Quest> Quests { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public Board()
        {
            Quests = new List<Quest>();
        }
    }
}