
using System.Collections.Generic;


namespace BankOfWizard.Repository.Http
{

    public class HttpRequestObject<T> : HttpObject<T>
        where T : class
    {

        public HttpRequestObject()
        {
        }

        public HttpRequestObject(T item)
            : base(item)
        {
        }

        public HttpRequestObject(IEnumerable<T> items)
            : base(items)
        {
        }
    }
}
