using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Services
{
    public class IAdminServices
    {
        Task<RequestSolution> ProvideSolution(Employee employee);

        Task<List<Request>> GetAllRequests();

        Task<Request> CloseRequest(Employee employee);

        Task<List<SolutionFeedback>> GetSolutionFeedback(Employee employee);
    }
}
