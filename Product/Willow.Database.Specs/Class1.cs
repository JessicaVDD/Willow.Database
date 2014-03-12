using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willow.Database.Tests
{
    interface IQuery<TInput, TOutput>
    {
        TInput Input { get; }
        TOutput Output { set; }
        int Result { get; }
    }
    class TheQuery<TInput, TOutput> : IQuery<TInput, TOutput>
    {
        
    }

    class Class1
    {
        public void Test()
        {
            //query class = class met input args
            //return class = class met output args

            //theDatasource = class met geg voor connectie naar db

            //thecontext = connection + transaction

            theDataSource.GetContext().List<ReturnType>(theQuery);   //.List(typeof(ReturnType), theQuery)
            theDataSource.GetContext().First<ReturnType>(theQuery);  //.First(typeof(ReturnType), theQuery)
            theDataSource.GetContext().Execute(theQuery);            //.Execute(typeof(ReturnType), theQuery)

            theQuery.List<ReturnType>();     // Alleen als theQuery : IQuery => statement & type

                
            

            theQuery.Execute().List<ItemType>();
            theQuery.Execute().Value(typeof(ItemType));
            theQuery.Execute().First();
            theQuery.Execute().Now();

            theQuery.Execute().Now().Result<ResultType>();
            theQuery.Execute().Now().Result(typeof(ResultType));
            theQuery.Execute().Now().Result(Ret);

            theQuery.Execute("instance1").List();
            theQuery.Execute("instance1").Value();
            theQuery.Execute("instance1").First();
            theQuery.Execute("instance1").Now();

            theQuery.Execute("instance1").On("sqldatabase").List();
            theQuery.Execute("instance1").On("sqldatabase").Value();
            theQuery.Execute("instance1").On("sqldatabase").First();
            theQuery.Execute("instance1").On("sqldatabase").Now();

            theQuery.Execute("instance1").On("sqldatabase").FromConfig(the_config).WithMap(the_map).ResultIn(Ret).WithMap(the_result_map).List();


            theQuery.Execute("instance1").On("sqldatabase").ResultIn(Ret).List();
            theQuery.Execute("instance1").On("sqldatabase").ResultIn(Ret).Value();
            theQuery.Execute("instance1").On("sqldatabase").ResultIn(Ret).First();
            theQuery.Execute("instance1").On("sqldatabase").ResultIn(theQuery).Now();

            On("sqldatabase").Datasource("instance1").Execute(theQuery).ResultIn(Ret).List();
            On("sqldatabase").Datasource("instance1").Execute(theQuery).ResultIn(Ret).Value();
            On("sqldatabase").Datasource("instance1").Execute(theQuery).ResultIn(Ret).First();
            On("sqldatabase").Datasource("instance1").Execute(theQuery).ResultIn(Ret).Now();

            On("sqldatabase").Datasource("instance1").Execute(theQuery).WithMap(the_map).ResultIn(Ret).WithMap(the_result_map).List();

            On.Default.Datasource("instance1").Execute(theQuery).List();
            On.Default.Datasource("instance1").Execute(theQuery).Value();
            On.Default.Datasource("instance1").Execute(theQuery).First();
            On.Default.Datasource("instance1").Execute(theQuery).Now();

            Datasource("instance1").Execute(theQuery).ResultIn(Ret).List();
            Datasource("instance1").Execute(theQuery).ResultIn(Ret).Value();
            Datasource("instance1").Execute(theQuery).ResultIn(Ret).First();
            Datasource("instance1").Execute(theQuery).ResultIn(Ret).Now();

            Datasource.Default.Execute(theQuery).ResultIn(out Ret).List();
            Datasource.Default.Execute(theQuery).ResultIn(out Ret).Value();
            Datasource.Default.Execute(theQuery).ResultIn(out Ret).First();
            Datasource.Default.Execute(theQuery).ResultIn(out Ret).Now();

            Datasource("instance1").Execute(theQuery).List();
            Datasource("instance1").Execute(theQuery).Value();
            Datasource("instance1").Execute(theQuery).First();
            Datasource("instance1").Execute(theQuery).Now();


            var context = On("sqldatabase").Datasource("instance1").GetContext();
            context.Execute(theQuery).Now();
            context.Execute(theQuery).Now();
            context.Commit();
            context.Rollback();

            // + autodetect distributed transaction & enroll in it

        }
    }
}
