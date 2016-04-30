using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestBoard.Api.Interfaces;
using QuestBoard.Api.Models;

namespace QuestBoard.Api.Repositories
{
    public interface IMemberRepository : IRead<Member>, IDelete<Member>
    {
        Member GetByEmail(string emailAddress);
    }
}
