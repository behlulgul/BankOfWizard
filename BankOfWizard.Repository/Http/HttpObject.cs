using System.Collections.Generic;


namespace BankOfWizard.Repository.Http
{

    public abstract class HttpObject<T>
        where T : class
    {
        public List<T> Items { get; set; } = new List<T>();


        protected HttpObject()
        {
        }


        protected HttpObject(T item)
        {
            if (null != item)
            {
                Items.Add(item);
            }
        }

        protected HttpObject(IEnumerable<T> items)
        {
            if (null != items)
            {
                Items.AddRange(items);
            }
        }
    }
}
