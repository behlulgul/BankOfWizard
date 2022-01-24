using System.Collections.Generic;

namespace BankOfWizard.Repository.Http
{

    public class HttpResponseObjectSuccess<T> : HttpResponseObject<T>
        where T : class
    {
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 1;


        public HttpResponseObjectSuccess()
        {
        }


        public HttpResponseObjectSuccess(T item)
            : base(item)
        {
        }

        public HttpResponseObjectSuccess(IEnumerable<T> items)
            : base(items)
        {
        }
    }
}
