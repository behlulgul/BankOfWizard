using System.Collections.Generic;

namespace BankOfWizard.Repository.Http
{

    public class HttpResponseObject<T> : HttpObject<T>
        where T : class
    {
        public int Size { get; set; } = 0;
        public int Status { get; set; } = 200;
        public string Message { get; set; } = "OK";


        public HttpResponseObject()
        {
        }

        public HttpResponseObject(T item)
            : base(item)
        {
            Size = 1;
        }

        public HttpResponseObject(IEnumerable<T> items)
            : base(items)
        {

        }

        public bool IsOK()
        {
            return 200 == Status;
        }
    }
}
