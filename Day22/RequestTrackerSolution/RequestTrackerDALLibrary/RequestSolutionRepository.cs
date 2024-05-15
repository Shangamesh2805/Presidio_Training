using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary.Repositories
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        private readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }


        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<RequestSolution> DeleteByKey(int key)
        {
            RequestSolution item = await GetByKey(key);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();

            }
            return item;
        }

        public async Task<RequestSolution> GetByKey(int key)
        {
            RequestSolution item = await _context.RequestSolutions.Include(e => e.Feedbacks).ThenInclude(f => f.FeedbackByEmployee).FirstOrDefaultAsync(e => e.SolutionId == key); ;
            return item;

        }

        public async Task<List<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.Include(e => e.Feedbacks).ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            RequestSolution item = await GetByKey(entity.SolutionId);
            if (item != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            return null;

        }

         async Task<IList<RequestSolution>> IRepository<int, RequestSolution>.GetAll()
        {
            return await _context.RequestSolutions.Include(e => e.Feedbacks).ToListAsync();
        }
    }
}