using System.Collections.Generic;

namespace BayMarch.Data
{
    public interface IDataControl<T>
    {
        public T Get(long id);
        public IEnumerable<T> GetList();
    }
}
