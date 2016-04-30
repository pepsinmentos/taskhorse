using QuestBoard.Api.Interfaces;
using QuestBoard.Api.Models;
using QuestBoard.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestBoard.Api.Repositories
{
    public interface IBoardRepository : ICreate<Board>, IRead<Board>, IDelete<Board>
    {
    }
}
