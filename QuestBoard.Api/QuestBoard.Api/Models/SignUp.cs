﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Models
{
    public class SignUp
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }
    }
}