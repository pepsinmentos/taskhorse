using QuestBoard.Api.Interfaces;
using QuestBoard.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBoard.Api.Repositories
{
    public interface IQuestRepository : ICreate<Quest>, IRead<Quest>, IDelete<Quest>
    {
        List<Quest>AllForBoard(string boardId);
    }
}
