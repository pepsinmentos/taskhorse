using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestBoard.Api.Models;
using QuestBoard.Api.Repositories;

namespace QuestBoard.Api.Services
{
    public class QuestService : IQuestService
    {
        private readonly IQuestRepository _questRepository;

        public QuestService(IQuestRepository questRepository)
        {
            _questRepository = questRepository;
        }

        public List<Quest> All()
        {
            throw new NotImplementedException();
        }

        public Quest Create(Quest model)
        {
            if (string.IsNullOrWhiteSpace(model.BoardId))
                throw new ArgumentNullException("BoardId cannot be empty");
            if (model.CreatedOn == DateTime.MinValue)
                model.CreatedOn = DateTime.Now;
            if (string.IsNullOrWhiteSpace(model.Id))
                model.Id = Guid.NewGuid().ToString();

            return _questRepository.Create(model);
        }

        public Quest Delete(string id)
        {
            return _questRepository.Delete(id);
        }

        public Quest Get(string id)
        {
            return _questRepository.Get(id);
        }
    }
}