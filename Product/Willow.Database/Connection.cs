using System;
using System.Collections.Generic;
using System.Collections;

namespace Willow.Database
{
    public interface Connection
    {
        void Lease();
        List<T> Fetch<T>(Query the_query);
        IList Fetch(Type returnType, Query the_query);
        void Release();
    }
}
