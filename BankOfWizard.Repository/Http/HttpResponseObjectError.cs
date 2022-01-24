using System.Collections.Generic;

namespace BankOfWizard.Repository.Http
{

    public class HttpResponseObjectError<T> : HttpResponseObject<T>
        where T : class
    {

        public HttpResponseObjectError()
        {
            InitializeToBadRequest();
        }

        public HttpResponseObjectError(T item)
            : base(item)
        {
            InitializeToBadRequest();
        }

        public HttpResponseObjectError(IEnumerable<T> items)
            : base(items)
        {
            InitializeToBadRequest();
        }

        private void InitializeToBadRequest()
        {
            Status = 400;
            Message = "Bad Request";
        }
    }
}
