using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            try
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public async Task<Request> DeleteByKey(int key)
        {
            Request item = await GetByKey(key);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();

            }
            return item;
        }

        public async Task<Request> GetByKey(int key)
        {
            Request item = await _context.Requests.FirstOrDefaultAsync(e => e.RequestNumber == key);
            return item;

        }

        //public async Task<List<Request>> GetAll()
        //{
        //    return await _context.Requests.ToListAsync();
        //}

        public async Task<Request> Update(Request entity)
        {
          

            Request item = await GetByKey(entity.RequestNumber);
            if (item != null)
            {
                _context.Update(entity);
                _context.SaveChanges();
                return entity;
            }

            return null;

        }

        async Task<IList<Request>> IRepository<int, Request>.GetAll()
        {
            return await _context.Requests.ToListAsync();
        }
    }
}

