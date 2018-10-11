using IssuesAPI.Models;
using IssuesAPI.Services.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IssuesAPI.Services
{
    public class IssuesRepository : GenericRepository<Issues>, IIssuesRepository
    {
        public IssuesRepository(IssuesContext context) : base(context) { }

        public Issues GetIssue(int issueId)
        {
            return _context.Issues.Where(c => c.Id == issueId).FirstOrDefault();
        }

        public async Task<Issues> GetSingleAsyn(int issueId)
        {
            return await _context.Set<Issues>().FindAsync(issueId);
        }

        public override Issues Add(Issues issue)
        {
            issue.CreatedAt = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            return base.Add(issue);
        }

        public override Issues Update(Issues issue, object key)
        {
            Issues db = _context.Set<Issues>().Find(key);

            if (db != null)
            {
                db.State = issue.State;
                db.Title = issue.Title;
                db.Url = issue.Url;
                db.UpdatedAt = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            }

            return base.Update(db, key);
        }

        public async override Task<Issues> UpdateAsyn(Issues issue, object key)
        {
            Issues db = await _context.Set<Issues>().FindAsync(key);

            if (db != null)
            {
                db.State = issue.State;
                db.Title = issue.Title;
                db.Url = issue.Url;
                db.UpdatedAt = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            }

            return await base.UpdateAsyn(db, key);
        }
    }
}
