using QuestBoard.Api.Interfaces;
using QuestBoard.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBoard.Api.Services
{
    public interface IQuestService : ICreate<Quest>, IRead<Quest>, IDelete<Quest>
    {
    }
}
