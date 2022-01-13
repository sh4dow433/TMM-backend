using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMM_backend.DataAccess;
using TMM_backend.Models;

namespace TMM_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsRepository _commentsRepo;

        public CommentsController(CommentsRepository commentsRepo)
        {
            _commentsRepo = commentsRepo;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Comment comm)
        {
            if (ModelState.IsValid == false)
            {
                return ValidationProblem(ModelState);
            } 
            if (_commentsRepo.Create(comm))
            {
                return Created("", comm);
            }
            return ValidationProblem();
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var comms = _commentsRepo.GetAll();
            return Ok(comms);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult GetAll(int id)
        {
            _commentsRepo.Delete(id);
            return Ok();
        }
    }
}
