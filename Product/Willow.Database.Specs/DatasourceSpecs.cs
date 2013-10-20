using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Willow.Testing.Observations.RhinoMocks;
using Willow.Testing.Extensions;

namespace Willow.Database.Tests
{
    [Subject(typeof(Datasource))]
    public class when_retrieving_a_list_from_a_datasource : Observes<Datasource, DatabaseDataSource>
    {
        Establish e = () => 
        {
            the_source_list = new List<TheListType> { new TheListType(), new TheListType(), new TheListType() };

            the_query = fake.an<Query>();
            the_query.setup(x => x.SourceName).Return(() => "thesource");
            the_query.setup(x => x.QueryName).Return(() => "thequery");

            the_connection = depends.on<Connection>();
            the_connection.setup(x => x.Fetch<TheListType>(the_query)).Return(the_source_list);

            the_connection.received(x => x.Lease()).OnlyOnce();
            the_connection.received(x => x.Release()).OnlyOnce();
            the_connection.received(x => x.Fetch<TheListType>(the_query)).OnlyOnce();
        };

        Because b = () =>
        {
            the_list = sut.GetList<TheListType>(the_query);
        };

        It should_return_a_list_with_more_then_one_item = () =>
        {
            the_list.ShouldNotBeNull();
            the_list.ShouldNotBeEmpty();
        };

        It should_return_a_list_without_null_items = () =>
        {
            the_list.Any(x => ReferenceEquals(x, null)).ShouldBeFalse();
        };

        It should_return_a_list_with_all_the_items_satisfying_the_query = () =>
        {
            the_list.ShouldContain(the_source_list);
            the_source_list.ShouldContain(the_list);
        };
        
        static Query the_query;
        static List<TheListType> the_list;
        static List<TheListType> the_source_list;
        static Connection the_connection;
    }

    public class TheListType { }
}
