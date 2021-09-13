using System;
using System.Net.Http;
using System.Threading.Tasks;
using Deezer.Models.Business;

namespace Deezer.Helpers.Interface
{
    public interface IDataTransferHelper
    {
        Task<DataTransferHandlerResult<TResult>> SendClientAsync<TResult>
            (string route, HttpMethod httpMethod, object jsonContent = null) where TResult : class;
    }
}
