using Sorted.DataContract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorted.Service
{
    public interface IRainfallService
    {
        Task<GetRainfallResponse> Get(int stationId);
    }
}
