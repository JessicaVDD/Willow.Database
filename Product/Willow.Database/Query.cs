using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Willow.Database
{
    public interface Query
    {
        string SourceName { get; set; }
        string QueryName { get; set; }
    }
}
