using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestBoard.Api.Interfaces;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Services
{
    public interface IMemberService : ICreate<Member>
    {
    }
}
