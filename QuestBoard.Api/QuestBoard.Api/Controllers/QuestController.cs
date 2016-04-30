using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using QuestBoard.Api.Models;
using QuestBoard.Api.Services;

namespace QuestBoard.Api.Controllers
{
    public class QuestController : ApiController
    {
        private readonly IQuestService _questService;

        public QuestController(IQuestService questService)
        {
            _questService = questService;
        }

        [HttpGet]
        public Quest Get(string id)
        {
            return _questService.Get(id);
        }

        [HttpPost]
        [Route("api/board/{id}/quest/")]
        public Quest Post(Quest quest)
        {
            return _questService.Create(quest);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            _questService.Delete(id);
        }
    }
}