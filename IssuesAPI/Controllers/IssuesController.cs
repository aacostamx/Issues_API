using IssuesAPI.Models;
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
        private readonly IssuesContext _dbContext;

        public IssuesController(IssuesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Issues>> GetAll()
        {
            return _dbContext.Issues.ToList();
        }

        [HttpGet("{id}", Name = "GetIssue")]
        public ActionResult<Issues> GetById(int id)
        {
            var item = _dbContext.Issues.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Issues item)
        {
            item.CreatedAt = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            _dbContext.Issues.Add(item);
            _dbContext.SaveChanges();

            return CreatedAtRoute("GetIssue", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Issues item)
        {
            var issue = _dbContext.Issues.Find(id);
            if (issue == null)
            {
                return NotFound();
            }

            issue.State = item.State;
            issue.Title = item.Title;
            issue.Url = item.Url;
            issue.UpdatedAt = DateTime.Now.ToString("MM/dd/yyyy H:mm");

            _dbContext.Issues.Update(issue);
            _dbContext.SaveChanges();
            return Ok(issue);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _dbContext.Issues.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _dbContext.Issues.Remove(todo);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }

}