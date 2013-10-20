using System;
using System.Collections;
using System.Collections.Generic;

namespace Willow.Database
{
    public class DatabaseConnection : Connection
    {
        public void Lease()
        {
            throw new NotImplementedException();
        }

        public IList Fetch(Type returnType, Query the_query)
        {
            throw new NotImplementedException();
        }

        public List<T> Fetch<T>(Query the_query)
        {
            throw new NotImplementedException();
        }

        public void Release()
        {
            throw new NotImplementedException();
        }


    }
}
