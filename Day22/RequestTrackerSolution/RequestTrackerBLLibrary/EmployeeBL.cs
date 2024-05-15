using RequestTrackerDALLibrary.Repositories;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using RequestTrackerBLLibrary.Services;
using RequestTrackerDALLibrary;

namespace RequestTrackerBLLibrary.BussinessLogics
{
    public class EmployeeBL : IEmployeeServices
    {
        public readonly IRepository<int, Request> _requestRepository;
        public readonly IRepository<int, RequestSolution> _requestSolutionRepository;
        public readonly IRepository<int, SolutionFeedback> _feedbackRepository;

        public EmployeeBL()
        {
            _requestRepository = new RequestRepository(new RequestTrackerContext());
            _requestSolutionRepository = new RequestSolutionRepository(new RequestTrackerContext());
            _feedbackRepository = new FeedbackRepository(new RequestTrackerContext());
        }


        public async Task<int> RaiseRequest(Employee employee)
        {
            Request request = new Request() { RequestStatus = "Ticket Raised", RequestRaisedBy = employee.Id };
            request.BuildRequestFromConsole();
            await _requestRepository.Add(request);
            return request.RequestNumber;

        }


        public List<Request> ViewRequestStatus(Employee employee)
        {
            return employee.RequestsRaised.ToList();

        }


        public async Task<List<RequestSolution>> ViewSolution(Employee employee)
        {
            List<Request> requestList = employee.RequestsRaised.ToList();

            Console.WriteLine("Requests...");

            foreach (Request request in requestList)
            {
                Console.WriteLine(request);

            }

            Console.WriteLine("\nEnter the Request Number To View solutions.");

            int requestNumber = Convert.ToInt32(Console.ReadLine());

            List<RequestSolution> solutions = (List<RequestSolution>)await _requestSolutionRepository.GetAll();
            List<RequestSolution> requestSolutions = new List<RequestSolution>();
            foreach (RequestSolution solution in solutions)
            {
                if (solution.RequestId == requestNumber)
                {
                    requestSolutions.Add(solution);
                }

            }

            return requestSolutions;



        }

        public async Task<bool> RespondToSolution(Employee employee)
        {

            List<RequestSolution> requestSolutions = await ViewSolution(employee);

            foreach (RequestSolution solution in requestSolutions)
            {
                Console.WriteLine(solution);
            }

            Console.WriteLine("Enter the Solution Id to comment");

            int solutionId = Convert.ToInt32(Console.ReadLine());

            RequestSolution sol = await _requestSolutionRepository.GetByKey(solutionId);
            if (sol != null)
            {
                Console.WriteLine("Enter Comment");
                string comment = Console.ReadLine();
                sol.RequestRaiserComment = comment;

                _requestSolutionRepository.Update(sol);

                return true;

            }

            return false;

        }


        public async Task<SolutionFeedback> GiveFeedback(Employee employee)
        {

            List<RequestSolution> requestSolutions = await ViewSolution(employee);

            foreach (RequestSolution solution in requestSolutions)
            {
                Console.WriteLine(solution);
            }

            Console.WriteLine("Enter the Solution Id to add feedback");

            int solutionId = Convert.ToInt32(Console.ReadLine());

            RequestSolution requestSolution = await _requestSolutionRepository.GetByKey(solutionId);

            SolutionFeedback feedback = new SolutionFeedback()
            {
                FeedbackDate = DateTime.Now,

                FeedbackBy = employee.Id,

                SolutionId = requestSolution.SolutionId
            };

            feedback.GetFeedBack();

            await _feedbackRepository.Add(feedback);

            return feedback;


        }




    }
}