using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_7
{
    internal class Class2
    {
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public IEnumerable<T> Find(Func<T, bool> criteria)
    {
        return items.Where(criteria);
    }
}
