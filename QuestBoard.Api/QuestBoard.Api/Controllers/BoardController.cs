using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using QuestBoard.Api.Filters;
using QuestBoard.Api.Models;
using QuestBoard.Api.Services;

namespace QuestBoard.Api.Controllers
{
    /*[AuthenticateFilter] - This is registered by Autofac in the _FilterModule */
    public class BoardController : ApiController
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;        
        }

        [HttpPost]
        public void Post(Board boardModel)
        {
            _boardService.Create(boardModel);

            HttpContext.Current.Response.StatusCode = 200;
        }

        [HttpGet]
        public Board Get(string id)
        {
            return _boardService.Get(id);
        }

        [HttpGet]
        public List<Board> Get()
        {
            return _boardService.All();
        }
    }
}