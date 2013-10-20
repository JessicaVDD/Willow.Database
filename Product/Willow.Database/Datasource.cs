using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Willow.Database
{
    public interface Datasource
    {
        List<T> GetList<T>(Query the_query);
    }
}
