using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace Willow.Database
{
    public class DatabaseDataSource : Datasource
    {
        Connection _connection;
        public DatabaseDataSource() : this(new DatabaseConnection()) { }
        public DatabaseDataSource(Connection connection)
        {
            _connection = connection;

            Debug.Assert(!ReferenceEquals(_connection, null));
        }

        public List<T> GetList<T>(Query the_query)
        { 
            _connection.Lease();
            try
            {
                return _connection.Fetch<T>(the_query);
            }
            finally
            {
                _connection.Release();
            }
        }
        public IList GetList(Type returnType, Query the_query)
        {
            _connection.Lease();
            try
            {
                return _connection.Fetch(returnType, the_query);
            }
            finally
            {
                _connection.Release();
            }
        }
    }
}
