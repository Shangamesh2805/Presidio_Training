using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary.Services
{
    public class IRequestBL
    {
        public Task<Request> CreateRequest(Request request);

        public Task<Request> GetRequest(int RequestId);
    }
}
