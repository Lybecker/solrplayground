using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using AutoMapper;

namespace Lybecker.SolrNetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new FileParser<Dvd>();
            var dvds = parser.Parse("dvd.csv").ToList();

            Mapper.CreateMap<Dvd, SolrDvd>();
            var solrDvds = Mapper.Map<IEnumerable<Dvd>, IEnumerable<SolrDvd>>(dvds);


            Console.WriteLine("Adding to Solr index");
            // IoC ServiceLocator Anti-Pattern   
            Startup.Init<SolrDvd>("http://localhost:8983/solr/collection1");
            var solr = ServiceLocator.Current.GetInstance<ISolrOperations<SolrDvd>>();

            solr.AddRange(solrDvds);

            solr.Commit();

            Console.WriteLine("Done adding to Solr");
            Console.ReadLine();
        }

        //var results = solr.Query("Warner Brothers", new QueryOptions()
        //{
        //    Rows = 25,
        //    Start = 0,
        //    Facet = new FacetParameters
        //    {
        //        Queries = new ISolrFacetQuery[] { new SolrFacetFieldQuery("Studio") },
        //        MinCount = 1, Limit = 3
        //    }
        //});

        //Console.WriteLine("Results (total {0}):", results.NumFound);
        //foreach (var result in results)
        //{
        //    Console.WriteLine("\t" + result);
        //}

        //Console.WriteLine("Tags:");

        //foreach (var facet in results.FacetFields["tag"])
        //{
        //    Console.WriteLine("\t {0}: {1}", facet.Key, facet.Value);
        //} 
    }
}