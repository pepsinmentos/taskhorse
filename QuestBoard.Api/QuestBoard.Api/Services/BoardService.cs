using QuestBoard.Api.Models;
using QuestBoard.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestBoard.Api.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IQuestRepository _questRepository;
        public BoardService(IBoardRepository boardRepository, IQuestRepository questRepository)
        {
            _boardRepository = boardRepository;
            _questRepository = questRepository;
        }

        public List<Board> All()
        {
            return _boardRepository.All();
        }

        public Board Create(Board model)
        {
            if (model.CreatedOn == DateTime.MinValue)
                model.CreatedOn = DateTime.Now;

            if (string.IsNullOrEmpty(model.Id))
                model.Id = Guid.NewGuid().ToString();

            return _boardRepository.Create(model);
        }

        public Board Get(string id)
        {

            var board = _boardRepository.Get(id);
            if(board != null)
                board.Quests = _questRepository.AllForBoard(board.Id);
            return board;
        }

        public Board Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}