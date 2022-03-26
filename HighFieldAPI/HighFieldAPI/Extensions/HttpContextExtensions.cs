using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HighFieldAPI.Extensions
{
    public static class HttpContextExtensions
    {
        public async static Task InsertParametersPaginationInHeader<T>(this HttpContext httpContext,
            IQueryable<T> queryable)
        {

            if (httpContext == null) { throw new ArgumentNullException(nameof(httpContext)); }

            double count =await Task.FromResult(queryable.Count());
            httpContext.Response.Headers.Add("totalAmountOfRecords", count.ToString());
        }
    }
}
