using IssuesAPI.Models;
using IssuesAPI.Services.Generic;

namespace IssuesAPI.Services
{
    public interface IIssuesRepository : IGenericRepository<Issues>
    {
        Issues GetIssue(int issueId);
    }
}
