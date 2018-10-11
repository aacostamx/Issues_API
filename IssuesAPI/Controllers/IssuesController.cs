using IssuesAPI.Models;
using IssuesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IssuesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        private readonly IIssuesRepository _repository;

        public IssuesController(IIssuesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Issues>> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetIssue")]
        public ActionResult<Issues> GetById(int id)
        {
            var item = _repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Issues item)
        {
            item = _repository.Add(item);
            return CreatedAtRoute("GetIssue", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Issues item)
        {
            var issue = _repository.Get(id);
            if (issue == null)
            {
                return NotFound();
            }

            _repository.Update(item, id);

            return Ok(issue);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var issue = _repository.Get(id);
            if (issue == null)
            {
                return NotFound();
            }
            _repository.Delete(issue);
            return NoContent();
        }

    }

}