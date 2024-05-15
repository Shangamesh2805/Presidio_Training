using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class FeedbackRepository : IRepository<int, SolutionFeedback>
    {
        private readonly RequestTrackerContext _context;

        public FeedbackRepository(RequestTrackerContext context)
        {
            _context = context;

        }

        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            try
            {
                _context.Feedbacks.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;


        }

        public async Task<SolutionFeedback> DeleteByKey(int key)
        {
            SolutionFeedback item = await GetByKey(key);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();

            }
            return item;
        }

        public async Task<SolutionFeedback> GetByKey(int key)
        {
            SolutionFeedback item = await _context.Feedbacks.FirstOrDefaultAsync(e => e.SolutionId == key);
            return item;

        }

        //public async Task<List<SolutionFeedback>> GetAll()
        //{
        //    return await _context.Feedbacks.ToListAsync();
        //}

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            // _context.Update(entity);
            //await _context.SaveChangesAsync();
            //return entity;

            SolutionFeedback item = await GetByKey(entity.FeedbackId);
            if (item != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            return null;

        }

         async Task<IList<SolutionFeedback>> IRepository<int, SolutionFeedback>.GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
        }
    }
}