using System;
using System.Net.Http;

namespace Deezer.Helpers.Interface
{
    public interface IHttpClientHelper
    {
        HttpClient GetHttpClient();
    }
}
