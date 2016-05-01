using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class Member
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SignUpSource { get; set; }
        public DateTime CreatedOn { get; set; }

        public Member()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now;
        }
    }
}